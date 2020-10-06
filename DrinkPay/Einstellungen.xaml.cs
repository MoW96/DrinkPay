using System;
using System.Collections.Generic;
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
    /// Interaktionslogik für Einstellungen.xaml
    /// </summary>
    public partial class Einstellungen : Page, IDrinkPay
    {
        public Einstellungen()
        {
            InitializeComponent();

            setTbMail();
        }

        public bool AllowsBack => true;

        public bool AllowsHome => true;


        public IDrinkPay Previous { get; set; }
        public event NavigationRequestEventHandler NavigationRequest;

        private void setTbMail()
        {
            tbMail.Text = getMailfromDB();
        }

        private string getMailfromDB()
        {
            string sSQL = "SELECT MailAdresse FROM tblUser WHERE [Username] = '" + Info.getUser() + "'";

            return clsDB.Get_String(sSQL, "Mail");
        }

        private void btnMailÄndern_Click(object sender, RoutedEventArgs e)
        {

            MailEingabe mailEingabe = new MailEingabe();
            mailEingabe.ShowDialog();
            string sql_Update = "UPDATE tblUser SET MailAdresse = '" + mailEingabe.Mail + "' WHERE Username = '" + Info.getUser() + "'";
            clsDB.Execute_SQL(sql_Update);

            setTbMail();
        }
    }
}
