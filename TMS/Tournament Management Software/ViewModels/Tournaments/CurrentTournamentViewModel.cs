using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;
using Tournament_Management_Software.Helpers;
using Tournament_Management_Software.Helpers.Context;
using Tournament_Management_Software.Helpers.Messages;
using Tournament_Management_Software.Model;
using Tournament_Management_Software.ViewModels.Contestants;

namespace Tournament_Management_Software.ViewModels.Tournaments
{
    public class CurrentTournamentViewModel : ObservableObject
    {
        private readonly Tournament _tournament;
        public string OutputMessage { get; set; }
        public ObservableCollection<ButtonItem> ListView { get; set; } = new ObservableCollection<ButtonItem>();
        public CurrentTournamentViewModel(int tournamentId)
        {
            InitiateListView();
            _tournament = FindTournamentById(tournamentId);
            if (_tournament == null)
            {
                OutputMessage = "Nie znaleziono turnieju o ID " + tournamentId;
            }
            else
            {
                OutputMessage = _tournament.GetTournamentDataString();
            }
            _currentView = OutputMessage;
            RaisePropertyChangedEvent("CurrentView");
        }

        private object _currentView;
        public object CurrentView { get { return _currentView; } set { _currentView = value; RaisePropertyChangedEvent("CurrentView"); } }

        public void InitiateListView()
        {
            ListView.Add(new ButtonItem() {Label = "Contestants", Command = GoToContestantsCommand});
            ListView.Add(new ButtonItem() {Label = "Categories", Command = GoToCategoriesCommand});
            RaisePropertyChangedEvent("ListView");
            Messenger.Default.Send(new ChangeListView() { Message = ListView });
        }
        public ICommand GoToContestantsCommand => new DelegateCommand(GoToContestants);
        public ICommand GoToCategoriesCommand => new DelegateCommand(GoToCategories);

        public void GoToCategories()
        {
            
        }
        public void GoToContestants()
        {
            _currentView = new ContestantsViewModel(_tournament.TournamentId);
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
