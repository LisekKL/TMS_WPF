using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;
using Tournament_Management_Software.Helpers;
using Tournament_Management_Software.Helpers.Context;
using Tournament_Management_Software.Helpers.Messages;


namespace Tournament_Management_Software.ViewModels.AgeClasses.WeightClasses
{
    public class WeightClassViewModel : ObservableObject
    {
        private readonly int _ageClassId;
        private readonly TMSContext _context = new TMSContext();
        public string ViewTitle { get; set; } = "WEIGHT CLASS VIEW";
        public ObservableCollection<ButtonItem> ListView { get; set; }

        private object _currentView;
        public object CurrentView { get { return _currentView; } set { _currentView = value; RaisePropertyChangedEvent("CurrentView"); } }

        public WeightClassViewModel() { }
        public WeightClassViewModel(int ageClassId)
        {
            _ageClassId = ageClassId;
            InitiateListView();
        }

        public void InitiateListView()
        {
            ListView = new ObservableCollection<ButtonItem>()
            {
                new ButtonItem() {Label = "Home", Command = GoHomeCommand},
                new ButtonItem() {Label = "New Weight Class", Command = AddWeightClassCommand},
                new ButtonItem() {Label = "All Weight Classes", Command = ShowAllWeightClassesCommand},
                new ButtonItem() {Label = "Exit", Command = ExitCommand}
            };
            Messenger.Default.Send(new ChangeListView() {NavigationButtonsItems = ListView, NavigationTitle = "WEIGHTCLASSES"});
        }

        public ICommand GoHomeCommand => new DelegateCommand(GoHome);
        public ICommand AddWeightClassCommand => new DelegateCommand(AddWeightClass);
        public ICommand ExitCommand => new DelegateCommand(Exit);
        public ICommand ShowAllWeightClassesCommand => new DelegateCommand(ShowAllWeightClasses);

        public void AddWeightClass()
        {
            _currentView = new AddWeightClassViewModel(_ageClassId);
            RaisePropertyChangedEvent("CurrentView");
        }
        public void Exit()
        {
            if (MessageBox.Show("Are you sure you want to exit the application?", "Question", MessageBoxButton.YesNo,
                    MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }
        public void GoHome()
        {
            Messenger.Default.Send(new ChangeView() { ViewName = "Home" });
        }

        public void ShowAllWeightClasses()
        {

        }
    }
}
