using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using Tournament_Management_Software.Helpers.Context;
using Tournament_Management_Software.Model;

namespace Tournament_Management_Software.ViewModels
{
    public class AllContestantsViewModel : ObservableObject
    {
        public ObservableCollection<Contestant> Contestants { get; set; }

        public AllContestantsViewModel()
        {
            var context = new TMSContext();
            Contestants = new ObservableCollection<Contestant>(context.Contestants);
            RaisePropertyChangedEvent("Contestants");
        }
    }
}

