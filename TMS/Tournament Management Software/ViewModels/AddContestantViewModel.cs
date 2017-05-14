using System;
using System.Data.Entity.Migrations;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;
using Tournament_Management_Software.Helpers;
using Tournament_Management_Software.Helpers.Context;
using Tournament_Management_Software.Helpers.Enums;
using Tournament_Management_Software.Model;
using static System.Double;

namespace Tournament_Management_Software.ViewModels
{
    public class AddContestantViewModel : ObservableObject
    {
        private Contestant _contestant;
        public Contestant Contestant { get { return _contestant; } set { _contestant = value; RaisePropertyChangedEvent("Contestant"); } }

        public GenderEnum Gender { get { return _contestant.Gender; } set { _contestant.Gender = value; RaisePropertyChangedEvent("Gender"); } }
        public string TxtContestantFirstName
        {
            get { return _contestant.FirstName; }
            set
            {
                _contestant.FirstName = value;
                RaisePropertyChangedEvent("TxtContestantFirstName");
            }
        }
        public string OutputMessage { get; set; }

        public ICommand AddNewContestantCommand => new DelegateCommand(AddNewContestant);
        public string TxtContestantWeight { get { return _contestant.Weight.ToString(); } set
            {
                _contestant.Weight = Parse(value);
                RaisePropertyChangedEvent("Weight");
            } }
        public string TxtContestantHeight { get { return _contestant.Height.ToString(); } set
        {
            _contestant.Height = Parse(value);
            RaisePropertyChangedEvent("Height");
        } }
        public string TxtContestantLastName
        {
            get { return _contestant.LastName; }
            set
            {
                _contestant.LastName = value;
                RaisePropertyChangedEvent("ContestantLastName");
            }
        }
        public string TxtDateOfBirth
        {
            get
            {
                return _contestant.DateOfBirth.ToShortDateString();
            }
            set
            {
                _contestant.DateOfBirth = DateTime.Parse(value);
                RaisePropertyChangedEvent("DateOfBirth");
            }
        }
        public DateTime DtPickerDateOfBirth { get { return _contestant.DateOfBirth; } set { _contestant.DateOfBirth = value; RaisePropertyChangedEvent("DateOfBirth"); } }
        public bool IsMale
        {
            get { return _contestant.Gender.ToString().Equals("male", StringComparison.InvariantCultureIgnoreCase); }
            set { _contestant.Gender = value ? GenderEnum.Male : GenderEnum.Female; }
        }
        public bool IsFemale
        {
            get { return _contestant.Gender.ToString().Equals("female", StringComparison.InvariantCultureIgnoreCase); }
            set { _contestant.Gender = value ? GenderEnum.Female : GenderEnum.Male; }
        }
        public string LblGenderFemale => "Female";
        public string LblGenderMale => "Male";

        public static int TournamentId { get; set; }
        public AddContestantViewModel(int tournamentId)
        {
            Messenger.Default.Register<ActiveTournamentId>(this, SetTournamentId);
            _contestant = new Contestant {TournamentId = tournamentId};
        }

        //public AddContestantViewModel()
        //{
        //    Messenger.Default.Register<ActiveTournamentId>(this, DoNothing);
        //    _contestant = new Contestant();
        //}

        public void DoNothing(ActiveTournamentId action)
        {
            
        }

        public void SetTournamentId(ActiveTournamentId action)
        {
            TournamentId = action.Message;
            RaisePropertyChangedEvent("TournamentId");
        }
        public void AddNewContestant()
        {           
            try
            {
                TMSContext context = new TMSContext();
                _contestant.TournamentId = TournamentId;
                //TODO: VALIDATION
                context.Contestants.AddOrUpdate(_contestant);
                context.SaveChanges();
                OutputMessage += "\nSuccessfully added a new contestant to the database!\n";
                OutputMessage += _contestant.GetContestantDataString();
                RaisePropertyChangedEvent("OutputMessage");
            }
            catch (Exception e)
            {
                OutputMessage += "\nERROR adding new contestant to database!\nErrormessage = " + e.Message + "\n";
                OutputMessage += _contestant.GetContestantDataString();
                RaisePropertyChangedEvent("OutputMessage");
            }
            ClearData();
            RaisePropertyChangedEvent("Contestant");
        }

        public void ClearData()
        {
            TxtContestantFirstName = String.Empty;
            TxtContestantLastName = String.Empty;
            TxtContestantHeight = String.Empty;
            TxtContestantWeight = String.Empty;
            TxtDateOfBirth = String.Empty;
            _contestant = new Contestant();
            RaisePropertyChangedEvent("Contestant");
        }
    }
}
