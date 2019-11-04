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


namespace Gammal_Tenta2
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Skier> skiers = new List<Skier>();

        string forGoal1;
        string forGoal2;
        string forGoal3;
        string forGoal4;
        string forGoal5;

        string skiType;

        bool finished = false;

        int numberCounter = 0;
        int penaltyRounds = 0;

        public MainWindow()
        {
            InitializeComponent();
            NotButton();

        }
        private void NotButton()
        {
            rbtnStand.IsEnabled = false;
            rbtnLaying.IsEnabled = false;
            btnOK.IsEnabled = false;
        }
        private void PenaltyCounter()
        {
            if (goal1.IsChecked == false) { penaltyRounds++; forGoal1 = "Missade"; } else { forGoal1 = "Träffade"; }
            if (goal2.IsChecked == false) { penaltyRounds++; forGoal2 = "Missade"; } else { forGoal2 = "Träffade"; }
            if (goal3.IsChecked == false) { penaltyRounds++; forGoal3 = "Missade"; } else { forGoal3 = "Träffade"; }
            if (goal4.IsChecked == false) { penaltyRounds++; forGoal4 = "Missade"; } else { forGoal4 = "Träffade"; }
            if (goal5.IsChecked == false) { penaltyRounds++; forGoal5 = "Missade"; } else { forGoal5 = "Träffade"; }
        }
        private void SetresultDetaijl()
        {
            foreach (var person in skiers)
            {
                if (listbox1.SelectedItem.Equals($"{person.GetStartNumber()}: {person.GetSkiersNamn()}, {person.GetCountry()}"))
                {
                    Ski ski = new Ski();
                    ski.AddResult(forGoal1, forGoal2, forGoal3, forGoal4, forGoal5);
                    ski.AddPenaltyRounds(penaltyRounds);
                    ski.AddTypeForSki(skiType);
                    person.AddSkiResults(ski);

                    listbox2.Items.Clear();
                    listbox3.Items.Clear();

                    foreach (var result in person.skis)
                    {
                        listbox2.Items.Add($"{result.GetNumberOfPelaltyRounds()}, {result.GetTypeForSki()}");
                        string[] resultArray = result.GetResult();
                        for (int i = 0; i <= 4; i++)
                        {

                            listbox3.Items.Add($"Round{i+1}: {resultArray[i]}");
                        }
                        listbox3.Items.Add("");
                        

                    }


                }

            }
        }


        private void ButtonCheck()
        {
            if (rbtnStand.IsChecked == true)
            {
                foreach (var person in skiers)
                {
                    if (listbox1.SelectedItem.Equals($"{person.GetStartNumber()}: {person.GetSkiersNamn()}, {person.GetCountry()}"))
                    {
                        foreach (var result in person.skis)
                        {
                            result.AddStanding();
                        }
                    }
                }
            }
            if (rbtnLaying.IsChecked == true)
            {
                foreach (var person in skiers)
                {
                    if (listbox1.SelectedItem.Equals($"{person.GetStartNumber()}: {person.GetSkiersNamn()}, {person.GetCountry()}"))
                    {
                        foreach (var result in person.skis)
                        {
                            result.AddLaying();
                        }
                    }
                }
            }
        }

        private void RoundCheck()
        {
            foreach (var person in skiers)
            {
                if (listbox1.SelectedItem.Equals($"{person.GetStartNumber()}: {person.GetSkiersNamn()}, {person.GetCountry()}"))
                {
                    foreach (var result in person.skis)
                    {
                        if (result.GetStanding() == 2)
                        {
                            rbtnStand.IsEnabled = false;
                            rbtnLaying.IsChecked = true;
                        }
                        if (result.GetLaying() == 2)
                        {
                            rbtnLaying.IsEnabled = false;
                            rbtnStand.IsChecked = true;
                        }
                        if ((result.GetStanding() == 2) && (result.GetLaying() == 2))
                        {
                            MessageBox.Show("Alla fyra skjukningar har klarats.");
                            btnOK.IsEnabled = false;

                                    person.AddFinishcedOrNot();
                                    finished = person.GetFinishedOrNot();

                        }
                    }
                }
            }
        }

        private void ButtonsReset()
        {
            rbtnStand.IsEnabled = true;
            rbtnLaying.IsEnabled = true;
            btnOK.IsEnabled = true;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string fName, lName, country;
            fName = boxFNamn.Text;
            lName = boxLNamn.Text;
            country = boxCountry.Text;

            
            numberCounter++; // räknare för startnummer

            Skier skier = new Skier();
            skier.AddSkierInfo(fName, lName, numberCounter,country);
            skiers.Add(skier);

            listbox1.Items.Clear();
            foreach (var person in skiers)
            {
                listbox1.Items.Add($"{person.GetSkiersNamn()}, {person.GetCountry()}");
            }
            listbox1.IsEnabled = false;
                
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            listbox1.IsEnabled = true;
            listbox1.Items.Clear();
            ButtonsReset();
            foreach (var person in skiers)
            {
                listbox1.Items.Add($"{person.GetStartNumber()}: {person.GetSkiersNamn()}, {person.GetCountry()}");
            }
            rbtnStand.IsChecked = true;
        }

        private void listbox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listbox2.Items.Clear();
            listbox3.Items.Clear();

            foreach (var person in skiers)
            {
                if (listbox1.SelectedItem.Equals($"{person.GetStartNumber()}: {person.GetSkiersNamn()}, {person.GetCountry()}") && (listbox1.SelectedIndex >= 0))
                {
                    if (person.GetFinishedOrNot() == true)
                    {
                        NotButton();
                    }
                    else
                    {
                        ButtonsReset();
                    }
                }
            }
        }

        private void goal1_Click(object sender, RoutedEventArgs e)
        {
            listbox3.Items.Clear();
            btnAdd.IsEnabled = false;
            btnNum.IsEnabled = false;

            if (rbtnStand.IsChecked== true)
            {
                skiType = "Stående";
            }
            if (rbtnLaying.IsChecked == true)
            {
                skiType = "Liggande";
            }

            PenaltyCounter();

            if (penaltyRounds == 0)
            {
                MessageBox.Show("Åkaren fick ingen sraffrunda");
            }
            else if (penaltyRounds == 1)
            {
                MessageBox.Show($"Åkaren fick: {penaltyRounds} sraffrunda");
            }
            else if (penaltyRounds >=2)
            {
                MessageBox.Show($"Åkaren fick: {penaltyRounds} sraffrundor");
            }

            SetresultDetaijl();
            ButtonCheck();

            RoundCheck();
            penaltyRounds = 0;
            
        }


        
    }
}
