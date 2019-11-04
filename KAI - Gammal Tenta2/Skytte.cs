using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAI___Gammal_Tenta2
{
    class Skytte
    {
        public int[] Resultat {get; private set; }
        public int antalStraffrundor { get; private set; }
        public string typAvSkytte { get; private set; }

        public Skytte(string typ)
        {
            Resultat = new int[4];
            antalStraffrundor = 0;
            typAvSkytte = typ;
        }
        public void ResultatCalc(int antalstraffrundor,int[] resultat)
        {
            Resultat = resultat;
            antalStraffrundor = antalstraffrundor;
        }

    }
}
