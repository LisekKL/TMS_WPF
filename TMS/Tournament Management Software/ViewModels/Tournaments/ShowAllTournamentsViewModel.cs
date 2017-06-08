using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight.Messaging;
using Tournament_Management_Software.Helpers;
using Tournament_Management_Software.Helpers.Context;
using Tournament_Management_Software.Helpers.Messages;
using Tournament_Management_Software.Model;

namespace Tournament_Management_Software.ViewModels.Tournaments
{
    public class ShowAllTournamentsViewModel : ObservableObject
    {
        private ObservableCollection<Tournament> _tournaments;
        public ObservableCollection<Tournament> Tournaments { get { return _tournaments; } set { _tournaments = value; RaisePropertyChangedEvent("Tournaments"); } }

        private readonly TMSContext _context = new TMSContext();

        private bool _filterShowAll = true;
        private bool _filterShowHistory;
        private bool _filterShowOpen;

        public bool FilterShowAll
        {
            get
            {
                if (_filterShowHistory && _filterShowOpen)
                    _filterShowAll = true;
                else
                    _filterShowAll = false;
                return _filterShowAll;
            }
            set
            {
                _filterShowAll = value;
                FilterTournaments();
                RaisePropertyChangedEvent("FilterShowAll");
            }
        }
        public bool FilterShowHistory
        {
            get { return _filterShowHistory; }
            set
            {
                _filterShowHistory = value;
                FilterTournaments();
                RaisePropertyChangedEvent("FilterShowHistory");
            }
        }
        public bool FilterShowOpen {
            get { return _filterShowOpen; }
            set
            {
                _filterShowOpen = value;
                FilterTournaments();
                RaisePropertyChangedEvent("FilterShowOpen");
            }
        }

        public ShowAllTournamentsViewModel()
        {
            _tournaments = new ObservableCollection<Tournament>((from t in _context.Tournaments select t).ToList());
            Messenger.Default.Send(new ChangeImagePath() {ImagePath = @"C:\Users\Karol\Desktop\TMS WPF\TMS REPO\TMS\Tournament Management Software\Images\banner11.jpg"});
            RaisePropertyChangedEvent("Tournaments");
        }
        public void FilterTournaments()
        {
            if(_filterShowHistory)
                _tournaments = new ObservableCollection<Tournament>((from t in _tournaments where t.EndDate != null select t).ToList());
            else if(_filterShowOpen)
                _tournaments = new ObservableCollection<Tournament>((from t in _tournaments where t.EndDate == null select t).ToList());
            RaisePropertyChangedEvent("Tournaments");
        }

        private Tournament _currentTournament;
        public Tournament CurrentTournament
        {
            get { return _currentTournament; }
            set
            {
                _currentTournament = value;
                if(_currentTournament != null)
                    Messenger.Default.Send(new ActiveTournamentId() { Message = _currentTournament.TournamentId });
                RaisePropertyChangedEvent("CurrentTournament");
            }
        }
    }
}
