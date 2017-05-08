using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournament_Management_Software.Model
{
    public class Tournament
    {
        private static int _counter;

        public Tournament()
        {
            ++_counter;
            TournamentId = _counter;
        }
        public int TournamentId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Info { get; set; }


        public virtual ObservableCollection<Contestant> Contestants { get; set; } = new ObservableCollection<Contestant>();
        public virtual ObservableCollection<Round> Rounds { get; set; }

        public int GetContestantAmount() => Contestants.Count;
        public int GetAmountofRounds() => Rounds.Count;
        public List<AgeClass> GetAgeClasses()
        {
            var queryRounds = Rounds.ToList();
            var queryAgeClasses = (from r in queryRounds select r.AgeClass).ToList();
            var queryWeightClasses = (from weight in queryAgeClasses select weight).ToList();
            return queryAgeClasses;
        }
        public void RegisterForTournament(Contestant cont) { Contestants.Add(cont); }
        public List<Contestant> GetAllContestants() => Contestants.ToList();
        public string GetTournamentDataString()
        {
            return ("Tournament ID: " + TournamentId + "  | NAME = " + Name + " planned Start Date = " +
                    StartDate.ToString() + " at location" + Location + "\nCurrent number of contestants = ");
        }
    }
}
