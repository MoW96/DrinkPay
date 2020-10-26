using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaktionslogik für Entry.xaml
    /// </summary>
    public partial class Entry : Page, IDrinkPay
    {
        int adminClicked;

        public Entry()
        {
            InitializeComponent();
            btn_DrinkPay.ToolTip = "Getränkeingabe";
            btn_Übersicht.ToolTip = "Übersicht";
            btn_Einstellungen.ToolTip = "Einstellungen";
            btn_GesamtbetragAnpassen.ToolTip = "Gesamtbetrag anpassen";
            btn_UserLöschen.ToolTip = "User löschen";

            if (Info.getUser().Equals(""))
            {
                UserAnmeldung start = new UserAnmeldung();
                start.ShowDialog();
            }

            setInfoIsAdmin();
            
            checkAdmin();
        }

        public bool AllowsBack => false;

        public bool AllowsHome => false;


        public IDrinkPay Previous { get; set; }
        public event NavigationRequestEventHandler NavigationRequest;

        private void BlueLagoon_MouseEnter(object sender, MouseEventArgs e)
        {
            BlueLagoon.Height = BlueLagoon.ActualHeight / 1.1;
        }

        private void BlueLagoon_MouseLeave(object sender, MouseEventArgs e)
        {
            BlueLagoon.Height = BlueLagoon.ActualHeight * 1.1;
        }


        private void Bier_MouseEnter(object sender, MouseEventArgs e)
        {
            Bier.Height = Bier.ActualHeight / 1.1;
        }

        private void Bier_MouseLeave(object sender, MouseEventArgs e)
        {
            Bier.Height = Bier.ActualHeight * 1.1;
        }

        private void checkAdmin()
        {
            if (Info.getAdmin())
            {
                btn_UserLöschen.Visibility = Visibility.Visible;
                btn_GesamtbetragAnpassen.Visibility = Visibility.Visible;
            }
            else
            {
                btn_UserLöschen.Visibility = Visibility.Hidden;
                btn_GesamtbetragAnpassen.Visibility = Visibility.Hidden;
            }
        }

        private void btn_DrinkPay_Click(object sender, RoutedEventArgs e)
        {
            NavigationRequest?.Invoke(this, new Getränkeeingabe());
        }

        private void btn_Übersicht_Click(object sender, RoutedEventArgs e)
        {
            NavigationRequest?.Invoke(this, new Übersicht());
        }

        private void btn_Einstellungen_Click(object sender, RoutedEventArgs e)
        {
            NavigationRequest?.Invoke(this, new Einstellungen());
        }

        private void btn_UserLöschen_Click(object sender, RoutedEventArgs e)
        {
            NavigationRequest?.Invoke(this, new UserLöschen());
        }

        private void btn_GesamtbetragAnpassen_Click(object sender, RoutedEventArgs e)
        {
            NavigationRequest?.Invoke(this, new BetragAnpassen());
        }

        private void Admin_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            adminClicked++;

            if (getAdminFromDB().Equals("false"))
            {
                if (adminClicked == 10)
                {
                    AdminPasswort adminPasswort = new AdminPasswort();
                    adminPasswort.ShowDialog();

                    checkAdmin();
                }
            }
        }

        private string getAdminFromDB()
        {
            string sSQL = "SELECT isAdmin FROM tblUser WHERE [Username] = '" + Info.getUser() + "'";

            return clsDB.Get_String(sSQL, "isAdmin");
        }

        private void setInfoIsAdmin()
        {
            if (getAdminFromDB().Equals("true"))
            {
                Info.setAdmin(true);
            }
            else
            {
                Info.setAdmin(false);
            }
        }
    }
}
