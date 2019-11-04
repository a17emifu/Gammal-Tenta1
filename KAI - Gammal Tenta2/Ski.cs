using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gammal_Tenta2
{
    class Ski
    {
        string[] Result { get; set; }
        int NumberOfPenaltyRounds { get; set; }
        string TypeForSki { get; set; }

        int Standing = 0;
        int Laying = 0;

        public Ski()
        {
            Result = new string[5];
        }

        public void AddResult(string goal1, string goal2, string goal3, string goal4, string goal5)
        {
            Result[0] = goal1;
            Result[1] = goal2;
            Result[2] = goal3;
            Result[3] = goal4;
            Result[4] = goal5;

        }
        public void AddPenaltyRounds (int numberOfPenaltyRounds)
        {
            NumberOfPenaltyRounds = numberOfPenaltyRounds;
        }
        public void AddTypeForSki(string skiType)
        {
            TypeForSki = skiType;
        }
        public void AddStanding()
        {
            Standing++;
        }
        public void AddLaying()
        {
            Laying++;
        }
        public int GetStanding()
        {
            return Standing;
        }
        public int GetLaying()
        {
            return Laying;
        }
        public string[] GetResult()
        {
            return Result;
        }
        public int GetNumberOfPelaltyRounds()
        {
            return NumberOfPenaltyRounds;
        }
        public string GetTypeForSki()
        {
            return TypeForSki;
        }


    }
}
