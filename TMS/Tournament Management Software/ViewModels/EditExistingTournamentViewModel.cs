using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tournament_Management_Software.Helpers.Context;
using Tournament_Management_Software.Model;

namespace Tournament_Management_Software.ViewModels
{
    public class EditExistingTournamentViewModel : ObservableObject
    {
        private ObservableCollection<Tournament> _allTournaments;
        private readonly Tournament _tournament;

        public EditExistingTournamentViewModel(Tournament tournament)
        {
            var context = new TMSContext();
            _tournament = tournament;
            _allTournaments = new ObservableCollection<Tournament>(context.Tournaments);
        }
        public EditExistingTournamentViewModel() { }
        public string TxtTournamentName { get { return _tournament.Name; } set { _tournament.Name = value; RaisePropertyChangedEvent("TournamentName");  } }
        public string TxtTournamentStartDate { get { return _tournament.StartDate.ToString(); } set { _tournament.StartDate = DateTime.Parse(value);} }
    }
}
