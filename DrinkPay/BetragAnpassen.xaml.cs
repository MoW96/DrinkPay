using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaktionslogik für BetragAnpassen.xaml
    /// </summary>
    public partial class BetragAnpassen : Page, IDrinkPay
    {
        private float gesamtpreis;
        private float gesamtpreisNeu;
        private float abzug;
        private string selectedItem = "";
        private bool canParse;

        public BetragAnpassen()
        {
            InitializeComponent();
            fillCombobox();
        }

        public bool AllowsBack => true;

        public bool AllowsHome => true;


        public IDrinkPay Previous { get; set; }
        public event NavigationRequestEventHandler NavigationRequest;

        private void fillCombobox()
        {
            string sSQL = "SELECT Username FROM tblUser";

            cbUser.ItemsSource = clsDB.Get_DataTable(sSQL).DefaultView;
        }

        private void findGesamtbetragFromDB()
        {
            foreach (var item in cbUser.Items)
            {
                if (item == cbUser.SelectedItem)
                {
                    selectedItem = ((DataRowView)item)["Username"].ToString();
                }
            }


            string sSQL = "SELECT Gesamtbetrag FROM tblUser WHERE [Username] = '" + selectedItem + "'";
            tbOffenerBetrag.Text = "  " + clsDB.Get_String(sSQL, "Gesamtbetrag");

            string ges = clsDB.Get_String(sSQL, "Gesamtbetrag").Replace('€', ' ');
            ges = ges.Trim();

            gesamtpreis = float.Parse(ges, CultureInfo.CurrentCulture);
        }

        private void cbUser_DropDownClosed(object sender, EventArgs e)
        {
            if (cbUser.SelectedIndex != -1)
            {
                findGesamtbetragFromDB();
            }
        }

        private void tbBzahlt_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool canParse;
            try
            {
                float.Parse(tbBzahlt.Text, CultureInfo.CurrentCulture);
                canParse = true;
                tbBzahlt.Foreground = Brushes.Black;
            }
            catch 
            {
                canParse = false;
                tbBzahlt.Foreground = Brushes.Red;
            }
            if (canParse)
            {
                neuBerechnen();
            }

            if (canParse && !tbBzahlt.Text.Equals(""))
            {
                btnBetragAnpassen.IsEnabled = true;
            }
            else
            {
                btnBetragAnpassen.IsEnabled = false;
                string tbNeuText = gesamtpreis.ToString("0.00") + "€";
                tbNeuText.Replace(".", ",");
                tbNeu.Text = tbNeuText;
            }
        }

        private void neuBerechnen()
        {
            abzug = float.Parse(tbBzahlt.Text, CultureInfo.CurrentCulture);

                gesamtpreisNeu = gesamtpreis - abzug;

            string tbNeuText = gesamtpreisNeu.ToString("0.00") + "€";
            tbNeuText.Replace(".", ",");
            tbNeu.Text = tbNeuText;
        }

        private void btnBetragAnpassen_Click(object sender, RoutedEventArgs e)
        {
            string sql_Update = "UPDATE tblUser SET Gesamtbetrag = '" + tbNeu.Text + "' WHERE Username = '" + selectedItem + "'";
            clsDB.Execute_SQL(sql_Update);

            tbNeu.Text = "";
            tbBzahlt.Text = "";

            findGesamtbetragFromDB();

            MessageBox.Show("Der zu zahlende Betrag wurde angepasst", "Betrag angepasst");
        }
    }
}
