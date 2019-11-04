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

namespace Gammal_Tenta4
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        string symbol;
        int randomtal =0;
        Kortlek kortlek;
        Kort kort;

        int kortVärdeFörFörran;

        int antalRätt =0;
        int personBästa = 0;

        public MainWindow()
        {
            InitializeComponent();
            FörStart();
        }

        private void SlumpaTal()
        {
            Random random = new Random();
            randomtal = random.Next(3); // från [https://elearn20.miun.se/moodle/pluginfile.php/575264/mod_assign/intro/Labb%201_2_wpf.pdf]

        }

        private void Symboler(int randomtal)
        {
            if (randomtal == 0)
            {
                symbol += "O";
            }
            else if (randomtal == 1)
            {
                symbol += "$";
            }
            else if (randomtal == 2)
            {
                symbol += "#";
            }
        }
        private void SetSymboler()
        {
            lbl1.Content = symbol.Substring(0, 1);
            lbl2.Content = symbol.Substring(1, 1);
            lbl3.Content = symbol.Substring(2, 1);
        }

        private void JackPotCheck()
        {
            if ((symbol.Equals("OOO")) || (symbol.Equals("$$$"))|| (symbol.Equals("###")))
            {
                MessageBox.Show("Grattis, du fick jackpot!");
            }
        }
        private void StartaBandit()
        {
            for (int i = 0; i <= 2; i++)
            {
                SlumpaTal();
                Symboler(randomtal);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StartaBandit();
            SetSymboler();
            JackPotCheck();

            randomtal = 0;
            symbol = "";
        }
        private void SkapaKort()
        {
            kortlek = new Kortlek();
            kort = new Kort();
            kort = kortlek.DraSlumpmässigtKort();
        }
        private void FörStart()
        {
            SkapaKort();
            SettKort();
        }
        private void SettKort()
        {
            lblsviten.Content = kort.Svit;
            lblkorttyp.Content = kort.Korttyp;
            kortVärdeFörFörran = kort.Värde;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FörStart();
        }
        private void JämförKortFörHögre()
        {
            if(kort.Värde > kortVärdeFörFörran)
            {
                MessageBox.Show($"Grattis, nytta korten var {kort.Korttyp} så du har vunnit!");
                RäknareFörAntalRätt();
            }
            else
            {
                MessageBox.Show($"Noooo, nytta korten var {kort.Svit} {kort.Korttyp}!");
                RäknareFörPersonBästa();
            }
        }

        private void JämförKortFörLögre()
        {
            if (kort.Värde < kortVärdeFörFörran)
            {
                MessageBox.Show($"Grattis, nytta korten var {kort.Korttyp} så du har vunnit!");
                RäknareFörAntalRätt();
            }
            else
            {
                MessageBox.Show($"Noooo, nytta korten var {kort.Svit} {kort.Korttyp}!");
                RäknareFörPersonBästa();
            }
        }
        private void RäknareFörAntalRätt()
        {
            antalRätt++;
            lblAntalRätt.Content = antalRätt;
        }
        private void Resetlbl()
        {
            antalRätt = 0;
            lblAntalRätt.Content = antalRätt;
        }
        private void RäknareFörPersonBästa()
        {
            if (personBästa < antalRätt)
            {
                MessageBox.Show("Nytt rekord!");
                lblPersonBästa.Content = antalRätt;
                personBästa = antalRätt;
            }

            Resetlbl();
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SkapaKort();
            JämförKortFörHögre();
            SettKort();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            SkapaKort();
            JämförKortFörLögre();
            SettKort();
        }
    }
}
