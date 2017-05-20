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

        private bool _filterShowAll;
        private bool _filterShowHistory;
        private bool _filterShowOpen;
        public bool FilterShowAll { get { return _filterShowAll; } set { _filterShowAll = value; GetTournamentsFromDatabase(); RaisePropertyChangedEvent("FilterShowAll"); } }
        public bool FilterShowHistory { get { return _filterShowHistory; } set { _filterShowHistory = value; GetTournamentsFromDatabase(); RaisePropertyChangedEvent("FilterShowHistory"); } }
        public bool FilterShowOpen { get { return _filterShowOpen; } set { _filterShowOpen = value; RaisePropertyChangedEvent("FilterShowOpen"); } }

        public ShowAllTournamentsViewModel()
        {
            GetTournamentsFromDatabase();
        }
        public void GetTournamentsFromDatabase()
        {
            var context = new TMSContext();
            if(_filterShowHistory)
                _tournaments = new ObservableCollection<Tournament>((from t in context.Tournaments where t.EndDate != null select t).ToList());
            else if(_filterShowOpen)
                _tournaments = new ObservableCollection<Tournament>((from t in context.Tournaments where t.EndDate == null select t).ToList());
            else
            {
                _tournaments = new ObservableCollection<Tournament>((from t in context.Tournaments select t).ToList());
            }
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
