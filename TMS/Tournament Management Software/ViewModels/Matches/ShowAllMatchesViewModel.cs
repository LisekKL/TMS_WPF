using System.Collections.ObjectModel;
using System.Linq;
using Tournament_Management_Software.Helpers;
using Tournament_Management_Software.Helpers.Context;
using Tournament_Management_Software.Model;

namespace Tournament_Management_Software.ViewModels.Matches
{
    public class ShowAllMatchesViewModel : ObservableObject
    {
        private readonly int _tournamentId;
        public ShowAllMatchesViewModel(int tournamentId)
        {
            _tournamentId = tournamentId;
        }

        public ObservableCollection<SingleMatch> Matches { get; set; }

        public void GetAllMatchesFromDatabase()
        {
            var context = new TMSContext();
            Matches = new ObservableCollection<SingleMatch>((from match in context.Matches where match.TournamentId == _tournamentId select match).ToList());
        }
    }
}
