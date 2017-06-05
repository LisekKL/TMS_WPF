using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;
using Tournament_Management_Software.Helpers;
using Tournament_Management_Software.Helpers.Messages;
using Tournament_Management_Software.ViewModels.AgeClasses;
using Tournament_Management_Software.ViewModels.AgeClasses.WeightClasses;
using Tournament_Management_Software.ViewModels.Contestants;
using Tournament_Management_Software.ViewModels.Home;
using Tournament_Management_Software.ViewModels.Tournaments;
using MenuItem = System.Windows.Controls.MenuItem;
using MessageBox = System.Windows.MessageBox;


namespace Tournament_Management_Software.ViewModels
{
    public class MainWindowViewModel : ObservableObject
    {
        private Dictionary<string, object> _viewModels;

        //Tytuł - nie wymagane
        public static string Title { get; set; } = "Tournament Management Software";

        // Konstruktor inicjalujący listę navigacyjną (menu) oraz Opcje
        public MainWindowViewModel()
        {
            Messenger.Default.Register<ActiveTournamentId>(this, SetTournamentId);
            Messenger.Default.Register<ChangeListView>(this, SetListView);
            Messenger.Default.Register<ChangeView>(this, SetView);
            InitiateNavigationBar();
            InitiateViewModels();
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

        public void InitiateViewModels()
        {
            _viewModels = new Dictionary<string, object>
            {
                {"Home", new DefaultViewModel()},
                {"Tournaments", new TournamentViewModel()},
                {"Contestants", new ContestantViewModel(_currentTournamentId)},
                {"AgeClasses", new AgeClassViewModel(_currentTournamentId)}
            };
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
                _currentView = _viewModels["Home"];
            }
            else if (viewName.Equals("Tournaments", StringComparison.InvariantCultureIgnoreCase))
            {
                _currentView = _viewModels["Tournaments"];
            }
            else if (viewName.Equals("Contestants", StringComparison.InvariantCultureIgnoreCase))
            {
                if (_currentTournamentId > 0)
                    _currentView = _viewModels["Contestants"];
                else
                {
                    MessageBox.Show("INVALID TOURNAMENT ID!\nPlease select a valid tournament!\n");
                    _currentView = _viewModels["Home"];
                }
            }
            else if (viewName.Equals("AgeClasses", StringComparison.InvariantCultureIgnoreCase))
            {
                if (_currentTournamentId > 0)
                    _currentView = _viewModels["AgeClasses"];
                else
                {
                    MessageBox.Show("INVALID TOURNAMENT ID!\nPlease select a valid tournament!\n");
                    _currentView = _viewModels["Home"];
                }
            }
            else
            {
                _currentView = _viewModels["Home"];
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
