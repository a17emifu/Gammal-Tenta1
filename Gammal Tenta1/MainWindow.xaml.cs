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

namespace Gammal_Tenta1
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Person> personlist = new List<Person>();
        int extraCharge,bagWeight;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TotalBagWeight(int bags, int weight)
        {
            if (bags <= 3)
            {
                BagWeightCheck(weight);
            }
            else
            {
                MessageBox.Show("Du kan ta med max 3 resväskor!");
            }
        }

        private void BagWeightCheck(int weight)
        {
            if (weight<= 40)
            {
                extraCharge = 0;
                MessageBox.Show($"Bagaget väger {bagWeight}kg och priset för att checka in bagaget är {extraCharge}kr.");
            }
            else
            {
                extraCharge = 400;
                MessageBox.Show($"Bagaget väger {bagWeight}kg och priset för att checka in bagaget är {extraCharge}kr.");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string firstname, lastname, destination, date, dateForID;
            firstname = boxFname.Text;
            lastname = boxLname.Text;
            destination = boxDestination.Text;
            date = pickerDate.DisplayDate.ToString("yyyy-MM-dd");
            dateForID = pickerDate.DisplayDate.ToString("yyyy");

            if ((firstname == "")|| (lastname == "") || (destination == "") || (date == ""))
            {
                MessageBox.Show("Mata in!");
            }
            else
            {
                Person person = new Person();
                person.AddPersonInfo(firstname, lastname, destination, date, dateForID);
                personlist.Add(person);

                person.UnikNumberCalc(personlist);

                MessageBox.Show($"Ditt bokningsnummer är: {person.GetReservationNumber()}");
            }

            listbox1.Items.Clear();
            foreach (var person in personlist)
            {
                listbox1.Items.Add($"{person.GetPersonLastName()} {person.GetReservationNumber()}");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string lastname = checkInLnamn.Text;
            string bookingNumber = checkInBookingNumber.Text;
            bool check = false;

            foreach (var customers in personlist)
            {
                if (lastname == customers.GetPersonLastName())
                {
                    check = customers.Checkin(bookingNumber,personlist);
                }
            } 

            if (check == true)
            {
                MessageBox.Show("Du har checkat in!");
            }
            else if (check == false)
            {
                MessageBox.Show("Vi kan inte hitta din bokning i systemet.");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int bagAmount = int.Parse(boxBagAmount.Text);
            bagWeight = int.Parse(boxBagWeight.Text);

            TotalBagWeight(bagAmount,bagWeight);
            
        }
    }
}
