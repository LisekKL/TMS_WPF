using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;
using Tournament_Management_Software.Helpers;
using Tournament_Management_Software.Helpers.Context;
using Tournament_Management_Software.Helpers.Messages;
using Tournament_Management_Software.Model;

namespace Tournament_Management_Software.ViewModels.Tournaments
{
    public class CurrentTournamentViewModel : ObservableObject
    {
        public Tournament CurrentTournament { get; }

        public ObservableCollection<Contestant> Contestants => CurrentTournament.Contestants;
        public ObservableCollection<AgeClass> AgeClasses => CurrentTournament.AgeClasses;
        public ObservableCollection<WeightClass> WeightClasses { get; }

        public string ViewTitle { get; set; } = "CURRENT TOURNAMENT";

        public ObservableCollection<ButtonItem> ListView { get; set; } 
        public CurrentTournamentViewModel(int tournamentId)
        {
            InitiateListView();
            CurrentTournament = FindTournamentById(tournamentId);
            RaisePropertyChangedEvent("CurrentTournament");

            if (CurrentTournament == null)
            {
                MessageBox.Show("Nie znaleziono turnieju o ID " + tournamentId);
                Messenger.Default.Send(new ChangeView() {ViewName = "Tournaments"});
            }
            else
            {
                List<WeightClass> wClasses = new List<WeightClass>();
                foreach (var ag in AgeClasses)
                {
                    var query = (from wg in ag.WeightClasses select wg).ToList();
                    wClasses.AddRange(query);
                }
                WeightClasses = new ObservableCollection<WeightClass>(wClasses);
                RaisePropertyChangedEvent("WeightClasses");
            }
        }

        private object _ageClassesView;
        public object AgeClassesView { get { return _ageClassesView; } set { _ageClassesView = value; RaisePropertyChangedEvent("AgeClassesView"); } }

        public void InitiateListView()
        {
            ListView = new ObservableCollection<ButtonItem>()
            {
                new ButtonItem() {Label = "Contestants", Command = GoToContestantsCommand},
                new ButtonItem() {Label = "AgeClasses", Command = GoToAgeClassesCommand}, 
                new ButtonItem() {Label = "Exit", Command = ExitCommand }
            };          
            Messenger.Default.Send(new ChangeListView() { NavigationButtonsItems = ListView, NavigationTitle = "CURRENT TOURNAMENT: " + CurrentTournament?.TournamentId});
        }

        public ICommand GoToContestantsCommand => new DelegateCommand(GoToContestants);
        public ICommand GoToAgeClassesCommand => new DelegateCommand(GoToAgeClasses);
        public ICommand GoToWeightClassesCommand => new DelegateCommand(GoToWeightClasses);
        public ICommand ExitCommand => new DelegateCommand(Exit);

        public void GoToContestants()
        {
            Messenger.Default.Send(new ChangeView() {ViewName = "Contestants"});
        }
        public void Exit()
        {
            Messenger.Default.Send(new ChangeView() { ViewName = "EXIT" });
        }
        public void GoToAgeClasses()
        {
            Messenger.Default.Send(new ChangeView() { ViewName = "AgeClasses"});
        }
        public void GoToWeightClasses()
        {
            Messenger.Default.Send(new ChangeView() { ViewName = "WeightClasses" });
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
                MessageBox.Show("ERROR FINDING TOURNAMENT!" + e.Message);
                return null;
            }

        }
    }
}
