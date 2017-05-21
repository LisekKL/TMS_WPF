using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;
using Tournament_Management_Software.Helpers;
using Tournament_Management_Software.Helpers.Messages;
using Tournament_Management_Software.ViewModels.Tournaments;

namespace Tournament_Management_Software.ViewModels.Home
{
    public class DefaultViewModel : ObservableObject
    {
        public string ViewTitle { get; set; } = "DEFAULT VIEW";
        public ObservableCollection<ButtonItem> ListView { get; set; }
        public string ListViewTitle { get; set; } = "HOME MENU";

        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                RaisePropertyChangedEvent("CurrentView");
            }
        }

        public DefaultViewModel()
        {
            InitiateListView();
            // _currentView = new ShowAllTournamentsViewModel();
            //  RaisePropertyChangedEvent("ListView");
        }

        public void InitiateListView()
        {
            ListView = new ObservableCollection<ButtonItem>()
            {
                new ButtonItem() {Label = "Home"},
                new ButtonItem() {Label = "Exit"}
            };
            RaisePropertyChangedEvent("ListView");
            Messenger.Default.Send(new ChangeListView() {Message = ListView, Title = "MAIN MENU"});
        }
    }
}
