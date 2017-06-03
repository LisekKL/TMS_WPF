using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tournament_Management_Software.Helpers;
using Tournament_Management_Software.Helpers.Context;
using Tournament_Management_Software.Model;

namespace Tournament_Management_Software.ViewModels.AgeClasses.WeightClasses
{
    public class ShowAllWeightClassesViewModel : ObservableObject
    {
        private readonly TMSContext _context = new TMSContext();

        public ShowAllWeightClassesViewModel(int ageClassId)
        {
           GetWeightClassesFromDatabase(ageClassId);
        }
        
        public ObservableCollection<WeightClass> WeightClasses { get; set; }
        public int MaxWeightFilter { get; set; }
        public int MinWeightFilter { get; set; }

        public void GetWeightClassesFromDatabase(int ageClassId)
        {
            var query = (from w in _context.WeightClasses where w.AgeClassId == ageClassId select w).ToList();
            WeightClasses = new ObservableCollection<WeightClass>(query);
            RaisePropertyChangedEvent("WeightClasses");
        }
    }
}
