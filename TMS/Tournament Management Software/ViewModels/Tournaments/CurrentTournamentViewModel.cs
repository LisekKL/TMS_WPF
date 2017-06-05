using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;
using Tournament_Management_Software.Helpers;
using Tournament_Management_Software.Helpers.Context;
using Tournament_Management_Software.Helpers.Messages;
using Tournament_Management_Software.Model;
using Tournament_Management_Software.ViewModels.AgeClasses;
using Tournament_Management_Software.ViewModels.Contestants;

namespace Tournament_Management_Software.ViewModels.Tournaments
{
    public class CurrentTournamentViewModel : ObservableObject
    {
        private readonly Tournament _tournament;
        public Tournament CurrentTournament => _tournament;

        public string ViewTitle { get; set; } = "CURRENT TOURNAMENT";

        public ObservableCollection<ButtonItem> ListView { get; set; } = new ObservableCollection<ButtonItem>();
        public CurrentTournamentViewModel(int tournamentId)
        {
            InitiateListView();
            _tournament = FindTournamentById(tournamentId);
            if (_tournament == null)
            {
                MessageBox.Show("Nie znaleziono turnieju o ID " + tournamentId);
                Messenger.Default.Send(new ChangeView() {ViewName = "Tournaments"});
            }
           // var context = new TMSContext();
           // _roundsView = new RoundViewModel(tournamentId);
            RaisePropertyChangedEvent("CurrentTournament");
        }

        private object _ageClassesView;
        public object AgeClassesView { get { return _ageClassesView; } set { _ageClassesView = value; RaisePropertyChangedEvent("AgeClassesView"); } }

        public void InitiateListView()
        {
            ListView.Add(new ButtonItem() {Label = "Contestants", Command = GoToContestantsCommand});
            ListView.Add(new ButtonItem() {Label = "AgeClasses", Command = GoToAgeClassesCommand});
            RaisePropertyChangedEvent("ListView");
            Messenger.Default.Send(new ChangeListView() { NavigationButtonsItems = ListView, NavigationTitle = "CURRENT TOURNAMENT: " +_tournament?.TournamentId});
        }
        public ICommand GoToContestantsCommand => new DelegateCommand(GoToContestants);
        public void GoToContestants()
        {
            Messenger.Default.Send(new ChangeView() {ViewName = "Contestants"});
            RaisePropertyChangedEvent("CurrentView");
        }

        public ICommand GoToAgeClassesCommand => new DelegateCommand(GoToAgeClasses);
        public void GoToAgeClasses()
        {
            Messenger.Default.Send(new ChangeView() { ViewName = "AgeClasses"});
            RaisePropertyChangedEvent("CurrentView");
        }

        public Tournament FindTournamentById(int id)
        {
            try
            {
                var context = new TMSContext();
                return (from t in context.Tournaments where t.TournamentId == id select t).ToList()[0];
            }
            catch (Exception e)
            {
                return null;
            }

        }
    }
}
