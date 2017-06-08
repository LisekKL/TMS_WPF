using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;
using Tournament_Management_Software.Helpers;
using Tournament_Management_Software.Helpers.Context;
using Tournament_Management_Software.Helpers.Enums;
using Tournament_Management_Software.Helpers.Messages;
using Tournament_Management_Software.Model;

namespace Tournament_Management_Software.ViewModels.Contestants
{
    public class AddContestantViewModel : ObservableObject
    {
        private readonly TMSContext _context = new TMSContext();
        private Contestant _contestant;
        public string OutputMessage { get; set; }

        [Required(ErrorMessage = "Musisz podać imię uczestnika!")]
        public string TxtContestantFirstName
        {
            get { return _contestant.FirstName; }
            set
            {
                _contestant.FirstName = value;
                RaisePropertyChangedEvent("TxtContestantFirstName");
            }
        }
        [Required(ErrorMessage = "Musisz podać nazwisko uczestnika!")]
        public string TxtContestantLastName
        {
            get { return _contestant.LastName; }
            set
            {
                _contestant.LastName = value;
                RaisePropertyChangedEvent("ContestantLastName");
            }
        }
        [Required(ErrorMessage = "Waga jest wymagana!")]
        [Range(20,100,ErrorMessage = "Waga przekracza dopuszczalny limit!")]
        public string TxtContestantWeight { get { return _contestant.Weight.ToString(); } set
            {
                if (value != null && !value.Equals(""))
                {
                    _contestant.Weight = Double.Parse(value);
                    RaisePropertyChangedEvent("Weight");
                }
            } }
        [Required(ErrorMessage = "Wzrost jest wymagany!")]
        [Range(50, 200, ErrorMessage = "Wzrost przekracza dopuszczalny limit!")]
        public string TxtContestantHeight { get { return _contestant.Height.ToString(); } set
        {
            if (value != null && !value.Equals(""))
            {
                _contestant.Height = Double.Parse(value);
                RaisePropertyChangedEvent("Height");
            }
        } }

        [Required(ErrorMessage = "Data urodzenia jest wymagana!")]
        public DateTime DtPickerDateOfBirth
        {
            get {
                   _contestant.DateOfBirth = DateTime.Now;
                return 
                    _contestant.DateOfBirth; }
            set
            {
                _contestant.DateOfBirth = value;
                RaisePropertyChangedEvent("DateOfBirth");
            }
        }


        [Required(ErrorMessage = "Proszę wybrać płeć!")]
        public GenderEnum Gender { get { return _contestant.Gender; } set { _contestant.Gender = value; RaisePropertyChangedEvent("Gender"); } }
        public int TournamentId => _contestant.TournamentId;

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

        public ICommand AddNewContestantCommand => new DelegateCommand(AddNewContestant);
        public AddContestantViewModel(int tournamentId)
        {
            _contestant = new Contestant {TournamentId = tournamentId};
        }

        public void AddNewContestant()
        {           
            try
            {
                _contestant.TournamentId = TournamentId;
                //TODO: VALIDATION
                var queryName = (from c in _context.Contestants
                    where c.FirstName.Equals(_contestant.FirstName) && c.LastName.Equals(_contestant.LastName)
                    select c).ToList();
                if (queryName.Count >= 1)
                {
                    OutputMessage = "A contestant with this name already exists in the database!";
                }
                else
                {
                    _context.Contestants.AddOrUpdate(_contestant);
                    _context.SaveChanges();
                    OutputMessage += "\nSuccessfully added a new contestant to the database!\n" +
                                     _contestant.GetContestantDataString();
                }
                MessageBox.Show(OutputMessage);
            }
            catch (Exception e)
            {
                OutputMessage += "\nERROR adding new contestant to database!\nErrormessage = " + e.Message + "\n" + _contestant.GetContestantDataString();
                MessageBox.Show(OutputMessage);
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
            DtPickerDateOfBirth = DateTime.Now;
            _contestant = new Contestant();
            RaisePropertyChangedEvent("Contestant");
            OutputMessage = String.Empty;
        }
    }
}
