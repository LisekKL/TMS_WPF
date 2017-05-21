using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;
using Tournament_Management_Software.Helpers;
using Tournament_Management_Software.Helpers.Messages;
using Tournament_Management_Software.ViewModels.Categories.AgeClasses;
using Tournament_Management_Software.ViewModels.Categories.WeightClasses;

namespace Tournament_Management_Software.ViewModels.Rounds.Categories
{
    public class CategoryViewModel : ObservableObject
    {
        private int _tournamentId;
        private object _currentView;
        public object CurrentView { get { return _currentView; } set { _currentView = value; RaisePropertyChangedEvent("CurrentView"); } }
        public CategoryViewModel(int tournamentId)
        {
            _tournamentId = tournamentId;
            InitiateListView();
        }

        public ObservableCollection<ButtonItem> ListView { get; set; }

        public void InitiateListView()
        {
            ListView = new ObservableCollection<ButtonItem>()
            {
                new ButtonItem() {Label = "AgeClasses", Command = GoToAgeClassesCommand}
               // new ButtonItem() {Label = "WeightClasses", Command = GoToWeightClassesCommand}
            };
            Messenger.Default.Send(new ChangeListView() {Message = ListView});
            //RaisePropertyChangedEvent("ListView");
        }

        public ICommand GoToAgeClassesCommand => new DelegateCommand(GoToAgeClasses);
        public void GoToAgeClasses()
        {
           _currentView = new AgeClassViewModel();
            RaisePropertyChangedEvent("CurrentView");
        }

        //public ICommand GoToWeightClassesCommand => new DelegateCommand(GoToWeightClasses);

        //public void GoToWeightClasses()
        //{
        //    _currentView = new WeightClassViewModel();
        //    RaisePropertyChangedEvent("CurrentView");
        //}
    }
}
