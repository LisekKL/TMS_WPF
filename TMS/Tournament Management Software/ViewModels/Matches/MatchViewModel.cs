using Tournament_Management_Software.Helpers;

namespace Tournament_Management_Software.ViewModels.Matches
{
    public class MatchViewModel : ObservableObject
    {
        private int _tournamentId;
        public MatchViewModel(int tournamentId)
        {
            _tournamentId = tournamentId;
        }

        private object _currentView;
        public object CurrentView { get { return _currentView; } set { _currentView = value; RaisePropertyChangedEvent("CurrentView"); } }

        public string ViewTitle { get; set; } = "MATCH VIEW";
    }
}
