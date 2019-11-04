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

namespace KAI___Gammal_Tenta2
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        Tävlare tävlare;
        Skytte skytte;
        List<Tävlare> spelareList = new List<Tävlare>();
        int[] skjutresultatet;

        int räknareFörStående = 0;
        int räknareFörLiggande = 0;

        public MainWindow()
        {
            InitializeComponent();
            btnOK.IsEnabled = false;
        }
        private void RäknareCheck()
        {
            räknareFörLiggande = 0;
            räknareFörStående = 0;

            foreach (var spelare in spelareList)
            {
                if (listbox1.SelectedItem.Equals($"{spelare.StartNummber}: {spelare.Förnamn} {spelare.Efternamn}"))
                {
                    foreach (var skyttes in spelare.SkyttesResultat)
                    {
                        if (skyttes.typAvSkytte == "Stående")
                        {
                            räknareFörStående++;
                        }
                        if (skyttes.typAvSkytte == "Liggande")
                        {
                            räknareFörLiggande++;
                        }
                    }
                }
            }
        }
        private void ControlSkjutningar()
        {
            if (räknareFörLiggande == 2)
            {
                rbtnLiggande.IsEnabled = false;
                rbtnLiggande.IsChecked = false;
                rbtnStående.IsChecked = true;
            }
            if (räknareFörStående == 2)
            {
                rbtnStående.IsEnabled = false;
                rbtnStående.IsChecked = false;
                rbtnLiggande.IsChecked = true;
            }
            if ((räknareFörLiggande == 2) && (räknareFörStående == 2))
            {
                btnOK.IsEnabled = false;
                MessageBox.Show("4 skjutningar har klarats.");
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tävlare = new Tävlare(boxFörnamn.Text, boxEfternamn.Text, boxland.Text);
            spelareList.Add(tävlare);
            Visatävlare();
        }
        private void VisarListbox2()
        {
            listbox2.Items.Clear();
            foreach (var spelare in spelareList)
            {
                if (listbox1.SelectedItem.Equals($"{spelare.StartNummber}: {spelare.Förnamn} {spelare.Efternamn}"))
                {
                    foreach (var skyttes in spelare.SkyttesResultat)
                    {
                        listbox2.Items.Add($"{skyttes.antalStraffrundor}, {skyttes.typAvSkytte}");
                    }
                }
            }

        }
        private void VisarListbox3()
        {
            listbox3.Items.Clear();
            foreach (var spelare in spelareList)
            {
                if (listbox1.SelectedItem.Equals($"{spelare.StartNummber}: {spelare.Förnamn} {spelare.Efternamn}"))
                {
                    foreach (var skyttes in spelare.SkyttesResultat)
                    {
                        string resultatnummer = "";
                        for (int i = 0; i < skyttes.Resultat.Length; i++)
                        {
                            resultatnummer += skyttes.Resultat[i];
                        }
                        listbox3.Items.Add(resultatnummer);
                    }
                }
            }
        }
        private void Visatävlare()
        {
            listbox1.Items.Clear();
            foreach(var spelare in spelareList)
            {
                listbox1.Items.Add($"{spelare.Förnamn} {spelare.Efternamn}");
            }
        }
        private void StartNummerCalc()
        {
            int i = 0;
            listbox1.Items.Clear();

            foreach (var spelare in spelareList)
            {
                i++;
                spelare.skapaStartnummber(i);
                listbox1.Items.Add($"{spelare.StartNummber}: {spelare.Förnamn} {spelare.Efternamn}");
            }
        }
        private void SkjutArrayKalk()
        {
            skjutresultatet = new int[5];
            if (träffa1.IsChecked == true) { skjutresultatet[0] = 0; } else { skjutresultatet[0] = 1; }
            if (träffa2.IsChecked == true) { skjutresultatet[1] = 0; } else { skjutresultatet[1] = 1; }
            if (träffa3.IsChecked == true) { skjutresultatet[2] = 0; } else { skjutresultatet[2] = 1; }
            if (träffa4.IsChecked == true) { skjutresultatet[3] = 0; } else { skjutresultatet[3] = 1; }
            if (träffa5.IsChecked == true) { skjutresultatet[4] = 0; } else { skjutresultatet[4] = 1; }

        }
        private int SkjutresultatetKalk()
        {
            int i = 0;
            SkjutArrayKalk();

            for (int j =0; j<skjutresultatet.Length; j++)
            {
                if (skjutresultatet[j] == 1)
                {
                    i++;
                }
            }
            return i;
        }
        private void MeddelandeFörStraffrundor(int straffrunda)
        {
            if (straffrunda == 0)
            {
                MessageBox.Show("Åkaren fick ingen straffrunda.");
            }
            else if (straffrunda == 1)
            {
                MessageBox.Show("Åkaren fick en straffrunda.");
            }
            else if (straffrunda >= 2)
            {
                MessageBox.Show($"Åkaren fick {straffrunda} straffrundor.");
            }
        }
        private void VisarVemVäljs(int straffrunda)
        {
            foreach (var spelare in spelareList)
            {
                if (listbox1.SelectedItem.Equals($"{spelare.StartNummber}: {spelare.Förnamn} {spelare.Efternamn}"))
                {
                    spelare.registreraSkjutresultat(skytte);
                }
            }
        }
        private void TypeCheck()
        {
            if (rbtnLiggande.IsChecked == true)
            {
                skytte = new Skytte("Liggande");
            }
            else if (rbtnStående.IsChecked == true)
            {
                skytte = new Skytte("Stående");
            }
        }
 
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            StartNummerCalc();
            btnOK.IsEnabled = true;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            btnAnmäl.IsEnabled = false;
            btnStartnummer.IsEnabled = false;

            TypeCheck();
            int straffrunda = SkjutresultatetKalk();

            skytte.ResultatCalc(straffrunda, skjutresultatet);

            MeddelandeFörStraffrundor(straffrunda);
            VisarVemVäljs(straffrunda);

            RäknareCheck();
            ControlSkjutningar();

            VisarListbox2();
            VisarListbox3();


        }

        private void listbox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ResetGränsnitt();
            RäknareCheck();
            ControlSkjutningar();
        }
        private void ResetGränsnitt()
        {
            rbtnLiggande.IsEnabled = true;
            rbtnStående.IsEnabled = true;
            btnOK.IsEnabled = true;
            träffa1.IsChecked = false;
            träffa2.IsChecked = false;
            träffa3.IsChecked = false;
            träffa4.IsChecked = false;
            träffa5.IsChecked = false;
            listbox2.Items.Clear();
            listbox3.Items.Clear();
        }
    }
}
