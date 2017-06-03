using System;
using System.Linq;
using System.Windows.Input;
using Tournament_Management_Software.Helpers;
using Tournament_Management_Software.Helpers.Context;
using Tournament_Management_Software.Model;

namespace Tournament_Management_Software.ViewModels.AgeClasses
{
    public class AddAgeClassViewModel : ObservableObject
    {
        private readonly AgeClass _ageClass;
        private readonly TMSContext _context = new TMSContext();
        public string OutputMessage { get; set; } = "";

        public AddAgeClassViewModel(int tournamentId)
        {
            _ageClass = new AgeClass() {TournamentId = tournamentId};
        }

        public string TxtName
        {
            get { return _ageClass.AgeClassName; }
            set
            {
                _ageClass.AgeClassName = value;
                RaisePropertyChangedEvent("TxtName");
            }
        }

        public int MaxYear
        {
            get { return _ageClass.MaxYear; }
            set
            {
                _ageClass.MaxYear = value;
                RaisePropertyChangedEvent("MaxYear");
            }
        }

        public int MinYear
        {
            get { return _ageClass.MinYear; }
            set
            {
                _ageClass.MinYear = value;
                RaisePropertyChangedEvent("MinYear");
            }
        }

        public int TournamentId => _ageClass.TournamentId;

        public ICommand AddAgeClassCommand => new DelegateCommand(AddAgeClass);

        public void AddAgeClass()
        {
            _context.AgeClasses.Add(_ageClass);
        }

        public int PerformDataValidation()
        {
            if (MinYear <= 2000)
            {
                
            }
            return 0;
        }



    }
}
