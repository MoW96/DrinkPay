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

            buttonEnable();
        }

        private void Anzahl1_Selected(object sender, RoutedEventArgs e)
        {
            anzahlOK = true;
            anzahl = 1;

            buttonEnable();
        }


        private void Anzahl2_Selected(object sender, RoutedEventArgs e)
        {
            anzahlOK = true;
            anzahl = 2;

            buttonEnable();
        }

        private void Anzahl3_Selected(object sender, RoutedEventArgs e)
        {
            anzahlOK = true;
            anzahl = 3;

            buttonEnable();
        }

        private void Anzahl4_Selected(object sender, RoutedEventArgs e)
        {
            anzahlOK = true;
            anzahl = 4;

            buttonEnable();
        }

        private void Anzahl5_Selected(object sender, RoutedEventArgs e)
        {
            anzahlOK = true;
            anzahl = 5;

            buttonEnable();
        }

        private void Anzahl6_Selected(object sender, RoutedEventArgs e)
        {
            anzahlOK = true;
            anzahl = 6;

            buttonEnable();
        }

        private void Anzahl7_Selected(object sender, RoutedEventArgs e)
        {
            anzahlOK = true;
            anzahl = 7;

            buttonEnable();
        }

        private void Anzahl8_Selected(object sender, RoutedEventArgs e)
        {
            anzahlOK = true;
            anzahl = 8;
        }

        private void Anzahl9_Selected(object sender, RoutedEventArgs e)
        {
            anzahlOK = true;
            anzahl = 9;

            buttonEnable();
        }

        private void Anzahl10_Selected(object sender, RoutedEventArgs e)
        {
            anzahlOK = true;
            anzahl = 10;

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
            }
        }
    }
}
