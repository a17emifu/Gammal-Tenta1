using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gammal_Tenta1
{
    class Person
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string FullName { get; set; }
        string Destination { get; set; }
        string Date { get; set; }
        string ReservationNumber { get; set; }
        string Year { get; set; }
        bool CheckedIn { get; set; }

        string SmallOneFirstName { get; set; }
        string SmallOneLastName { get; set; }

        int UnikNumber = 0;
        int Number = 0;

        public void AddPersonInfo(string a, string b, string c, string d, string e)
        {
            FirstName = a;
            LastName = b;
            FullName = $"{a} {b}";
            Destination = c;
            Date = d;
            Year = e;
            CheckedIn = false;
            SetReservationNumber();
        }

        private void SetReservationNumber()
        {
            string smallFName = FirstName.ToLower();
            string smallLName = LastName.ToLower();
            string smallD = Destination.ToLower();
            ReservationNumber = $"{smallFName.Substring(0, 1)}{smallLName.Substring(0, 1)}{smallD}{Year}_{UnikNumber}";

            SmallOneFirstName = smallFName.Substring(0, 1);
            SmallOneLastName = smallLName.Substring(0, 1);
        }
        public void UnikNumberCalc(List<Person> a)
        {
            foreach(var person in a)
            {
                string nameDestinationAndYear = $"{person.SmallOneFirstName}{person.SmallOneLastName}{person.GetDestination().ToLower()}{person.GetYear()}";
                string resevation = $"{GetReservationNumber()}";

                if (resevation.Contains(nameDestinationAndYear) == true)
                {
                    Number++;
                }
                else
                {
                    Number = 0;
                }

            }
            UnikNumber = Number;
            SetReservationNumber();
        }

        public bool Checkin(string bookingNumber, List<Person>b)
        {
                foreach (var person in b)
                {
                    if (bookingNumber == person.GetReservationNumber())
                    {
                        person.CheckedIn = true;
                        return true;
                    }
                }
            

            return false;
            
        }
        public string GetPersonFirstName()
        {
            return FirstName;
        }
        public string GetPersonLastName()
        {
            return LastName;
        }
        public string GetDestination()
        {
            return Destination;
        }

        public string GetDate()
        {
            return Date;
        }

        public string GetReservationNumber()
        {
            return ReservationNumber;
        }

        public int GetUnikNumber()
        {
            return UnikNumber;
        }
        public string GetYear()
        {
            return Year;
        }
    }
}
