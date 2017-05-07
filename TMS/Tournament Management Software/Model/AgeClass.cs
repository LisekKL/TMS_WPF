using System;
using System.Collections.ObjectModel;

namespace Tournament_Management_Software.Model
{
    public class AgeClass
    {
        private static int _counter;

        public AgeClass()
        {
            ++_counter;
            AgeClassId = _counter;
        }
        public int AgeClassId { get; set; }
        public string AgeClassName { get; set; }
        public int MinYear { get; set; }
        public int MaxYear { get; set; }
        public bool IsNoGenderDifference { get; set; } = false;

        public virtual ObservableCollection<WeightClass> WeightClasses { get; set; }
        public virtual ObservableCollection<Round> Rounds { get; set; }
    }
}
