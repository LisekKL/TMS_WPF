using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using Tournament_Management_Software.Helpers;


namespace Tournament_Management_Software.ViewModels
{
    public class MainWindowViewModel : ObservableObject
    {
        public ObservableCollection<MenuItem> NavigationMenu { get; set; } = new ObservableCollection<MenuItem>();
        public ObservableCollection<string> ToolbarMenu { get; set; } = new ObservableCollection<string>();
        private object _currentView;
        public object CurrentView { get { return _currentView; }  set { _currentView = value; RaisePropertyChangedEvent("CurrentView"); } }
        public ICommand ShowHomeViewCommand => new DelegateCommand(SetHomeView);
        public ICommand ShowEditViewCommand => new DelegateCommand(SetEditView);
        public ICommand ShowAllContestantsCommand => new DelegateCommand(SetAllContestantsView);
        public ICommand ExploreDatabaseCommand => new DelegateCommand(ExploreDatabase);
        public string Title { get; set; } = "Tournament Management Software";

        public void ExploreDatabase()
        {
            _currentView = new ExploreDatabaseViewModel();
            RaisePropertyChangedEvent("CurrentView");
        }
        public MainWindowViewModel()
        {
            CurrentView = new DefaultViewModel();
        }
        public void SetHomeView()
        {
            _currentView = new DefaultViewModel();
            RaisePropertyChangedEvent("CurrentView");
        }
        public void SetEditView()
        {
            CurrentView = new AddContestantViewModel();
            RaisePropertyChangedEvent("CurrentView");
        }
        public void SetAllContestantsView()
        {
            _currentView = new AllContestantsViewModel();
            RaisePropertyChangedEvent("CurrentView");
        }

    }
}
