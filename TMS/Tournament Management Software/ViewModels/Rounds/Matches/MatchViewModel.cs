using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournament_Management_Software.ViewModels.Rounds.Matches
{
    public class MatchViewModel
    {
        private int _tournamentId;
        public MatchViewModel(int tournamentId)
        {
            _tournamentId = tournamentId;
        }
    }
}
