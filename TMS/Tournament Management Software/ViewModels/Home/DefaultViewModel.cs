using System;
using System.CodeDom;
using System.Collections.ObjectModel;
using System.IO;
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
        public string ImagePath =>
            @"C:\Users\Karol\Desktop\TMS WPF\TMS REPO\TMS\Tournament Management Software\Images\judo-banner.jpg";
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
                new ButtonItem() {Label = "Home", Command = GoHomeCommand},
                new ButtonItem() {Label = "Tournaments", Command = GoToTournamentsCommand}, 
                new ButtonItem() {Label = "Contestants", Command = GoToContestantsCommand },
                new ButtonItem() {Label = "Exit", Command = ExitCommand}
            };
            RaisePropertyChangedEvent("ListView");
            Messenger.Default.Send(new ChangeListView() {NavigationButtonsItems = ListView, NavigationTitle = "MAIN MENU"});
        }

        public ICommand GoHomeCommand => new DelegateCommand(GoHome);
        public ICommand GoToTournamentsCommand => new DelegateCommand(GoToTournaments);
        public ICommand GoToContestantsCommand => new DelegateCommand(GoToContestants);
        public ICommand GoToManualCommand => new DelegateCommand(GoToManual);
        public ICommand ExitCommand => new DelegateCommand(Exit);

        public void GoHome()
        {
            Messenger.Default.Send(new ChangeView() { ViewName = "Home" });
        }
        public void GoToContestants()
        {
            Messenger.Default.Send(new ChangeView() {ViewName = "Contestants"});
        }
        public void GoToTournaments()
        {
            Messenger.Default.Send(new ChangeView() { ViewName = "Tournaments" });
        }
        public void Exit()
        {
            if (MessageBox.Show("Are you sure you want to exit the application?", "Question", MessageBoxButton.YesNo,
                    MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        public void GoToManual()
        {
           // throw new NotImplementedException();
        }
            
    }
}
