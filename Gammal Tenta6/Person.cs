using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gammal_Tenta6
{
    class Person
    {
        public List<Clothes> CollectionFriday { get; set; }
        public List<Clothes> CollectionSaturday { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public Person()
        {
            CollectionFriday = new List<Clothes>();
            CollectionSaturday = new List<Clothes>();
        }
    }
}
