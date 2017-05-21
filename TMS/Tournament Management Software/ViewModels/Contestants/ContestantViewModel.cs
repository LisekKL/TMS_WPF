using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;
using Tournament_Management_Software.Helpers;
using Tournament_Management_Software.Helpers.Messages;

namespace Tournament_Management_Software.ViewModels.Contestants
{
    public class ContestantViewModel : ObservableObject
    {
        private readonly int _tournamentId;
        public string ViewTitle { get; set; } = "CONTESTANT VIEW";
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

        public void ShowAllContestants()
        {
            _currentView = new ShowAllContestantsViewModel(_tournamentId);
            RaisePropertyChangedEvent("CurrentView");
        }
        public void AddNewContestant()
        {
            if(_tournamentId != 0)
                 _currentView = new AddContestantViewModel(_tournamentId);
            RaisePropertyChangedEvent("CurrentView");
        }

        public void InitiateListView()
        {
            ListView = new ObservableCollection<ButtonItem>()
            {
                new ButtonItem() {Label = "All contestants", Command = ShowAllContestantsCommand},
                new ButtonItem() {Label = "Add new contestant", Command = AddNewContestantCommand}
            };
            Messenger.Default.Send(new ChangeListView() {Title = "Contestants", Message = ListView});
            RaisePropertyChangedEvent("ListView");
        }
    }
}
