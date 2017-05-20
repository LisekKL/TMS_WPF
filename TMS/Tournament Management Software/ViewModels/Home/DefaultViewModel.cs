using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;
using Tournament_Management_Software.Helpers;
using Tournament_Management_Software.Helpers.Messages;
using Tournament_Management_Software.ViewModels.Tournaments;

namespace Tournament_Management_Software.ViewModels.Home
{
    public class DefaultViewModel : ObservableObject
    {
        public ObservableCollection<ButtonItem> ListView { get; set; } = new ObservableCollection<ButtonItem>();
        public string ListViewTitle { get; set; } = "Tournaments";
        public string ViewTitle { get; set; } = "SHOWING TOURNAMENTS";

        private int _currentTournamentId;
        public int CurrentTournamentId { get { return _currentTournamentId; } set { _currentTournamentId = value; RaisePropertyChangedEvent("CurrentTournamentId"); } }
        public DefaultViewModel()
        {
            Messenger.Default.Register<ActiveTournamentId>(this, SetCurrentTournamentId);
            InitiateListView();
            _currentView = new ShowAllTournamentsViewModel();
          //  RaisePropertyChangedEvent("CurrentView");
        }

        public ICommand ShowAllTournamentsCommand => new DelegateCommand(ShowAllTournaments);
        public ICommand AddNewTournamentCommand => new DelegateCommand(AddNewTournament);
        public ICommand GoToCurrentTournamentCommand => new DelegateCommand(GoToCurrentTournament);

        public void SetCurrentTournamentId(ActiveTournamentId action)
        {
            CurrentTournamentId = action.Message;
            RaisePropertyChangedEvent("CurrentTournamentId");
        }
        public void ShowAllTournaments()
        {
            CurrentView = new ShowAllTournamentsViewModel();
            Messenger.Default.Send(new ChangeView() {Message = _currentView});
            RaisePropertyChangedEvent("CurrentView");
        }
        public void AddNewTournament()
        {
            CurrentView = new AddTournamentViewModel();
            RaisePropertyChangedEvent("CurrentView");
        }
        public void GoToCurrentTournament()
        {
            if (_currentTournamentId > 0)
                CurrentView = new CurrentTournamentViewModel(_currentTournamentId);
            else
            {
                MessageBox.Show("Nie wybrano turnieju lub turniej nie poprawny!");
            }
            RaisePropertyChangedEvent("CurrentView");
        }

        public void InitiateListView()
        {
            ListView.Add(new ButtonItem() {Label = "All Tournaments", Command = ShowAllTournamentsCommand});
            ListView.Add(new ButtonItem() {Label = "Add new tournament", Command = AddNewTournamentCommand});
            ListView.Add(new ButtonItem() {Label = "Current Tournament", Command = GoToCurrentTournamentCommand});
            RaisePropertyChangedEvent("ListView");
            Messenger.Default.Send(new ChangeListView() {Message = ListView});
        }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                RaisePropertyChangedEvent("CurrentView");
            }
        }
    }
}
