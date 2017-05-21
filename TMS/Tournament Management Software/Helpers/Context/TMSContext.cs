using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tournament_Management_Software.Model;

namespace Tournament_Management_Software.Helpers.Context
{
    public class TMSContext : DbContext
    {
        public TMSContext() : base("TMS_TST")
        {
            Database.SetInitializer(new TMSContextInitializer());
        }
        public DbSet<Contestant> Contestants { get; set; }
        public DbSet<SingleMatch> Matches { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<AgeClass> AgeClasses { get; set; }
        public DbSet<WeightClass> WeightClasses { get; set; }
        public DbSet<Round> Rounds { get; set; }    }
}
