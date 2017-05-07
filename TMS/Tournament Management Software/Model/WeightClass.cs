using System;

namespace Tournament_Management_Software.Model
{
    public class WeightClass
    {
        private static int _counter;

        public WeightClass()
        {
            ++_counter;
            WeightClassId = _counter;
        }
        public int WeightClassId { get; set; }
        public string WeightClassName { get; set; }
        public double MinWeight { get; set; } = 0;
        public double MaxWeight { get; set; } = Double.MaxValue;

        public int AgeClassId { get; set; }
        public virtual AgeClass AgeClass { get; set; }
    }
}
