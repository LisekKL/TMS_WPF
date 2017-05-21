using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;
using Tournament_Management_Software.Helpers;
using Tournament_Management_Software.Helpers.Messages;
using Tournament_Management_Software.ViewModels.Categories;
using Tournament_Management_Software.ViewModels.Rounds.Categories;
using Tournament_Management_Software.ViewModels.Rounds.Matches;

namespace Tournament_Management_Software.ViewModels.Rounds
{
    public class RoundViewModel : ObservableObject
    {
        private int _tournamentId;
        public RoundViewModel(int tournamentId)
        {
            _tournamentId = tournamentId;
        }
        public ObservableCollection<ButtonItem> ListView { get; set; }

        public string ViewTitle { get; set; } = "ROUND VIEW";

        private object _currentView;
        public object CurrentView { get { return _currentView; } set { _currentView = value; RaisePropertyChangedEvent("CurrentView"); } }

        public void InitiateListView()
        {
            ListView = new ObservableCollection<ButtonItem>()
            {
                new ButtonItem() {Label = "CATEGORIES", Command = GoToCategoriesCommand},
                new ButtonItem() {Label = "MATCHES", Command = GoToMatchesCommand}
            };
            Messenger.Default.Send(new ChangeListView() {Message = ListView, Title = "ROUND"});
        }

        public ICommand GoToCategoriesCommand => new DelegateCommand(GoToCategories);
        public void GoToCategories()
        {
            _currentView = new CategoryViewModel(_tournamentId);
            RaisePropertyChangedEvent("CurrentView");
        }

        public ICommand GoToMatchesCommand => new DelegateCommand(GoToMatches);
        public void GoToMatches()
        {
            _currentView = new MatchViewModel(_tournamentId);
            RaisePropertyChangedEvent("CurrentView");
        }
    }
}
