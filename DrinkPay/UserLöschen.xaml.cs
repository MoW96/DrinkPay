using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DrinkPay
{
    /// <summary>
    /// Interaktionslogik für UserLöschen.xaml
    /// </summary>
    public partial class UserLöschen : Page, IDrinkPay
    {
        public UserLöschen()
        {
            InitializeComponent();
            findUser();
        }

        public bool AllowsBack => true;

        public bool AllowsHome => true;


        public IDrinkPay Previous { get; set; }
        public event NavigationRequestEventHandler NavigationRequest;

        private void findUser()
        {
            string sSQL = "SELECT * FROM tblUser WHERE NOT Username = '" + Info.getUser() + "'";

            UserTbl.ItemsSource = clsDB.Get_DataTable(sSQL).DefaultView;
        }

        private void btnDeleteUserFromDB_Click(object sender, RoutedEventArgs e)
        {
            if ((int)UserTbl.SelectedIndex != -1)
            {
                DataRowView row = (DataRowView)UserTbl.Items.GetItemAt(UserTbl.SelectedIndex);

                if (MessageBox.Show("Wollen Sie den User " + "'" + row["Username"].ToString() + "'" + " wirklich löschen?", "Löschen?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    deleteUser(row["Username"].ToString());
                    MessageBox.Show("User: " + "'" + row["Username"].ToString() + "'" + " wurde gelöscht!", "Löschen", MessageBoxButton.OK, MessageBoxImage.Information);
                    findUser();
                }
                else
                {
                    MessageBox.Show("User: " + "'" + row["Username"].ToString() + "'" + " wurde nicht gelöscht!", "Löschen", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void deleteUser(string User)
        {
            string SQL_Del = "DELETE FROM tblUser WHERE [Username] = '" + User + "'";

            clsDB.Execute_SQL(SQL_Del);
        }
    }
}
