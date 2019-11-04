using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gammal_Tenta4
{
    class Kortlek
    {
        public List<Kort> ListaAvKort { get; set; }

        public Kort DraSlumpmässigtKort()
        {
            SkapaKortlek();

            Random random = new Random();
            int slumpIndex = random.Next(52);

            Kort kort = ListaAvKort[slumpIndex];
            return kort;
        }

        private void SkapaKortlek()
        {
            ListaAvKort = new List<Kort>();
            ListaAvKort.Clear();
            for (int i = 1; i < 5; i++) // 4 sviter
            {
                for (int j = 2; j < 15; j++) // 13 kort (totalt 52 (4x13))
                {
                    Kort kort = new Kort(); // skapa nytt kort
                                            // tilldela sviter
                    if (i == 1)
                        kort.Svit = "Spader";
                    else if (i == 2)
                        kort.Svit = "Klöver";
                    else if (i == 3)
                        kort.Svit = "Hjärter";
                    else if (i == 4)
                        kort.Svit = "Ruter";
                    // tilldela värde
                    kort.Värde = j;
                    // tilldela klädda kort
                    if (j == 14)
                        kort.Korttyp = "Ess";
                    else if (j == 13)
                        kort.Korttyp = "Kung";
                    else if (j == 12)
                        kort.Korttyp = "Dam";
                    else if (j == 11)
                        kort.Korttyp = "Knekt";
                    else if (j <= 10 && j >= 2)
                        kort.Korttyp = j.ToString();
                    //lägg in i kortleken
                    ListaAvKort.Add(kort);
                }
            }
        }

    }
}
