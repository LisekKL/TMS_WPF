using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;
using Tournament_Management_Software.Helpers;
using Tournament_Management_Software.Helpers.Messages;

namespace Tournament_Management_Software.ViewModels.Categories
{
    public class CategoriesViewModel : ObservableObject
    {
        private int _tournamentId;
        public CategoriesViewModel(int tournamentId)
        {
            _tournamentId = tournamentId;
        }

        public ObservableCollection<ButtonItem> ListView { get; set; }

        public void InitiateListView()
        {
            ListView.Add(new ButtonItem() {Label = "AgeClasses", Command = GoToAgeClassesCommand});
            ListView.Add(new ButtonItem() { Label = "WeightClasses"});
            Messenger.Default.Send(new ChangeListView() {Message = ListView});
        }

        public ICommand GoToAgeClassesCommand => new DelegateCommand(GoToAgeClasses);

        public void GoToAgeClasses()
        {
            
        }
    }
}
