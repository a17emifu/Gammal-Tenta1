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

namespace Gammal_Tenta6
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        int[] washTemp = new int[]{30, 30, 60, 60, 40, 40, 60 };
        int korg30 = 0;
        int korg40 = 0;
        int korg60 = 0;
        int[] korgArray;

        Person person;


        private Person SkapaObjekt()
        {
            Person personen = new Person() { Firstname = "Test", Lastname = "Johansson"};
            Clothes clothesFredag;
            Clothes clothesLördag;

            clothesFredag = new Clothes() { Type = "Jeans", Color="Rosa", Characteristics ="A", WashTemperture = 60 };
            personen.CollectionFriday.Add(clothesFredag);

            clothesFredag = new Clothes() { Type = "T-shirt", Color = "Svart", Characteristics = "B", WashTemperture = 40 };
            personen.CollectionFriday.Add(clothesFredag);

            clothesLördag = new Clothes() { Type = "Skorta", Color = "Vit", Characteristics = "C", WashTemperture = 60 };
            personen.CollectionSaturday.Add(clothesLördag);

            clothesLördag = new Clothes() { Type = "Kavaj", Color = "Röd", Characteristics = "D", WashTemperture = 30 };
            personen.CollectionSaturday.Add(clothesLördag);

            clothesLördag = new Clothes() { Type = "Slips", Color = "Blå", Characteristics = "E", WashTemperture = 60 };
            personen.CollectionSaturday.Add(clothesLördag);

            return personen;
        }

        public MainWindow()
        {
            InitializeComponent();
            person = SkapaObjekt();
        }

        private int KorgenCheck()
        {
            int korgenFörFlestPlagg;
            for (int i =0; i<washTemp.Length; i++)
            {
                if (washTemp[i] == 30) { korg30++; }
                else if (washTemp[i] == 40) { korg40++; }
                else if (washTemp[i] == 60) { korg60++; }
            }
            korgArray  = new int[] { korg30, korg40, korg60 };
            korgenFörFlestPlagg = GerKorgenGrader(korgArray.Max());   // .Max: [https://www.urablog.xyz/entry/2018/06/14/070000]

            return korgenFörFlestPlagg;
        }
         private int GerKorgenGrader(int antaletPlagg)
        {
            int grader =0;
            if (antaletPlagg == korg30)
            {
                grader = 30;
            }
            else if (antaletPlagg == korg40)
            {
                grader = 40;
            }
            else if (antaletPlagg == korg60)
            {
                grader = 60;
            }
            return grader;
        }

        private int TemperaturCheck(string önskadeTeperaturen)
        {
            int temperatur = 0;

            if (önskadeTeperaturen == "Lögst")
            {
                temperatur = LögstaTemperatur();
            }
            else if (önskadeTeperaturen == "Högst")
            {
                temperatur = HögstaTemperatur();
            }

            return temperatur;
        }
        private int LögstaTemperatur()
        {
            int lägstaTemperaturen = washTemp[0];

            for (int i = 0; i < washTemp.Length; i++)
            {
                if (lägstaTemperaturen > washTemp[i])
                {
                    lägstaTemperaturen = washTemp[i];
                }
            }
            return lägstaTemperaturen;
        }

        private int HögstaTemperatur()
        {
            int högstaTemperaturen = washTemp[0];

            for (int i = 0; i < washTemp.Length; i++)
            {
                if (högstaTemperaturen < washTemp[i])
                {
                    högstaTemperaturen = washTemp[i];
                }
            }
            return högstaTemperaturen;
        }

        private void VisaKläderFörFredag()
        {
            listbox1.Items.Clear();
            foreach(var kläder in person.CollectionFriday)
            {
                listbox1.Items.Add($"{kläder.Type} {kläder.Color}");
            }
        }
        private void VisaKläderFörLördag()
        {
            listbox1.Items.Clear();
            foreach (var kläder in person.CollectionSaturday)
            {
                listbox1.Items.Add($"{kläder.Type} {kläder.Color}");
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            VisaKläderFörFredag();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            VisaKläderFörLördag();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int temperatur = TemperaturCheck("Lögst");

            boxResultat.Text = $"Lögsta temperturen är: {temperatur} grader.";
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            int temperatur = TemperaturCheck("Högst");
            boxResultat.Text = $"Lögsta temperturen är: {temperatur} grader.";
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            int korg = KorgenCheck();
            boxResultat.Text = $"Största tvättkorgen är: för {korg} grader.";

        }
    }
}
