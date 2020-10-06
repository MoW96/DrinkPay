using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaktionslogik für Übersicht.xaml
    /// </summary>
    public partial class Übersicht : Page, IDrinkPay
    {

        float gesamtpreis;

        public Übersicht()
        {
            InitializeComponent();

            db_find_startRecord();
            db_find_Gesamtpreis();
            setPicturefromGesamtpreis();
            db_find_Anzahl();
        }

        public bool AllowsBack => true;

        public bool AllowsHome => true;


        public IDrinkPay Previous { get; set; }
        public event NavigationRequestEventHandler NavigationRequest;

        private void db_find_startRecord()
        {

            string sSQL = "SELECT * FROM tblDrinks WHERE Username = '" + Info.getUser() + "'";

            dgTermine.ItemsSource = clsDB.Get_DataTable(sSQL).DefaultView;
        }

        private void db_find_Gesamtpreis()
        {
            string sSQL = "SELECT Gesamtbetrag FROM tblUser WHERE Username = '" + Info.getUser() + "'";
            string ges = clsDB.Get_String(sSQL, "Gesamtbetrag").Replace('€', ' ');
            ges = ges.Trim();

            gesamtpreis = float.Parse(ges, CultureInfo.CurrentCulture);
            Gesamtpreis.Text = "  " + clsDB.Get_String(sSQL, "Gesamtbetrag");
        }

        private void db_find_Anzahl()
        {
            // Bier
            string sSQL = "SELECT SUM(Anzahl) AS Gesamtanzahl FROM tblDrinks WHERE Username = '" + Info.getUser() + "' AND Drink = 'Bier'";
            tb_Bier.Text = "  " + clsDB.get_db_string_sum(sSQL);

            // Cuba Libre
            sSQL = "SELECT SUM(Anzahl) AS Gesamtanzahl FROM tblDrinks WHERE Username = '" + Info.getUser() + "' AND Drink = 'Cuba Libre'";
            tb_CubaLibre.Text = "  " + clsDB.get_db_string_sum(sSQL);

            // Gin Tonic
            sSQL = "SELECT SUM(Anzahl) AS Gesamtanzahl FROM tblDrinks WHERE Username = '" + Info.getUser() + "' AND Drink = 'Gin Tonic'";
            tb_GinTonic.Text = "  " + clsDB.get_db_string_sum(sSQL);
        }

        private void setPicturefromGesamtpreis()
        {
            if (gesamtpreis > 20.0)
            {
                Zahlen.Visibility = Visibility.Visible;
                NichtZahlen.Visibility = Visibility.Collapsed;
            }
            else 
            {
                Zahlen.Visibility = Visibility.Collapsed;
                NichtZahlen.Visibility = Visibility.Visible;
            }
        }
    }
}
