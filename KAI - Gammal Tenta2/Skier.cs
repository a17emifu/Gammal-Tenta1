using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gammal_Tenta2
{
    class Skier
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string FullName { get; set; }
        int StartNumber { get; set; }
        string Country { get; set; }

        bool FinishedOrNot { get; set; }

        public List<Ski> skis { get; private set; }

        public Skier()
        {
            skis = new List<Ski>();
            FinishedOrNot = false;
        }

        public void AddSkierInfo(string fName, string lName, int number, string country)
        {
            FirstName = fName;
            LastName = lName;
            FullName = $"{FirstName} {LastName}";
            StartNumber = number;
            Country = country;
        }
 
        public void AddFinishcedOrNot()
        {
            FinishedOrNot = true;
        }
        public void AddSkiResults(Ski ski)
        {
            skis.Add(ski);
        }

        public string GetSkiersNamn()
        {
            return FullName;
        }

        public int GetStartNumber()
        {
            return StartNumber;
        }

        public string GetCountry()
        {
            return Country;
        }

        public bool GetFinishedOrNot()
        {
            return FinishedOrNot;
        }

    }
}
