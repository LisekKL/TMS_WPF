using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournament_Management_Software.Model
{
    public class Round
    {
        private static int _counter;

        public Round()
        {
            ++_counter;
            RoundId = _counter;
        }
        public int RoundId { get; set; }

        public int TournamentId { get; set; }
        public virtual Tournament Tournament { get; set; }

        public int AgeClassId { get; set; }
        public virtual AgeClass AgeClass { get; set; }
        
        public virtual ObservableCollection<SingleMatch> SingleMatches { get; set; }
    }
}
