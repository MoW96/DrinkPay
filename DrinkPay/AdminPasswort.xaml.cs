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
using System.Windows.Shapes;

namespace DrinkPay
{
    /// <summary>
    /// Interaktionslogik für AdminPasswort.xaml
    /// </summary>
    public partial class AdminPasswort : Window
    {
        private bool btnEnabled, closing;

        public AdminPasswort()
        {
            InitializeComponent();
            AdminPw.ToolTip = "Admin-Passwort";
        }

        private void AdminPw_KeyDown(object sender, KeyEventArgs e)
        {
            if (btnEnabled)
            {
                if (e.Key == Key.Return)
                {
                    checkAdmin();
                }
            }
        }

        private void btnAdmin_Click(object sender, RoutedEventArgs e)
        {
            checkAdmin();
        }

        private void AdminPw_PasswordChanged(object sender, RoutedEventArgs e)
        {
            checkEingabe();
        }

        private void checkAdmin()
        {
            if (AdminPw.Password.Equals("0815"))
            {
                Info.setAdmin(true);

                string sql_Add = "UPDATE tblUser SET isAdmin = 'true' WHERE Username = '" + Info.getUser() + "'";
                clsDB.Execute_SQL(sql_Add);
                closing = true;

                this.Close();
            }
            else
            {
                AdminFehler.Text = "Falsches Passwort";
            }
        }

        private void checkEingabe()
        {
            if (AdminPw.Password.Equals(""))
            {
                btnEnabled = false;
                btnAdmin.IsEnabled = false;
            }
            else
            {
                btnEnabled = true;
                btnAdmin.IsEnabled = true;
            }
        }
    }
}
