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
        public MainWindowViewModel()
        {
            Messenger.Default.Register<ActiveTournamentId>(this, SetCurrentTournamentId);
            Messenger.Default.Register<ChangeListView>(this, ChangeListViewContent);
            Messenger.Default.Register<ChangeView>(this,ChangeViewContent);
            InitiateNavigationBar();
            SetHomeView();
        }

        private int _currentTournamentId;
        public int CurrentTournamentId { get { return _currentTournamentId; } set { _currentTournamentId = value;RaisePropertyChangedEvent("CurrentTournamentId"); } }
        public static string Title { get; set; } = "Tournament Management Software";

        public ObservableCollection<ButtonItem> ListView { get; set; }
        public ObservableCollection<MenuItem> NavigationMenu { get; set; } = new ObservableCollection<MenuItem>();

        private object _currentView;
        public object CurrentView { get { return _currentView; } set { _currentView = value; RaisePropertyChangedEvent("CurrentView"); } }

        public void InitiateNavigationBar()
        {
            NavigationMenu.Add(new MenuItem() {Header = "Home", Command = NavigateHomeCommand});
            RaisePropertyChangedEvent("NavigationMenu");
        }

        public ICommand NavigateHomeCommand => new DelegateCommand(SetHomeView);
        public ICommand ShowAllTournamentsCommand => new DelegateCommand(ShowAllTournaments);
        public ICommand AddNewTournamentCommand => new DelegateCommand(AddNewTournament);
        public ICommand GoToCurrentTournamentCommand => new DelegateCommand(GoToCurrentTournament);

        public void ShowAllTournaments()
        {

        }
        public void AddNewTournament()
        {

        }
        public void GoToCurrentTournament()
        {

        }
        public void SetHomeView()
        {
            _currentView = new DefaultViewModel();
            RaisePropertyChangedEvent("CurrentView");
        }

        public void SetCurrentTournamentId(ActiveTournamentId action)
        {
            CurrentTournamentId = action.Message;
            RaisePropertyChangedEvent("CurrentTournamentId");
        }

        public void ChangeListViewContent(ChangeListView action)
        {
            ListView = action.Message;
            RaisePropertyChangedEvent("ListView");
        }

        public void ChangeViewContent(ChangeView action)
        {
            _currentView = action.Message;
            RaisePropertyChangedEvent("CurrentView");
        }

    }
}
