using System;
using System.Collections.ObjectModel;

namespace Tournament_Management_Software.Model
{
    public class Tournament
    {
        private static int _counter;

        public Tournament()
        {
            TournamentId = ++_counter;
        }
        public int TournamentId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Information { get; set; }

        public virtual ObservableCollection<Contestant> Contestants { get; set; }
        public virtual ObservableCollection<AgeClass> AgeClasses { get; set; }

        public string GetTournamentDataString()
        {
            int contAmount = Contestants?.Count ?? 0;
            return ("Tournament ID: " + TournamentId + "\nNAME = " + Name + "\nPlanned Start Date = " +
                    StartDate + "\nAt location" + Location + "\nCurrent number of contestants = " + contAmount);
        }
    }
}
