using System;

namespace Tournament_Management_Software.Model
{
    public class SingleMatch
    {
        private static int _counter;

        public SingleMatch(int contA, int contB)
        {
            SingleMatchId = ++_counter;
            Result = new Result() {PointsContestantA = 0, PointsContestantB = 0};
            FirstContestantId = contA;
            SecondContestantId = contB;
        }
        public int SingleMatchId { get; set; }
        public string MatchName { get; set; }
        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public long Duration { get; set; }
        public Result Result { get; set; }

        public int FirstContestantId { get; set; }
        public int SecondContestantId { get; set; }

        public int TournamentId { get; set; }
        public virtual Tournament Tournament { get; set; }
        
    }
}
