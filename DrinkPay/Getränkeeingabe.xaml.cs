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
    /// Interaktionslogik für Getränkeeingabe.xaml
    /// </summary>
    public partial class Getränkeeingabe : Page, IDrinkPay
    {
        private double Preis, Gesamtpreis;
        private int anzahl;
        private bool auswahlOk, anzahlOK;
        DateTime dt;

        public Getränkeeingabe()
        {
            InitializeComponent();
        }

        public bool AllowsBack => true;

        public bool AllowsHome => true;


        public IDrinkPay Previous { get; set; }
        public event NavigationRequestEventHandler NavigationRequest;

        private void ComboBoxItemBier_Selected(object sender, RoutedEventArgs e)
        {
            imgBier.Visibility = Visibility.Visible;
            imgCuba.Visibility = Visibility.Collapsed;
            imgGinTonic.Visibility = Visibility.Collapsed;

            auswahlOk = true;
            Preis = 0.4;

            buttonEnable();
        }

        private void ComboBoxItemCuba_Selected(object sender, RoutedEventArgs e)
        {
            imgBier.Visibility = Visibility.Collapsed;
            imgCuba.Visibility = Visibility.Visible;
            imgGinTonic.Visibility = Visibility.Collapsed;

            auswahlOk = true;
            Preis = 1.8;

            buttonEnable();
        }

        private void ComboBoxItemGin_Selected(object sender, RoutedEventArgs e)
        {
            imgBier.Visibility = Visibility.Collapsed;
            imgCuba.Visibility = Visibility.Collapsed;
            imgGinTonic.Visibility = Visibility.Visible;

            auswahlOk = true;
            Preis = 1.0;

            buttonEnable();
        }

        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            imgBier.Visibility = Visibility.Collapsed;
            imgCuba.Visibility = Visibility.Collapsed;
            imgGinTonic.Visibility = Visibility.Collapsed;

            auswahlOk = false;

            buttonEnable();
        }

        private void Anzahl0_Selected(object sender, RoutedEventArgs e)
        {
            anzahlOK = false;
            tbPreis.Text = "-";
            icon_bier1.Visibility = Visibility.Hidden;
            icon_bier2.Visibility = Visibility.Hidden;
            icon_bier3.Visibility = Visibility.Hidden;
            icon_bier4.Visibility = Visibility.Hidden;
            icon_bier5.Visibility = Visibility.Hidden;
            icon_bier6.Visibility = Visibility.Hidden;
            icon_bier7.Visibility = Visibility.Hidden;
            icon_bier8.Visibility = Visibility.Hidden;
            icon_bier9.Visibility = Visibility.Hidden;
            icon_bier10.Visibility = Visibility.Hidden;
            buttonEnable();
        }

        private void Anzahl1_Selected(object sender, RoutedEventArgs e)
        {
            anzahlOK = true;
            anzahl = 1;
            icon_bier1.Visibility = Visibility.Visible;
            icon_bier2.Visibility = Visibility.Hidden;
            icon_bier3.Visibility = Visibility.Hidden;
            icon_bier4.Visibility = Visibility.Hidden;
            icon_bier5.Visibility = Visibility.Hidden;
            icon_bier6.Visibility = Visibility.Hidden;
            icon_bier7.Visibility = Visibility.Hidden;
            icon_bier8.Visibility = Visibility.Hidden;
            icon_bier9.Visibility = Visibility.Hidden;
            icon_bier10.Visibility = Visibility.Hidden;
            buttonEnable();
        }


        private void Anzahl2_Selected(object sender, RoutedEventArgs e)
        {
            anzahlOK = true;
            anzahl = 2;
            icon_bier1.Visibility = Visibility.Visible;
            icon_bier2.Visibility = Visibility.Visible;
            icon_bier3.Visibility = Visibility.Hidden;
            icon_bier4.Visibility = Visibility.Hidden;
            icon_bier5.Visibility = Visibility.Hidden;
            icon_bier6.Visibility = Visibility.Hidden;
            icon_bier7.Visibility = Visibility.Hidden;
            icon_bier8.Visibility = Visibility.Hidden;
            icon_bier9.Visibility = Visibility.Hidden;
            icon_bier10.Visibility = Visibility.Hidden;
            buttonEnable();
        }

        private void Anzahl3_Selected(object sender, RoutedEventArgs e)
        {
            anzahlOK = true;
            anzahl = 3;
            icon_bier1.Visibility = Visibility.Visible;
            icon_bier2.Visibility = Visibility.Visible;
            icon_bier3.Visibility = Visibility.Visible;
            icon_bier4.Visibility = Visibility.Hidden;
            icon_bier5.Visibility = Visibility.Hidden;
            icon_bier6.Visibility = Visibility.Hidden;
            icon_bier7.Visibility = Visibility.Hidden;
            icon_bier8.Visibility = Visibility.Hidden;
            icon_bier9.Visibility = Visibility.Hidden;
            icon_bier10.Visibility = Visibility.Hidden;
            buttonEnable();
        }

        private void Anzahl4_Selected(object sender, RoutedEventArgs e)
        {
            anzahlOK = true;
            anzahl = 4;
            icon_bier1.Visibility = Visibility.Visible;
            icon_bier2.Visibility = Visibility.Visible;
            icon_bier3.Visibility = Visibility.Visible;
            icon_bier4.Visibility = Visibility.Visible;
            icon_bier5.Visibility = Visibility.Hidden;
            icon_bier6.Visibility = Visibility.Hidden;
            icon_bier7.Visibility = Visibility.Hidden;
            icon_bier8.Visibility = Visibility.Hidden;
            icon_bier9.Visibility = Visibility.Hidden;
            icon_bier10.Visibility = Visibility.Hidden;
            buttonEnable();
        }

        private void Anzahl5_Selected(object sender, RoutedEventArgs e)
        {
            anzahlOK = true;
            anzahl = 5;
            icon_bier1.Visibility = Visibility.Visible;
            icon_bier2.Visibility = Visibility.Visible;
            icon_bier3.Visibility = Visibility.Visible;
            icon_bier4.Visibility = Visibility.Visible;
            icon_bier5.Visibility = Visibility.Visible;
            icon_bier6.Visibility = Visibility.Hidden;
            icon_bier7.Visibility = Visibility.Hidden;
            icon_bier8.Visibility = Visibility.Hidden;
            icon_bier9.Visibility = Visibility.Hidden;
            icon_bier10.Visibility = Visibility.Hidden;
            buttonEnable();
        }

        private void Anzahl6_Selected(object sender, RoutedEventArgs e)
        {
            anzahlOK = true;
            anzahl = 6;
            icon_bier1.Visibility = Visibility.Visible;
            icon_bier2.Visibility = Visibility.Visible;
            icon_bier3.Visibility = Visibility.Visible;
            icon_bier4.Visibility = Visibility.Visible;
            icon_bier5.Visibility = Visibility.Visible;
            icon_bier6.Visibility = Visibility.Visible;
            icon_bier7.Visibility = Visibility.Hidden;
            icon_bier8.Visibility = Visibility.Hidden;
            icon_bier9.Visibility = Visibility.Hidden;
            icon_bier10.Visibility = Visibility.Hidden;
            buttonEnable();
        }

        private void Anzahl7_Selected(object sender, RoutedEventArgs e)
        {
            anzahlOK = true;
            anzahl = 7;
            icon_bier1.Visibility = Visibility.Visible;
            icon_bier2.Visibility = Visibility.Visible;
            icon_bier3.Visibility = Visibility.Visible;
            icon_bier4.Visibility = Visibility.Visible;
            icon_bier5.Visibility = Visibility.Visible;
            icon_bier6.Visibility = Visibility.Visible;
            icon_bier7.Visibility = Visibility.Visible;
            icon_bier8.Visibility = Visibility.Hidden;
            icon_bier9.Visibility = Visibility.Hidden;
            icon_bier10.Visibility = Visibility.Hidden;
            buttonEnable();
        }

        private void Anzahl8_Selected(object sender, RoutedEventArgs e)
        {
            anzahlOK = true;
            anzahl = 8;
            icon_bier1.Visibility = Visibility.Visible;
            icon_bier2.Visibility = Visibility.Visible;
            icon_bier3.Visibility = Visibility.Visible;
            icon_bier4.Visibility = Visibility.Visible;
            icon_bier5.Visibility = Visibility.Visible;
            icon_bier6.Visibility = Visibility.Visible;
            icon_bier7.Visibility = Visibility.Visible;
            icon_bier8.Visibility = Visibility.Visible;
            icon_bier9.Visibility = Visibility.Hidden;
            icon_bier10.Visibility = Visibility.Hidden;
            buttonEnable();
        }

        private void Anzahl9_Selected(object sender, RoutedEventArgs e)
        {
            anzahlOK = true;
            anzahl = 9;
            icon_bier1.Visibility = Visibility.Visible;
            icon_bier2.Visibility = Visibility.Visible;
            icon_bier3.Visibility = Visibility.Visible;
            icon_bier4.Visibility = Visibility.Visible;
            icon_bier5.Visibility = Visibility.Visible;
            icon_bier6.Visibility = Visibility.Visible;
            icon_bier7.Visibility = Visibility.Visible;
            icon_bier8.Visibility = Visibility.Visible;
            icon_bier9.Visibility = Visibility.Visible;
            icon_bier10.Visibility = Visibility.Hidden;
            buttonEnable();
        }

        private void Anzahl10_Selected(object sender, RoutedEventArgs e)
        {
            anzahlOK = true;
            anzahl = 10;
            icon_bier1.Visibility = Visibility.Visible;
            icon_bier2.Visibility = Visibility.Visible;
            icon_bier3.Visibility = Visibility.Visible;
            icon_bier4.Visibility = Visibility.Visible;
            icon_bier5.Visibility = Visibility.Visible;
            icon_bier6.Visibility = Visibility.Visible;
            icon_bier7.Visibility = Visibility.Visible;
            icon_bier8.Visibility = Visibility.Visible;
            icon_bier9.Visibility = Visibility.Visible;
            icon_bier10.Visibility = Visibility.Visible;
            buttonEnable();
        }

        private void buttonEnable()
        {
            if (auswahlOk && anzahlOK)
            {
                btnGetränkAbschliesen.IsEnabled = true;

                Math.Round(Preis, 2);
                Gesamtpreis = anzahl * Preis;
                Math.Round(Gesamtpreis, 2);

                tbPreis.Text = anzahl + " * " + Preis.ToString("0.00") + "€ = " + Gesamtpreis.ToString("0.00") + "€";
            }
            else
            {
                btnGetränkAbschliesen.IsEnabled = false;
                tbPreis.Text = "-";
            }
        }

        private string get_GesamtpreisFromDB(string Username)
        {
            string sSQL = "SELECT Gesamtbetrag FROM tblUser WHERE [Username] = '" + Username + "'";

            return clsDB.Get_String(sSQL, "Gesamtbetrag");
        }

        private void btnGetränkAbschliesen_Click(object sender, RoutedEventArgs e)
        {
           dt = DateTime.Now;
            double d_Gesamtbetrag = 0;

            string Selected_Combobox = cbGetränk.SelectedValue.ToString().Replace("System.Windows.Controls.ComboBoxItem: ", "");

            string sql_Add = "INSERT INTO tblDrinks ([Username],[Drink],[Preis],[Anzahl],[Datum]) VALUES('" + Info.getUser() + "','" + Selected_Combobox + "','" + Gesamtpreis.ToString("0.00") + "€','" + anzahl + "',' " + dt.ToString("dd.MM.yyyy | HH:mm") + "')";
            clsDB.Execute_SQL(sql_Add);

            if(get_GesamtpreisFromDB(Info.getUser()) == "") 
            {
                string sql_setGesamtbetragNull = "UPDATE tblUser SET Gesamtbetrag = '0.00€' WHERE Username = '" + Info.getUser() + "'";
                clsDB.Execute_SQL(sql_setGesamtbetragNull);
            }

            string Gesamtbetrag = get_GesamtpreisFromDB(Info.getUser());

            Gesamtbetrag = Gesamtbetrag.Trim(new Char[] { '€' });
            // Gesamtbetrag = Gesamtbetrag.Replace(",", ".");

            d_Gesamtbetrag = Double.Parse(Gesamtbetrag);
            d_Gesamtbetrag += Gesamtpreis;

            string sql_update = "UPDATE tblUser SET Gesamtbetrag = '" + d_Gesamtbetrag.ToString("0.00") + "€'" + "WHERE Username = '" + Info.getUser() + "'";
            clsDB.Execute_SQL(sql_update);

            MessageBox.Show("Getränk wurde bestellt", "Getränkebestellung", MessageBoxButton.OK);

            cbAnzahl.SelectedIndex = 0;
            cbGetränk.SelectedIndex = 0;
            tbPreis.Text = "-";
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            cbAnzahl.SelectedIndex = 0;
            cbGetränk.SelectedIndex = 0;
        }
    }
}
