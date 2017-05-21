using System;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;
using Tournament_Management_Software.Helpers;
using Tournament_Management_Software.Helpers.Context;
using Tournament_Management_Software.Helpers.Messages;
using Tournament_Management_Software.Model;
using Tournament_Management_Software.ViewModels.Home;

namespace Tournament_Management_Software.ViewModels.Tournaments
{
    public class AddTournamentViewModel : ObservableObject
    {
        private Tournament _tournament = new Tournament();

        private string _outputMessage;
        public string OutputMessage { get { return _outputMessage; } set { _outputMessage = value; RaisePropertyChangedEvent("OutputMessage");} }     
        public string TournamentName { get { return _tournament.Name; } set { _tournament.Name = value; RaisePropertyChangedEvent("TournamentName"); } }
        public string Location { get { return _tournament.Location; } set { _tournament.Location = value; RaisePropertyChangedEvent("Location"); } }
        public string Information { get { return _tournament.Information; } set { _tournament.Information = value; RaisePropertyChangedEvent("Information"); } }
        public string TournamentId { get { return _tournament.TournamentId.ToString(); } set { _tournament.TournamentId = Int32.Parse(value); RaisePropertyChangedEvent("TournamentId");} }

        public string TxtDateTime { get; set; } = DateTime.Now.ToShortDateString();
        public DateTime? DtPickerStartDate
        {
            get { return _tournament.StartDate; }
            set { _tournament.StartDate = value; RaisePropertyChangedEvent("StartDate"); }
        }

        public ICommand AddNewTournamentCommand => new DelegateCommand(AddNewTournament);

        public void AddNewTournament()
        {
            try
            {
                TMSContext context = new TMSContext();
                var query = (from t in context.Tournaments where t.TournamentId == _tournament.TournamentId select t)
                    .ToList();
                //TODO: VALIDATION
                if (query.Count >= 1)
                {
                    OutputMessage = "This tournament already exists in database!";
                    MessageBox.Show(OutputMessage);
                }
                else
                {
                    context.Tournaments.AddOrUpdate(_tournament);
                    context.SaveChanges();
                    OutputMessage += "\nSuccessfully added a new tournament to the database!\n";
                    OutputMessage += _tournament.GetTournamentDataString();
                    MessageBox.Show(OutputMessage);
                }
            }
            catch (Exception e)
            {
                OutputMessage += "\nERROR adding new tournament to database!\nErrormessage = " + e.Message + "\n";
                OutputMessage += _tournament.GetTournamentDataString();
                MessageBox.Show(OutputMessage);
            }
            CleanUp();
            Messenger.Default.Send(new ChangeView() {Message = new DefaultViewModel()});
        }

        public void CleanUp()
        {
            TournamentName = String.Empty;
            
            Information = String.Empty;
            Location = String.Empty;
            TxtDateTime = DateTime.Now.ToShortDateString();
            DtPickerStartDate = null;
            _tournament = new Tournament();
            RaisePropertyChangedEvent("Tournament");
        }


    }
}
