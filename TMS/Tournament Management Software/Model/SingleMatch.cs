using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Tournament_Management_Software.Model
{
    public class SingleMatch
    {
        private static int _counter;

        public SingleMatch()
        {
            ++_counter;
            SingleMatchId = _counter;
        }
        public int SingleMatchId { get; set; }
        public string MatchName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public long Duration { get; set; }
        public Result Result { get; set; }

        public int FirstContestantId { get; set; }
        public int SecondIdContestantId { get; set; }

        public int RoundId { get; set; }
        public virtual Round Round { get; set; }
        
    }
}
