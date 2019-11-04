using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAI___Gammal_Tenta1
{
    class Person
    {
        public string FörNamn { get; private set; }
        public string EfterNamn { get; private set; }
        public string Resmål { get; private set; }
        public DateTime Datum { get; private set; }

        public string BokningsNummer { get; private set; }
        public bool CheckatIn { get; private set; }

        public Person(string förnamn, string efternamn, string resmål, DateTime datum)
        {
            FörNamn = förnamn;
            EfterNamn = efternamn;
            Resmål = resmål;
            Datum = datum;
            CheckatIn = false;
        }

        public string GetBokningsNummer(string år, List<Person> kundlist)
        {
            BokningsNummer = $"{FörNamn.Substring(0, 1).ToLower()}{EfterNamn.Substring(0, 1).ToLower()}{Resmål.ToLower()}{år}";
            SökKund(kundlist, år);
            return BokningsNummer;
        } 

        private void SökKund(List<Person> kundlist, string år)
        {
            int i = 0;

            foreach (var kund in kundlist)
            {
                if (kund.BokningsNummer.Contains(BokningsNummer))
                {
                    i++;
                    BokningsNummer = $"{FörNamn.Substring(0, 1).ToLower()}{EfterNamn.Substring(0, 1).ToLower()}{Resmål.ToLower()}{år}_{i}";
                }
            }
        }

        public void CheckIn()
        {
            CheckatIn = true;
        }
    }
}
