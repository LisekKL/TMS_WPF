using Tournament_Management_Software.Helpers;
using Tournament_Management_Software.Model;

namespace Tournament_Management_Software.ViewModels.Rounds.Categories.AgeClasses
{
    public class AddAgeClassViewModel : ObservableObject
    {
        private int _currentTournamentId;
        private AgeClass _ageClass;


        public AddAgeClassViewModel(int tournamentId)
        {
            _currentTournamentId = tournamentId;
        }

       public string TxtName { get { return _ageClass.AgeClassName; } set { _ageClass.AgeClassName = value; RaisePropertyChangedEvent("Name"); } }
    }
}
