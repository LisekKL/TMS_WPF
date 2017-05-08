using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Migrations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using Tournament_Management_Software.Helpers;
using Tournament_Management_Software.Helpers.Context;
using Tournament_Management_Software.Model;

namespace Tournament_Management_Software.ViewModels
{
    public class AddTournamentViewModel : ObservableObject
    {
        private Tournament _tournament;

        private string _outputMessage;
        public string OutputMessage { get { return _outputMessage; } set { _outputMessage = value; RaisePropertyChangedEvent("OutputMessage");} }     
        public string TxtTournamentName { get { return _tournament.Name; } set { _tournament.Name = value; RaisePropertyChangedEvent("TxtTournamentName"); } }
        public string TxtTournamentStartDate
        {
            get { return _tournament.StartDate.ToString(); }
            set { _tournament.StartDate = DateTime.Parse(value); RaisePropertyChangedEvent("TxtTournamentStartDate"); }
        }
        public DateTime? DtPickerStartDate
        {
            get { return _tournament.StartDate; }
            set { _tournament.StartDate = value; RaisePropertyChangedEvent("StartDate"); }
        }
        public string TxtLocation { get { return _tournament.Location; } set { _tournament.Location = value; RaisePropertyChangedEvent("TxtLocation"); } }
        public string TxtInformation { get { return _tournament.Info; } set { _tournament.Info = value; RaisePropertyChangedEvent("TxtInformation"); } }

        public ICommand AddNewTournamentCommand => new DelegateCommand(AddNewTournament);

        public AddTournamentViewModel()
        {
            _tournament = new Tournament();
        }
        public void AddNewTournament()
        {
            try
            {
                TMSContext context = new TMSContext();
                //TODO: VALIDATION

                if (context.Tournaments.Any(t => t.TournamentId == _tournament.TournamentId))
                {
                    OutputMessage = "This tournament already exists in database!";
                }
                else
                {
                    context.Tournaments.AddOrUpdate(_tournament);
                    context.SaveChanges();
                    OutputMessage += "\nSuccessfully added a new tournament to the database!\n";
                    OutputMessage += _tournament.GetTournamentDataString();
                }
            }
            catch (Exception e)
            {
                OutputMessage += "\nERROR adding new tournament to database!\nErrormessage = " + e.Message + "\n";
                OutputMessage += _tournament.GetTournamentDataString();          
            }
            RaisePropertyChangedEvent("OutputMessage");
            CleanUp();
        }

        public void CleanUp()
        {
            TxtTournamentName = String.Empty;
            TxtTournamentStartDate = String.Empty;
            TxtInformation = String.Empty;
            TxtLocation = String.Empty;
            _tournament = new Tournament();
            RaisePropertyChangedEvent("Tournament");
        }


    }
}
