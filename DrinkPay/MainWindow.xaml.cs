using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
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
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IDrinkPay currentPage = null;
        public MainWindow()
        {
            InitializeComponent();

            NavigateToPage(new Entry());

            Username.Text = "User: " + Info.getUser();
            btnLogout.ToolTip = "Logout";

            checkZahlung();
            checkAdmin();
        }

        private void NavigateToPage(IDrinkPay page, bool back = false)
        {
            if (!back)
            {
                page.Previous = currentPage;
            }

            //Event-Handler registrieren: hier dazu genutzt, dass Pages dem Fenster mitteilen können welche page angezeigt werden soll
            page.NavigationRequest += Page_NavigationRequest;
            if (currentPage != null)
            {
                //Event-Handler von der vorherigen Page entfernen: 
                currentPage.NavigationRequest -= Page_NavigationRequest;
            }
            currentPage = page;
            headerText.Text = (page as Page).Title;
            cmdBack.IsEnabled = page.AllowsBack;
            cmdHome.IsEnabled = page.AllowsHome;
            frame.Content = page as Page;
        }

        private void Page_NavigationRequest(object sender, IDrinkPay page)
        {
            NavigateToPage(page);
        }

        //Button in Pages extra einfügen -> wenn nicht: Loop
        private void CmdReturn_Click(object sender, RoutedEventArgs e)
        {
            if (currentPage.AllowsBack)
            {
                NavigateToPage(currentPage.Previous, false);
            }
        }

        private void CmdBack_Click(object sender, RoutedEventArgs e)
        {
            if (currentPage.AllowsBack)
            {
                NavigateToPage(currentPage.Previous, true);
            }
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            //Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            //e.Handled = true;
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            NavigateToPage(new Entry());
        }

        private void Cmd_ImpressumClick(object sender, RoutedEventArgs e)
        {
            // NavigateToPage(impressumPage);
        }

        private string get_MailFromDB()
        {
            string sSQL = "SELECT MailAdresse FROM tblUser WHERE [Username] = '" + Info.getUser() + "'";

            return clsDB.Get_String(sSQL, "Mail");
        }

        private string getGesamtbetragfromDB()
        {
            string sSQL = "SELECT Gesamtbetrag FROM tblUser WHERE [Username] = '" + Info.getUser() + "'";

            return clsDB.Get_String(sSQL, "Gesamtbetrag");
        }

        private void sendMail()
        {

            string from = "zahledeinegetraenke@gmail.com";
            string to = get_MailFromDB();

            SmtpClient SmtpMail = new SmtpClient("smtp.gmail.com");
            SmtpMail.Port = 587;
            SmtpMail.Credentials = new System.Net.NetworkCredential("zahledeinegetraenke", "Ratiborer.Wohnheim.123");
            SmtpMail.EnableSsl = true;

            MailMessage myMail = new MailMessage(from, to);
            myMail.Subject = "Suff bezahlen (Rati EG) " + DateTime.Now.ToString("dd.MM.yyyy - hh:mm") ;
            myMail.Priority = MailPriority.Normal;
            myMail.IsBodyHtml = true;
            myMail.Body = "<html>" +
                "<body style='text-align:center, margin:auto'>" +
                "<h2>Zahlungserinnerung:</h2>" +
                "<p><br>Bitte bezahle " + getGesamtbetragfromDB() + " auf das folgende PayPal-Konto:<br>test@mail.de</p>" +
                "<a href='www.google.de'>Platzhalter</a>" +
                "<p><br>Viele Grüße<br></p>" +
                "<p>Rati EG</p>" + 
                "</body>" +
                "</html>";

            SmtpMail.Send(myMail);
        }

        private void checkZahlung()
        {
            string ges = getGesamtbetragfromDB().Replace('€', ' ');
            ges = ges.Trim();

            float gesamtpreis = float.Parse(ges, CultureInfo.CurrentCulture);

            if (gesamtpreis > 20)
            {
                sendMail();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            clsDB.Close_DB_Connection();
            Environment.Exit(Environment.ExitCode); 
        }

        private string getAdminfromDB()
        {
            string sSQL = "SELECT isAdmin FROM tblUser WHERE [Username] = '" + Info.getUser() + "'";

            return clsDB.Get_String(sSQL, "isAdmin");
        }

        private void checkAdmin()
        {
            if (getAdminfromDB().Equals("false"))
            {
                Info.setAdmin(false);
            }
            else
            {
                Info.setAdmin(true);
            }
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }
    }
}
