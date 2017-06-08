using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;
using Tournament_Management_Software.Helpers;
using Tournament_Management_Software.Helpers.Messages;
using Tournament_Management_Software.View.Contestants;

namespace Tournament_Management_Software.ViewModels.Contestants
{
    public class ContestantViewModel : ObservableObject
    {
        private readonly int _tournamentId;
        public string ViewTitle { get; set; } = "CONTESTANT VIEW";
        public string ImagePath => @"C:\Users\Karol\Desktop\TMS WPF\TMS REPO\TMS\Tournament Management Software\Images\tournament background cont.jpg";
        public Visibility ImageVisibility = Visibility.Visible;

        public void InitiateListView()
        {
            ListView = new ObservableCollection<ButtonItem>()
            {
                new ButtonItem() {Label = "All contestants", Command = ShowAllContestantsCommand},
                new ButtonItem() {Label = "Add new contestant", Command = AddNewContestantCommand}
            };
            Messenger.Default.Send(new ChangeListView() { NavigationTitle = "Contestants", NavigationButtonsItems = ListView });
            RaisePropertyChangedEvent("ListView");
        }

        public ContestantViewModel() { }
        public ContestantViewModel(int tournamentId)
        {
            _tournamentId = tournamentId;
            InitiateListView();
        }

        private object _currentView;
        public object CurrentView { get { return _currentView; } set { _currentView = value; RaisePropertyChangedEvent("CurrentView");} }

        public ObservableCollection<ButtonItem> ListView { get; set; }
        public ICommand ShowAllContestantsCommand => new DelegateCommand(ShowAllContestants);
        public ICommand AddNewContestantCommand => new DelegateCommand(AddNewContestant);
        public ICommand ExitCommand => new DelegateCommand(Exit);

        public void ShowAllContestants()
        {
            ImageVisibility = Visibility.Collapsed;
            _currentView = new ShowAllContestantsViewModel(_tournamentId);
            RaisePropertyChangedEvent("CurrentView");
        }
        public void AddNewContestant()
        {
            new AddContestantWindow().Show();
            if (_tournamentId != 0)
            {
                new AddContestantWindow().Show();
            }
            ImageVisibility = Visibility.Collapsed;
            RaisePropertyChangedEvent("CurrentView");
        }

        public void Exit()
        {
            Messenger.Default.Send(new ChangeView() {ViewName = "EXIT"});
        }

    }
}
