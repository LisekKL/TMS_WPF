using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;
using Tournament_Management_Software.Helpers;
using Tournament_Management_Software.Model;


namespace Tournament_Management_Software.ViewModels
{
    public class MainWindowViewModel : ObservableObject
    {
        public ObservableCollection<MenuItem> NavigationMenu { get; set; } = new ObservableCollection<MenuItem>();
        public ObservableCollection<string> ToolbarMenu { get; set; } = new ObservableCollection<string>();
        public Visibility TournamentOptionsVisibility { get; set;} = Visibility.Collapsed;

        public string OutputMessage { get; set; }

        private object _currentView;
        public object CurrentView { get { return _currentView; }  set { _currentView = value; RaisePropertyChangedEvent("CurrentView"); } }

        public MainWindowViewModel()
        {
            Messenger.Default.Register<ActiveTournamentId>(this, SetTournamentOptionsOnMessageReceived);
            CurrentView = new DefaultViewModel();         
        }

        public string Title { get; set; } = "Tournament Management Software";

        public int CurrentTournamentId { get; set; }

        public void SetTournamentOptionsOnMessageReceived(ActiveTournamentId action)
        {
            CurrentTournamentId = action.TournamentId;
            TournamentOptionsVisibility = Visibility.Visible;
            RaisePropertyChangedEvent("TournamentOptionsVisibility");
            RaisePropertyChangedEvent("CurrentTournamentId");
        }

        public ICommand ShowHomeViewCommand => new DelegateCommand(SetHomeView);
        public ICommand ShowAddContestantViewCommand => new DelegateCommand(SetAddContestantView);
        public ICommand ShowAllContestantsCommand => new DelegateCommand(SetAllContestantsView);
        //In development
        //public ICommand ShowAllDatabaseDataCommand => new DelegateCommand(SetExploreDatabase);
        public ICommand ShowAddNewTournamentCommand => new DelegateCommand(AddNewTournament);
        public ICommand ShowAllTournamentsCommand => new DelegateCommand(ShowAllTournaments);

        public void ShowAllTournaments()
        {
            _currentView = new ShowAllTournamentsViewModel();
            RaisePropertyChangedEvent("CurrentView");
        }
        public void AddNewTournament()
        {
            _currentView = new AddTournamentViewModel();
            RaisePropertyChangedEvent("CurrentView");
        }
        public void SetExploreDatabase()
        {
            _currentView = new ExploreDatabaseViewModel();
            RaisePropertyChangedEvent("CurrentView");
        }     
        public void SetHomeView()
        {
            _currentView = new DefaultViewModel();
            RaisePropertyChangedEvent("CurrentView");
        }
        public void SetAddContestantView()
        {

            if (CurrentTournamentId == 0)
            {
                OutputMessage = "NO TOURNAMENT SELECTED!\nSelect an existing tournament or add a new one";
                RaisePropertyChangedEvent("OutputMessage");
            }
            else
                CurrentView = new AddContestantViewModel(CurrentTournamentId);
            RaisePropertyChangedEvent("CurrentView");
        }
        public void SetAllContestantsView()
        {
            _currentView = new ShowAllContestantsViewModel(CurrentTournamentId);
            RaisePropertyChangedEvent("CurrentView");
        }
    }
}
