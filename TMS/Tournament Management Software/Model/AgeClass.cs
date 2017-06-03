using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Tournament_Management_Software.Model
{
    public class AgeClass 
    {
        private static int _counter;

        public AgeClass()
        {          
            AgeClassId = ++_counter;
        }
        public int AgeClassId { get; set; }
        public string AgeClassName { get; set; }
        public int MinYear { get; set; }
        public int MaxYear { get; set; } = DateTime.Now.Year;
        public bool IsGenderDistinguishable { get; set; } = true;

        public int TournamentId { get; set; }
        public virtual Tournament Tournament { get; set; }

        public virtual ObservableCollection<WeightClass> WeightClasses { get; set; }
        //public virtual ObservableCollection<Round> Rounds { get; set; }
    }
}
