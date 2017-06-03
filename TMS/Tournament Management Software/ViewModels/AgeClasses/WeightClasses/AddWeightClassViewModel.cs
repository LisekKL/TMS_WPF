using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;
using Tournament_Management_Software.Helpers;
using Tournament_Management_Software.Helpers.Context;
using Tournament_Management_Software.Helpers.Messages;
using Tournament_Management_Software.Model;

namespace Tournament_Management_Software.ViewModels.AgeClasses.WeightClasses
{
    public class AddWeightClassViewModel : ObservableObject
    {
        private readonly WeightClass _weightClass;
        private readonly TMSContext _context = new TMSContext();

        public AddWeightClassViewModel(int ageClassId)
        {
            _weightClass = new WeightClass() {AgeClassId = ageClassId};
        }
        public string Name { get { return _weightClass.WeightClassName; } set { _weightClass.WeightClassName = value; RaisePropertyChangedEvent("Name"); } }
        [Required(ErrorMessage = "Please supply a valid minimum weight!")]
        [Range(0,100, ErrorMessage = "Minimum weight out of bounds!")]
        public double MinWeight { get { return _weightClass.MinWeight; } set { _weightClass.MinWeight = value; RaisePropertyChangedEvent("MinWeight"); } }
        [Required(ErrorMessage = "Please supply a valid maximum weight!")]
        [Range(0, 100, ErrorMessage = "Maximum weight out of bounds!")]
        public double MaxWeight { get { return _weightClass.MaxWeight; } set { _weightClass.MaxWeight = value; RaisePropertyChangedEvent("MaxWeight"); } }
        
        public ICommand AddWeightClassCommand => new DelegateCommand(AddWeightClass);

        public void AddWeightClass()
        {
            try
            {
                _context.WeightClasses.Add(_weightClass);
                _context.SaveChanges();
                MessageBox.Show("Successfully added new weight class to database!\n"
                                + "Name = " + _weightClass.WeightClassName
                                + "\nID = " + _weightClass.WeightClassId
                                + "\nAgeClass ID = " + _weightClass.AgeClassId
                                + "\nMinimum weight = " + _weightClass.MinWeight
                                + "\nMaximum weight = " + _weightClass.MaxWeight
                );
                Messenger.Default.Send(new ChangeView() {ViewName = "CurrentTournament"});
            }
            catch(Exception e)
            {
                MessageBox.Show("ERROR adding weightclass to database!\n" + e.Message);
                ClearData();
            }
        }

        public void ClearData()
        {
            Name = string.Empty;
            MinWeight = 0;
            MaxWeight = 0;
        }
    }
}
