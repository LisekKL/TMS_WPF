using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;
using Tournament_Management_Software.Helpers;
using Tournament_Management_Software.Helpers.Messages;

namespace Tournament_Management_Software.ViewModels.AgeClasses.WeightClasses
{
    public class WeightClassViewModel : ObservableObject
    {
        private int _ageClassId;
        public string ViewTitle { get; set; } = "WEIGHT CLASS VIEW";
        public ObservableCollection<ButtonItem> ListView { get; set; }
        public WeightClassViewModel(int ageClassId)
        {
            _ageClassId = ageClassId;
        }

        public void InitiateListView()
        {
            ListView = new ObservableCollection<ButtonItem>()
            {
                new ButtonItem() {Label = "New WeightClass", Command = AddWeightClassCommand},
                new ButtonItem() {Label = "Show all weightclasses", Command = ShowAllWeightClassesCommand}
            };
            Messenger.Default.Send(new ChangeListView() {Message = ListView, Title = "WEIGHTCLASSES"});
        }
        public ICommand AddWeightClassCommand => new DelegateCommand(AddWeightClass);

        public void AddWeightClass()
        {
            
        }
        public ICommand ShowAllWeightClassesCommand => new DelegateCommand(ShowAllWeightClasses);

        public void ShowAllWeightClasses()
        {
            
        }
    }
}
