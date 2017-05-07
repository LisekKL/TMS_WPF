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
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public ObservableCollection<Contestant> Contestants { get; set; } = new ObservableCollection<Contestant>();

        public void RegisterForTournament(Contestant cont) { Contestants.Add(cont);}
        public List<Contestant> GetAllContestants() => Contestants.ToList();
        public virtual ObservableCollection<Round> Rounds { get; set; }
        
    }
}
