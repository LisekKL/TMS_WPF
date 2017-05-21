using System;
using System.Collections.ObjectModel;

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

        public virtual ObservableCollection<WeightClass> WeightClasses { get; set; }
        public virtual ObservableCollection<Round> Rounds { get; set; }
    }
}
