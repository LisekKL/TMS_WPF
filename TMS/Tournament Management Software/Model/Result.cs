using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournament_Management_Software.Model
{
    public class Result
    {
        public int PointsContestantA { get; set; } = 0;
        public int PointsContestantB { get; set; } = 0;

        private char _separator = '-';

        public string GetTotalScoreString() => String.Concat(PointsContestantA + _separator + PointsContestantB);
    }
}
