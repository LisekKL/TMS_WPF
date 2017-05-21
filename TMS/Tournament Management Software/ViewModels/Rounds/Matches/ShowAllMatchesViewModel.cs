using System.Collections.ObjectModel;
using System.Linq;
using Tournament_Management_Software.Helpers;
using Tournament_Management_Software.Helpers.Context;
using Tournament_Management_Software.Model;

namespace Tournament_Management_Software.ViewModels.Rounds.Matches
{
    public class ShowAllMatchesViewModel : ObservableObject
    {
        private readonly int _roundId;
        public ShowAllMatchesViewModel(int roundId)
        {
            _roundId = roundId;
        }

        public ObservableCollection<SingleMatch> Matches { get; set; }

        public void GetAllMatchesFromDatabase()
        {
            var context = new TMSContext();
            Matches = new ObservableCollection<SingleMatch>((from match in context.Matches where match.RoundId == _roundId select match).ToList());
        }
    }
}
