using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gammal_Tenta3
{
    class Match
    {
        public int AktuelltSet;
        Person SpelareA;
        Person SpelareB;

        /*public Match(Person spelareA, Person spelareB)
        {
            SpelareA = spelareA;
            SpelareB = spelareB;
            AktuelltSet = 0;
        }*/

        public Match(Person spelareA, Person spelareB)
        {
            SpelareA = spelareA;
            SpelareB = spelareB;

            SpelareA.Poäng = 18;
            SpelareB.Poäng = 18;
            AktuelltSet = 0;
        }

        private void LagrarSet(Person spelare)
        {
            AktuelltSet++;
            spelare.AntalVunnaSet++;
        }

        private void SetSegrar()
        {
            if (SpelareA.AntalVunnaSet > SpelareB.AntalVunnaSet)
            {
                SpelareA.Segrare = true;
            }

            if (SpelareA.AntalVunnaSet < SpelareB.AntalVunnaSet)
            {
                SpelareB.Segrare = true;
            }
        }
        private void SetPoäng()
        {
            SpelareA.SetPoäng[AktuelltSet-1] = SpelareA.Poäng;
            SpelareB.SetPoäng[AktuelltSet-1] = SpelareB.Poäng;
        }
        private void Resetpoäng()
        {
            SpelareA.Poäng = 0;
            SpelareB.Poäng = 0;
        }
      public void KollaSetSeger()
        {
            int skilnad = Math.Abs(SpelareA.Poäng - SpelareB.Poäng);

            if ((SpelareA.Poäng >= 21) && (skilnad >= 2))
            {
                LagrarSet(SpelareA);
                SetPoäng();
                Resetpoäng();
            }
            if ((SpelareB.Poäng >= 21) && (skilnad >= 2))
            {
                LagrarSet(SpelareB);
                SetPoäng();
                Resetpoäng();
            }
            if ((SpelareA.AntalVunnaSet == 2) || (SpelareB.AntalVunnaSet == 2))
            {
                SetSegrar();
            }
        }
    }
}
