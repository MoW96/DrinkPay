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
    /// Interaktionslogik für Übersicht.xaml
    /// </summary>
    public partial class Übersicht : Page, IDrinkPay
    {
        public Übersicht()
        {
            InitializeComponent();

            db_find_startRecord();
            db_find_Gesamtpreis();
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

            Gesamtpreis.Text = "  " + clsDB.Get_String(sSQL, "Gesamtbetrag");
        }

        private void db_find_Anzahl()
        {
            // Bier
            string sSQL = "SELECT SUM(Anzahl) FROM tblDrinks WHERE Username = '" + Info.getUser() + "' AND Drink = 'Bier'";
            tb_Bier.Text = "  " + clsDB.get_db_string_sum(sSQL);

            // Cuba Libre
            sSQL = "SELECT SUM(Anzahl) FROM tblDrinks WHERE Username = '" + Info.getUser() + "' AND Drink = 'Cuba Libre'";
            tb_CubaLibre.Text = "  " + clsDB.get_db_string_sum(sSQL);

            // Gin Tonic
            sSQL = "SELECT SUM(Anzahl) FROM tblDrinks WHERE Username = '" + Info.getUser() + "' AND Drink = 'Gin Tonic'";
            tb_GinTonic.Text = "  " + clsDB.get_db_string_sum(sSQL);
        }
    }
}
