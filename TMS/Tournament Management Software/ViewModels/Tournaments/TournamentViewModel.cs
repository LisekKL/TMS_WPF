using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;
using Tournament_Management_Software.Helpers;
using Tournament_Management_Software.Helpers.Messages;

namespace Tournament_Management_Software.ViewModels.Tournaments
{
    public class TournamentViewModel : ObservableObject
    {
        public string ViewTitle { get; set; } = "Tournament View";
        public string ImagePath => @"C:\Users\Karol\Desktop\TMS WPF\TMS REPO\TMS\Tournament Management Software\Images\tournament banner.png";

        private object _currentView;
        public object CurrentView { get { return _currentView; } set { _currentView = value; RaisePropertyChangedEvent("CurrentView"); } }

        private int _currentTournamentId;
        public int CurrentTournamentId { get { return _currentTournamentId; } set { _currentTournamentId = value; RaisePropertyChangedEvent("CurrentTournamentId"); } }

        public TournamentViewModel()
        {
            Messenger.Default.Register<ActiveTournamentId>(this, SetTournamentId);
            InitiateListView();
        }

        public void SetTournamentId(ActiveTournamentId action)
        {
            _currentTournamentId = action.Message;
            RaisePropertyChangedEvent("CurrentTournamentId");
        }

        public ObservableCollection<ButtonItem> ListView { get; set; }
        public void InitiateListView()
        {
            ListView = new ObservableCollection<ButtonItem>()
            {
                new ButtonItem() {Label = "Home", Command = GoHomeCommand},
                new ButtonItem() {Label = "All Tournaments", Command = ShowAllTournamentsCommand},
                new ButtonItem() {Label = "Add new tournament", Command = AddNewTournamentCommand},
                new ButtonItem() {Label = "Current Tournament", Command = GoToCurrentTournamentCommand}, 
                new ButtonItem() {Label = "Exit", Command = ExitCommand}
            };
            RaisePropertyChangedEvent("ListView");
            Messenger.Default.Send(new ChangeListView() { NavigationButtonsItems = ListView, NavigationTitle = "TOURNAMENTS"});
        }

        public ICommand GoHomeCommand => new DelegateCommand(GoHome);
        public ICommand ShowAllTournamentsCommand => new DelegateCommand(ShowAllTournaments);
        public ICommand AddNewTournamentCommand => new DelegateCommand(AddNewTournament);
        public ICommand GoToCurrentTournamentCommand => new DelegateCommand(GoToCurrentTournament);
        public ICommand ExitCommand => new DelegateCommand(Exit);

        public void GoHome()
        {
            Messenger.Default.Send(new ChangeView() { ViewName = "Home" });
        }
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
        public void GoToCurrentTournament()
        {
            if (_currentTournamentId > 0)
                _currentView = new CurrentTournamentViewModel(_currentTournamentId);
            else
            {
                MessageBox.Show("Nie wybrano turnieju lub turniej nie poprawny!");
            }
            RaisePropertyChangedEvent("CurrentView");
        }
        public void Exit()
        {
            if (MessageBox.Show("Are you sure you want to exit the application?", "Question", MessageBoxButton.YesNo,
                    MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }
    }
}
