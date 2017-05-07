using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tournament_Management_Software.Model;

namespace Tournament_Management_Software.Helpers.Context
{
    public class ContestantData
    {
        private readonly TMSContext _context;

        public ContestantData()
        {
            _context = new TMSContext();
        }

        public List<Contestant> GetContestants()
        {
            var query = (from con in _context.Contestants select con);
            return query.ToList();
        }

        public List<Contestant> FindContestant(string lastname)
        {
            return (from con in _context.Contestants where con.LastName.Equals(lastname) select con).ToList();
        }
        public Contestant FindContestant(int id)
        {
            return (Contestant)(from con in _context.Contestants where (con.ContestantId == id) select con);
        }

    }
}
