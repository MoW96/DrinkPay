using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
    /// Interaktionslogik für UserAnmeldung.xaml
    /// </summary>
    public partial class UserAnmeldung : Window
    {
        bool MailOK, UsernameOK, PasswortOK, UserOK, AnmeldePWOK, NotClose;
        public UserAnmeldung()
        {
            InitializeComponent();

            tbUsernameRegistrieren.ToolTip = "Bitte 'Vorname_Nachname' verwenden!";
        }

        // Registrierung
        private void tbUsername_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!tbUsernameRegistrieren.Text.Equals("") && get_UserFromDB(tbUsernameRegistrieren.Text).Equals("") && tbUsernameRegistrieren.Text.Contains("_") && !tbUsernameRegistrieren.Text.StartsWith("_")
                && !tbUsernameRegistrieren.Text.EndsWith("_"))
            {
                UsernameOK = true;
                tbUsernameRegistrieren.Foreground = Brushes.Black;
            }
            else
            {
                UsernameOK = false;
                tbUsernameRegistrieren.Foreground = Brushes.Red;
            }
            inputRegOK();
        }

        private void tbPasswortRegistrieren_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!tbPasswortRegistrieren.Password.Equals(""))
            {
                PasswortOK = true;
            }
            else
            {
                PasswortOK = false;
            }
            inputRegOK();
        }

        private void tbMailAdress_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (IsValidEmail(tbMailAdressRegistrrieren.Text))
            {
                MailOK = true;
                tbMailAdressRegistrrieren.Foreground = Brushes.Black;
            }
            else
            {
                MailOK = false;
                tbMailAdressRegistrrieren.Foreground = Brushes.Red;
            }
            inputRegOK();
        }

        private void inputRegOK()
        {
            if (MailOK && UsernameOK && PasswortOK)
            {
                btnSaveRegistrieren.IsEnabled = true;
            }
            else
            {
                btnSaveRegistrieren.IsEnabled = false;
            }
        }

        private void btnSaveRegistrieren_Click(object sender, RoutedEventArgs e)
        {
            string sql_Add = "INSERT INTO tblUser ([Username],[MailAdresse],[Passwort],[Gesamtbetrag],[isAdmin]) VALUES('" + tbUsernameRegistrieren.Text + "','" + tbMailAdressRegistrrieren.Text + "','" + hashing(tbPasswortRegistrieren.Password) + "','0,00€','false')";
            clsDB.Execute_SQL(sql_Add);

            Info.setUser(tbUsernameRegistrieren.Text);

            NotClose = true;

            this.Close();
        }

        // Anmeldung

        private void tbPasswortAnmelden_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!tbPasswortAnmelden.Password.Equals(""))
            {
                AnmeldePWOK = true;
            }
            else
            {
                AnmeldePWOK = false;
            }
            inputAnmeldenOK();
        }

        private void tbUserAnmelden_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!tbUserAnmelden.Text.Equals(""))
            {
                UserOK = true;
            }
            else
            {
                UserOK = false;
            }
            inputAnmeldenOK();
        }

        private void inputAnmeldenOK()
        {
            if (UserOK && AnmeldePWOK)
            {
                btnSaveAnmelden.IsEnabled = true;
            }
            else
            {
                btnSaveAnmelden.IsEnabled = false;
            }
        }

        private bool checkPW(string Passwort)
        {
            string PWfromDB = Get_PWFromDB();
            string PWEingabe = hashing(Passwort);

            if (PWfromDB.Equals(PWEingabe))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void EnterPressed(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                if (UserOK && AnmeldePWOK)
                {
                    Anmelden();
                }
            }
        }

        private void btnSaveAnmelden_Click(object sender, RoutedEventArgs e)
        {
            Anmelden();
        }

        private void Anmelden()
        {
            //TODO: Mit DB abgleichen und starten
            if (!get_UserFromDB(tbUserAnmelden.Text).Equals("") && checkPW(tbPasswortAnmelden.Password))
            {
                Info.setUser(tbUserAnmelden.Text);

                NotClose = true;

                this.Close();
            }
            else
            {
                tbAnmeldungFalsch.Text = "Passwort oder Username nicht korrekt";
            }
        }

        // ----------------------------------------------------------------------

        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private string Get_PWFromDB()
        {
            string sSQL = "SELECT Passwort FROM tblUser WHERE [Username] = '" + tbUserAnmelden.Text + "'";

            return clsDB.Get_String(sSQL, "Passwort");
        }

        private string hashing(string Passwort)
        { 
            // with SHA256 und salt
            string salt = "DrinkPay2020";

            using (SHA256 sha256Hash = SHA256.Create())
            {
                //From String to byte array
                byte[] sourceBytes = Encoding.UTF8.GetBytes(Passwort + salt);
                byte[] hashBytes = sha256Hash.ComputeHash(sourceBytes);
                string hash = BitConverter.ToString(hashBytes).Replace("-", String.Empty);

                return hash; 
            }
        }

        private string get_UserFromDB(string Username)
        {
            string sSQL = "SELECT Username FROM tblUser WHERE [Username] = '" + Username + "'";

            return clsDB.Get_String(sSQL, "User");
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (NotClose == false)
            {
                clsDB.Close_DB_Connection();
                Application.Current.Shutdown();
            }
        }
    }
}
