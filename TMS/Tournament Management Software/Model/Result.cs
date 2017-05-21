using static System.String;

namespace Tournament_Management_Software.Model
{
    public class Result
    {
        public int PointsContestantA { get; set; } = 0;
        public int PointsContestantB { get; set; } = 0;

        private const char Separator = '-';

        public string GetTotalScoreString() => Concat(PointsContestantA + Separator + PointsContestantB);
    }
}
