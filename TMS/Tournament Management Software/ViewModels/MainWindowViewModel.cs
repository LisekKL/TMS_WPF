using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;
using Tournament_Management_Software.Helpers;
using Tournament_Management_Software.Helpers.Messages;
using Tournament_Management_Software.ViewModels.AgeClasses;
using Tournament_Management_Software.ViewModels.Contestants;
using Tournament_Management_Software.ViewModels.Home;
using Tournament_Management_Software.ViewModels.Tournaments;
using MenuItem = System.Windows.Controls.MenuItem;
using MessageBox = System.Windows.MessageBox;


namespace Tournament_Management_Software.ViewModels
{
    public class MainWindowViewModel : ObservableObject
    {
        //Tytuł - nie wymagane
        public static string Title { get; set; } = "Tournament Management Software";

        // Konstruktor inicjalujący listę navigacyjną (menu) oraz Opcje
        public MainWindowViewModel()
        {
            Messenger.Default.Register<ActiveTournamentId>(this, SetTournamentId);
            Messenger.Default.Register<ChangeListView>(this, SetListView);
            Messenger.Default.Register<ChangeView>(this, SetView);
            InitiateNavigationBar();
            SetHomeView();
        }

        // Dostaje wiadomość z ID zaznaczonego turnieju
        private int _currentTournamentId;
        public int CurrentTournamentId { get { return _currentTournamentId; } set { _currentTournamentId = value; RaisePropertyChangedEvent("CurrentTournamentId"); } }

        // Przechowuje opcje dla górnego menu
        public ObservableCollection<MenuItem> NavigationMenu { get; set; }

        // Przechowuje widok główny obecny
        private object _currentView;
        public object CurrentView { get { return _currentView; } set { _currentView = value; RaisePropertyChangedEvent("CurrentView"); } }

        // Przechowuje listę nawigacyjną dla obecnego widoku
        private object _currentListView;
        public object CurrentListView { get { return _currentListView; } set { _currentListView = value; RaisePropertyChangedEvent("CurrentListView"); } }

        //Inicjalizuje górne menu
        public void InitiateNavigationBar()
        {
            NavigationMenu =
                new ObservableCollection<MenuItem>
                {
                    new MenuItem()
                    {
                        Header = "Home",   
                        Command = NavigateHomeCommand
                    },
                    new MenuItem()
                    {
                        Header = "Tournaments",
                        Command = NavigateToTournamentCommand
                    },
                    new MenuItem()
                    {
                        Header = "Contestants",
                        Command = NavigateToContestantCommand
                    },
                    new MenuItem()
                    {
                        Header = "AgeClasses",
                        Command = NavigateToAgeClassesCommand
                    }
                };
            RaisePropertyChangedEvent("NavigationMenu");
        }

        public ICommand NavigateHomeCommand => new DelegateCommand(SetHomeView);
        public ICommand NavigateToTournamentCommand => new DelegateCommand(SetTournamentView);
        public ICommand NavigateToContestantCommand => new DelegateCommand(SetContestantView);
        public ICommand NavigateToAgeClassesCommand => new DelegateCommand(SetAgeClassView);

        public void SetHomeView()
        {
            _currentView = new DefaultViewModel();
            RaisePropertyChangedEvent("CurrentView");
        }
        public void SetTournamentView()
        {
            _currentView = new TournamentViewModel();
            RaisePropertyChangedEvent("CurrentView");
        }
        public void SetContestantView()
        {
            if (_currentTournamentId == 0)
            {
                MessageBox.Show("No Tournament selected!\nPlease select a tournament first to show it's contestants!");
            }
            else
            {
                _currentView = new ContestantViewModel(_currentTournamentId);
                RaisePropertyChangedEvent("CurrentView");
            }
        }
        public void SetAgeClassView()
        {
            if (_currentTournamentId == 0)
            {
                MessageBox.Show("No Tournament selected!\nPlease select a tournament first to show it's categories!");
            }
            else
            {
                _currentView = new AgeClassViewModel(_currentTournamentId);
                RaisePropertyChangedEvent("CurrentView");
            }
        }

        public void SetListView(ChangeListView action)
        {
            _currentListView = new NavigationMenuViewModel(action);
            RaisePropertyChangedEvent("CurrentListView");
        }
        public void SetView(ChangeView action)
        {
            string viewName = action.ViewName;
            if (viewName.Equals("Home", StringComparison.InvariantCultureIgnoreCase))
            {
                _currentView = new DefaultViewModel();
            }
            else if (viewName.Equals("Tournaments", StringComparison.InvariantCultureIgnoreCase))
            {
                _currentView = new TournamentViewModel();
            }
            else if (viewName.Equals("Contestants", StringComparison.InvariantCultureIgnoreCase))
            {
                if (_currentTournamentId > 0)
                    _currentView = new ContestantViewModel(_currentTournamentId);
                else
                {
                    MessageBox.Show("INVALID TOURNAMENT ID!\nPlease select a valid tournament!\n");
                    _currentView = new DefaultViewModel();
                }
            }
            else if (viewName.Equals("AgeClasses", StringComparison.InvariantCultureIgnoreCase))
            {
                if (_currentTournamentId > 0)
                    _currentView = new AgeClassViewModel(_currentTournamentId);
                else
                {
                    MessageBox.Show("INVALID TOURNAMENT ID!\nPlease select a valid tournament!\n");
                    _currentView = new DefaultViewModel();
                }
            }
            else
            {
                _currentView = new DefaultViewModel();
            }
            RaisePropertyChangedEvent("CurrentView");
        }
        public void SetTournamentId(ActiveTournamentId action)
        {
            _currentTournamentId = action.Message;
            RaisePropertyChangedEvent("CurrentTournamentId");
        }
    }
}
