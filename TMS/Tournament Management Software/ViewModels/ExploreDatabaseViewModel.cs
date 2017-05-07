using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tournament_Management_Software.Helpers.Context;
using Tournament_Management_Software.Model;

namespace Tournament_Management_Software.ViewModels
{
    public class ExploreDatabaseViewModel : ObservableObject
    {
        public ObservableCollection<WeightClass> WeightClasses { get; set; }
        public ObservableCollection<AgeClass> AgeClasses { get; set; }
        public ObservableCollection<Contestant> Contestants { get; set; }

        //TODO: Implement Tournament Info section (Rounds, Matches, ...)
        public string TournamentInfo { get; set; } = "Coming soon....";

        public ExploreDatabaseViewModel()
        {
            var context = new TMSContext();
            WeightClasses = new ObservableCollection<WeightClass>(context.WeightClasses);
            RaisePropertyChangedEvent("WeightClasses");
            AgeClasses = new ObservableCollection<AgeClass>(context.AgeClasses);
            RaisePropertyChangedEvent("AgeClasses");
            Contestants = new ObservableCollection<Contestant>(context.Contestants);
            RaisePropertyChangedEvent("Contestants");
        }

    }
}
