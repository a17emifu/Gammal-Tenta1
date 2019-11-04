using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gammal_Tanta5
{
    class Tävlande
    {
        public int[] Bonussekunder { get; set; }
        public string Land { get; set; }
        public string Namn { get; set; }

        public Tävlande()
        {
            Bonussekunder = new int[5];
        }
    }
}
