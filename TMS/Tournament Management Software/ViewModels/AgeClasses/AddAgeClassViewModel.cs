using Tournament_Management_Software.Helpers;
using Tournament_Management_Software.Model;

namespace Tournament_Management_Software.ViewModels.AgeClasses
{
    public class AddAgeClassViewModel : ObservableObject
    {
        private readonly AgeClass _ageClass;

        public AddAgeClassViewModel(int tournamentId)
        {
            _ageClass = new AgeClass() {TournamentId = tournamentId};
        }

        public string TxtName
        {
            get { return _ageClass.AgeClassName; }
            set
            {
                _ageClass.AgeClassName = value;
                RaisePropertyChangedEvent("TxtName");
            }
        }

        public int MaxYear
        {
            get { return _ageClass.MaxYear; }
            set
            {
                _ageClass.MaxYear = value;
                RaisePropertyChangedEvent("MaxYear");
            }
        }

        public int MinYear
        {
            get { return _ageClass.MinYear; }
            set
            {
                _ageClass.MinYear = value;
                RaisePropertyChangedEvent("MinYear");
            }
        }

        public int TournamentId => _ageClass.TournamentId;
    }
}
