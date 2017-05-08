using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Tournament_Management_Software.Helpers;
using Tournament_Management_Software.Helpers.Context;
using Tournament_Management_Software.Model;

namespace Tournament_Management_Software.ViewModels
{
    public class DefaultViewModel : ObservableObject
    {
        public string Text { get; set; }
        public string FooterText { get; set; } = "Tournament Management Software Default View";
        public Visibility EditButtonVisibility { get; set; }
        public Visibility ButtonPanelVisibility { get; set; }
        public Visibility TextPanelVisibility { get; set; }

        public DefaultViewModel()
        {
            Text = "Reading data from database..."; 
            //Get content form Database about current Tournaments --> TODO : How to make ShowAllTournament Do that and give me back the count of Tournaments?
            var context = new TMSContext();
            var queryCurrentTournaments = (from t in context.Tournaments where t.EndDate == null select t).ToList();
            Tournaments = new ObservableCollection<Tournament>(queryCurrentTournaments);
            if (Tournaments.Count > 0)
            {
                _tournamentView = new ShowAllTournamentsViewModel(Tournaments);
                RaisePropertyChangedEvent("TournamentView");
                Text = "Here is a list of current Tournaments in Database";
                
                EditButtonVisibility = Visibility.Visible;
            }
            else
            {
                Text =
                    "Oops.... \nIt seems you don't have any current Tournaments running....\nCreate one now by clicking the \"New Tournament\"-button!";
                EditButtonVisibility = Visibility.Hidden;
            }
            TextPanelVisibility = Visibility.Visible;
            ButtonPanelVisibility = Visibility.Visible;
            RaisePropertyChangedEvent("TournamentView");
            RaisePropertyChangedEvent("EditButtonVisibility");
            RaisePropertyChangedEvent("Text");

        }

        private object _tournamentView;
        public object TournamentView { get { return _tournamentView; } set { _tournamentView = value; RaisePropertyChangedEvent("TournamentView"); } }

        private ObservableCollection<Tournament> _tournaments;
        public ObservableCollection<Tournament> Tournaments { get { return _tournaments; } set { _tournaments = value; RaisePropertyChangedEvent("Tournaments"); } }

        public ICommand CreateNewTournamentCommand => new DelegateCommand(CreateNewTournament);
        public ICommand EditExistingTournamentCommand => new DelegateCommand(EditExistingTournament);
        public ICommand ShowAllTournamentsCommand => new DelegateCommand(ShowAllTournaments);

        //public int TournamentId { get; set; }

        public void ShowAllTournaments()
        {
            _tournamentView = new ShowAllTournamentsViewModel();
            RaisePropertyChangedEvent("TournamentView");
        }
        public void EditExistingTournament() { 
            _tournamentView = new EditExistingTournamentViewModel();
            RaisePropertyChangedEvent("TournamentView");
        }
        public void CreateNewTournament()
        {
            ButtonPanelVisibility = Visibility.Collapsed;
            TextPanelVisibility = Visibility.Collapsed;
            RaisePropertyChangedEvent("ButtonPanelVisibility");
            _tournamentView = new AddTournamentViewModel();
            RaisePropertyChangedEvent("TournamentView");
        }
        
    }
}
