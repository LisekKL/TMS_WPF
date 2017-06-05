using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using Tournament_Management_Software.Model;

namespace Tournament_Management_Software.Helpers.OpponentFinder
{
    public static class RoundRobin
    {
        public enum Flags
        {
            Normal,
            Bye,

        }
        public static List<SingleMatch> GetMatches(List<Contestant> allContestants)
        {
            if (allContestants.Count <= 1)
            {
                return null;
            }
            List<SingleMatch> matches = new List<SingleMatch>();

            // If there are only 2 contestants there's only one match
            if (allContestants.Count == 2)
            {
                matches.Add(new SingleMatch(allContestants[0].ContestantId, allContestants[1].ContestantId));
                return matches;
            }

            List<int> tmp = new List<int>();
            for (int i = 0; i < allContestants.Count; i++)
            {
                tmp.Add(i);
            }
            if (allContestants.Count % 2 != 0 )
                allContestants.Add(new Contestant() {FirstName = "", LastName = "", TournamentId = allContestants[0].TournamentId});

            int returnedToStartIndex = 1;
        }
    }
}
