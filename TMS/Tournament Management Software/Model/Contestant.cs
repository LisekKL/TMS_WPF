using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using Tournament_Management_Software.Helpers.Context;
using Tournament_Management_Software.Helpers.Enums;

namespace Tournament_Management_Software.Model
{
    public class Contestant : Person
    {
       // private static int _counter;

        public Contestant()
        {
            //ContestantId = ++_counter;
        }
        public int ContestantId { get; set; }

        public string GetContestantDataString()
        {
            return "CONTESTANT WITH ID " + ContestantId + ":" + FirstName + " " +
                   LastName + ", Age " + GetAge() + ", Weight " +
                   Weight + ", Height " + Height;
        }
        public int WeightClass { get; set; }

        public int TournamentId { get; set; }
        public virtual Tournament Tournament { get; set; }
    }
}
