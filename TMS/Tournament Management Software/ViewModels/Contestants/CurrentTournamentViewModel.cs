using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tournament_Management_Software.Helpers;
using Tournament_Management_Software.Helpers.Context;
using Tournament_Management_Software.Model;

namespace Tournament_Management_Software.ViewModels.Contestants
{
    public class CurrentTournamentViewModel : ObservableObject
    {
        private Tournament _tournament;
        public CurrentTournamentViewModel(int tournamentId)
        {
            _tournament = FindTournamentById(tournamentId);

        }

        private object _currentTournament;
        public object CurrentTournament { get { return _currentTournament; } set { _currentTournament = value; RaisePropertyChangedEvent("CurrentView"); } }

        public Tournament FindTournamentById(int tournamentId)
        {
            var context = new TMSContext();
            _tournament = (from tournament in context.Tournaments
                where tournament.TournamentId == tournamentId
                select tournament).ToList().First();
            if (_tournament == null)
            {
                MessageBox.Show("NIE ZNALEZIONO turnieju o ID " + tournamentId);
                return null;
            }
            return _tournament;
        }

        public ObservableCollection<Contestant> Constestants { get; set; }
        public ObservableCollection<Round> Rounds { get; set; }
    }
}
