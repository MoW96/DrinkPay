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
        public Entry()
        {
            InitializeComponent();
            btn_DrinkPay.ToolTip = "Getränkeingabe";
            btn_Übersicht.ToolTip = "Übersicht";
            btn_Einstellungen.ToolTip = "Einstellungen";
        }

        public bool AllowsBack => false;

        public bool AllowsHome => false;


        public IDrinkPay Previous { get; set; }
        public event NavigationRequestEventHandler NavigationRequest;

        private void BlueLagoon_MouseEnter(object sender, MouseEventArgs e)
        {
            Image img = ((Image)sender);

            Thickness margin = img.Margin;
            margin.Left = 100 / 1.15;
            margin.Right = 100 / 1.15;
            margin.Top = 100 / 1.15;
            margin.Bottom = 100 / 1.15;
            img.Margin = margin;
        }

        private void BlueLagoon_MouseLeave(object sender, MouseEventArgs e)
        {
            Image img = ((Image)sender);

            Thickness margin = img.Margin;
            margin.Left = 100;
            margin.Right = 100;
            margin.Top = 100;
            margin.Bottom = 100;
            img.Margin = margin;
        }
    }
}
