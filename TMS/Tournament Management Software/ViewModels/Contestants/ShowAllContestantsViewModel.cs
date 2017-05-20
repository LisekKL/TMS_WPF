using System.Collections.ObjectModel;
using System.Linq;
using Tournament_Management_Software.Helpers;
using Tournament_Management_Software.Helpers.Context;
using Tournament_Management_Software.Model;

namespace Tournament_Management_Software.ViewModels.Contestants
{
    public class ShowAllContestantsViewModel : ObservableObject
    {
        private ObservableCollection<Contestant> _contestants;
        public ObservableCollection<Contestant> Contestants { get { return _contestants; } set { _contestants = value; RaisePropertyChangedEvent("Contestants"); } }

        public ShowAllContestantsViewModel(int tournamentId)
        {
            var context = new TMSContext();
            var queryContestantsInTournament = (from c in context.Contestants
                where c.TournamentId == tournamentId
                select c).ToList();
            Contestants = new ObservableCollection<Contestant>(queryContestantsInTournament);
            RaisePropertyChangedEvent("Contestants");
        }

        public ShowAllContestantsViewModel()
        {
            //throw new System.NotImplementedException();
        }
    }
}

