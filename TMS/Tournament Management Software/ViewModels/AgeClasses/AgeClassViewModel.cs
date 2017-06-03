using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;
using Tournament_Management_Software.Helpers;
using Tournament_Management_Software.Helpers.Messages;
using Tournament_Management_Software.ViewModels.AgeClasses.WeightClasses;

namespace Tournament_Management_Software.ViewModels.AgeClasses
{
    public class AgeClassViewModel : ObservableObject
    {
        private readonly int _tournamentId;
        public string ViewTitle { get; set; } = "AGE CLASS VIEW";
        public AgeClassViewModel(int tournamentId)
        {
            _tournamentId = tournamentId;
            InitiateListView();
        }
        public ObservableCollection<ButtonItem> ListView { get; set; }

        private object _currentView;
        public object CurrentView { get { return _currentView; } set { _currentView = value; RaisePropertyChangedEvent("CurrentView"); } }

        public void InitiateListView()
        {
            ListView = new ObservableCollection<ButtonItem>()
            {
                new ButtonItem() {Label = "All AgeClasses", Command = ShowAllAgeClassesCommand},
                new ButtonItem() {Label = "Add AgeClass", Command = AddAgeClassCommand},
                new ButtonItem() {Label = "Go to WeightClasses", Command = GoToWeightClassesCommand}
            };
            Messenger.Default.Send(new ChangeListView() {NavigationButtonsItems = ListView, NavigationTitle = "AGE CLASSES"});
            RaisePropertyChangedEvent("ListView");
        }

        public ICommand ShowAllAgeClassesCommand => new DelegateCommand(ShowAllAgeClasses);
        public void ShowAllAgeClasses()
        {
            _currentView = new ShowAllAgeClassesViewModel(_tournamentId);
            RaisePropertyChangedEvent("CurrentView");
        }

        public ICommand AddAgeClassCommand => new DelegateCommand(AddAgeClass);
        public void AddAgeClass()
        {
            _currentView = new AddAgeClassViewModel(_tournamentId);
            RaisePropertyChangedEvent("CurrentView");
        }

        public ICommand GoToWeightClassesCommand => new DelegateCommand(GoToWeightClasses);
        public void GoToWeightClasses()
        {
            _currentView = new WeightClassViewModel(_tournamentId);
            RaisePropertyChangedEvent("CurrentView");
        }
    }
}
