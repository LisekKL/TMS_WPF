using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tournament_Management_Software.Helpers;
using Tournament_Management_Software.Helpers.Context;
using Tournament_Management_Software.Helpers.Enums;
using Tournament_Management_Software.Model;
using static System.Double;

namespace Tournament_Management_Software.ViewModels
{
    public class AddContestantViewModel : ObservableObject
    {
        private readonly Contestant _contestant = new Contestant();
        private object _loggerWindow;
        public object LoggerWindow { get { return _loggerWindow; } set { _loggerWindow = value; RaisePropertyChangedEvent("LoggerWindow"); } }

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

        public string OutputMessage { get; set; } = "Logger";
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
        public void AddNewContestant()
        {
            try
            {
                TMSContext context = new TMSContext();
                //TODO: VALIDATION
                context.Contestants.AddOrUpdate(_contestant);
                context.SaveChanges();
                OutputMessage += "\nSuccessfully added a new contestant to the database!\n";
                RaisePropertyChangedEvent("OutputMessage");
                OutputMessage += _contestant.GetContestantDataString();
                RaisePropertyChangedEvent("OutputMessage");

            }
            catch (Exception e)
            {
                OutputMessage += "\nERROR adding new contestant to database!\nErrormessage = " + e.Message + "\n";
                RaisePropertyChangedEvent("OutputMessage");
                OutputMessage += _contestant.GetContestantDataString();
                RaisePropertyChangedEvent("OutputMessage");
            }
            
        }

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

       // public DateTime DtPickerDateOfBirth { get { return _contestant.DateOfBirth; } set { _contestant.DateOfBirth = value; RaisePropertyChangedEvent("DateOfBirth"); } }

        //public string TxtGender
        //{
        //    get { return _contestant.Gender.ToString(); }
        //    set { _contestant.Gender = value.Equals("M") ? GenderEnum.Male : GenderEnum.Female; }
        //}
        public string LblGenderMale => "Male";
        public string LblGenderFemale => "Female";
    }
}
