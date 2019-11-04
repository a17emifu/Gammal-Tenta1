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

namespace KAI___Gammal_Tenta1
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        Person kund;
        List<Person> kundlist = new List<Person>();
        

        public MainWindow()
        {
            InitializeComponent();
        }

        private string BokaKund(string förnamn, string efternamn, string resmål, DateTime datum)
        {
            string datumår = datepicker.DisplayDate.ToString("yyyy");
            kund = new Person(förnamn, efternamn, resmål, datum);
            
            return kund.GetBokningsNummer(datumår, kundlist);
        }

        private void VisaLista()
        {
            listboxKunder.Items.Clear();
            kundlist.Add(kund);
            foreach (var person in kundlist)
            {
                listboxKunder.Items.Add($"{person.EfterNamn} {person.BokningsNummer}");
            }
        }

        private bool FörCheckaIn(string efternamn, string bokningsnummer)
        {
            bool CheckaIn = false;
            foreach (var person in kundlist)
            {
                if ((person.EfterNamn.Contains(efternamn)) && (person.BokningsNummer.Contains(bokningsnummer)))
                {
                    CheckaIn = true;
                    person.CheckIn();
                    return CheckaIn;
                }
            }
            return CheckaIn;
        }

        private void MeddelandeFörCheckaIn(bool checkain)
        {
            if (checkain == true)
            {
                MessageBox.Show("Du har checkat in!");
            }
            else
            {
                MessageBox.Show("Vi kan tyvärr inte hitta din bokning i systemet.");
            }
        }

        private int CheckaInBagaget(int antalVäskor, int totalVikt)
        {
            int pris = 0;

            if (antalVäskor > 3)
            {
                MessageBox.Show("Du tillåter inte över 3 resväskor.");
                pris = -1;
                return pris;
            }
            else
            {
                if (totalVikt > 40)
                {
                    pris = 400;
                }
                return pris;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string message;
            message = BokaKund(boxFörnamn.Text, boxEfternman.Text, boxResmål.Text, datepicker.DisplayDate);
            MessageBox.Show(message);
            VisaLista();
        }
        
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            MeddelandeFörCheckaIn(FörCheckaIn(boxEnamn.Text, boxBokningsNummer.Text));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int pris;
            int antal = int.Parse(boxAntal.Text);
            int vikt = int.Parse(boxVikt.Text);
            pris = CheckaInBagaget(antal, vikt);

            if (pris >= 0)
            {
                MessageBox.Show($"Bagaget väger {vikt}kg och priset för att checka in bagaget är {pris}kr.");
            }
            
        }
    }
}
