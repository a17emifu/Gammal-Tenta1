using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gammal_Tenta3
{
    class Person
    {
        public string Förnamn{ get; set; }
        public int Poäng { get; set; }
        public int AntalVunnaSet { get; set; }
        public int[] SetPoäng { get; set; }
        public bool Segrare { get; set; }

        public Person()
        {
            Segrare = false;
            SetPoäng = new int[3];
            AntalVunnaSet = 0;
        }
    }
}
