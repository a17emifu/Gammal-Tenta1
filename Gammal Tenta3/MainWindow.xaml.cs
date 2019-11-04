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

namespace Gammal_Tenta3
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        Person spelareA;
        Person spelareB;
        Match match;

        public MainWindow()
        {
            InitializeComponent();
        }

        private int FörpackningKalk(int antalbollar, int antalmatcher)
        {
            double bollarFörEnMatch;
            bollarFörEnMatch = antalmatcher * 3;
            double antalförpackningar = Math.Ceiling(bollarFörEnMatch / antalbollar);
            return (int)antalförpackningar;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int bollar = int.Parse(box1.Text);
            int matcher = int.Parse(box2.Text);
            int förpackningar = FörpackningKalk(bollar, matcher);

            MessageBox.Show($"Du måste köpa {förpackningar} stycken rör med bollar");
        }

        private void VisarPoängOchSet()
        {
            lblPoängSpelareA.Content = spelareA.Poäng;
            lblPoängSpelareB.Content = spelareB.Poäng;
            lblSetSpelareA.Content = spelareA.AntalVunnaSet;
            lblSetSpelareB.Content = spelareB.AntalVunnaSet;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            lblPoängSpelareA.IsEnabled = true;
            lblPoängSpelareB.IsEnabled = true;

            spelareA = new Person(){ Förnamn = "Humle"};
            spelareB = new Person() { Förnamn = "Dumle" };
            match = new Match(spelareA, spelareB);

            VisarPoängOchSet();
        }

        private void PoängRäkning(Person spelare)
        {
            spelare.Poäng++;
            match.KollaSetSeger();
        }

        private void VisarResultat(Person spelare)
        {
            if (spelare.AntalVunnaSet == 2)
            {
                lblPoängSpelareA.IsEnabled = false;
                lblPoängSpelareB.IsEnabled = false;

                string seger = $"{spelare.Förnamn} van, grattis! \n";

                for (int i =0; i<3; i++)
                {
                    seger += $"{spelareA.SetPoäng[i]} - {spelareB.SetPoäng[i]} \n";
                }
                MessageBox.Show(seger);
            }
            
        }

        private void lblPoängSpelareA_MouseDown(object sender, MouseButtonEventArgs e)
        {
            VisarPoängOchSet();
            PoängRäkning(spelareA);
            VisarResultat(spelareA);
            
        }

        private void lblPoängSpelareB_MouseDown(object sender, MouseButtonEventArgs e)
        {
            VisarPoängOchSet();
            PoängRäkning(spelareB);
            VisarResultat(spelareB);
        }
    }
}
