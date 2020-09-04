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
    /// Interaktionslogik für UserAnmeldung.xaml
    /// </summary>
    public partial class UserAnmeldung : Window
    {
        bool MailOK, UsernameOK, PasswortOK, UserOK, AnmeldePWOK;
        public UserAnmeldung()
        {
            InitializeComponent();
        }

        // Registrierung
        private void tbUsername_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!tbUsernameRegistrieren.Text.Equals(""))
            {
                UsernameOK = true;
            }
            else
            {
                UsernameOK = false;
            }
            inputRegOK();
        }

        private void tbPasswort_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!tbPasswortRegistrieren.Text.Equals(""))
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
            if (IsValidEmail(tbPasswortRegistrieren.Text))
            {
                MailOK = true;
            }
            else
            {
                MailOK = false;
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
            //TODO: DB einträge vornehmen und starten
            this.Close();
        }

        // Anmeldung
        private void tbPasswortAnmelden_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!tbPasswortAnmelden.Text.Equals(""))
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
                btnSaveRegistrieren.IsEnabled = true;
            }
            else
            {
                btnSaveRegistrieren.IsEnabled = false;
            }
        }

        private void btnSaveAnmelden_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Mit DB abgleichen und starten
            this.Close();
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

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
