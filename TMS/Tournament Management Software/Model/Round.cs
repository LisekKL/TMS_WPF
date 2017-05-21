using System.Collections.ObjectModel;

namespace Tournament_Management_Software.Model
{
    public class Round
    {
        //private static int _counter;

        public Round()
        {
            //  RoundId = ++_counter;
        }
        public int RoundId { get; set; }

        public int TournamentId { get; set; }
        public virtual Tournament Tournament { get; set; }

        public int AgeClassId { get; set; }
        public virtual AgeClass AgeClass { get; set; }
        
        public virtual ObservableCollection<SingleMatch> SingleMatches { get; set; }
    }
}
