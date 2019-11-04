using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAI___Gammal_Tenta2
{
    class Tävlare
    {
        public string Förnamn { get; private set; }
        public string Efternamn { get; private set; }
        public int StartNummber { get; private set; }
        //public int SkjutResultat { get; private set; }

        public string Land { get; private set; }
        public List<Skytte> SkyttesResultat { get; private set; }

        public Tävlare(string förnamn, string efternamn, string land)
        {
            Förnamn = förnamn;
            Efternamn = efternamn;
            Land = land;
            SkyttesResultat = new List<Skytte>();
        }

        public void skapaStartnummber(int nummer)
        {
            StartNummber = nummer;
        }
        public void registreraSkjutresultat(Skytte skytte)
        {
            SkyttesResultat.Add(skytte);
        }
    }
}
