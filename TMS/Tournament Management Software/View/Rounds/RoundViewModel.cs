using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tournament_Management_Software.Helpers;
using Tournament_Management_Software.ViewModels.Rounds.Categories;
using Tournament_Management_Software.ViewModels.Rounds.Matches;

namespace Tournament_Management_Software.View.Rounds
{
    public class RoundViewModel : ObservableObject
    {
        private int _tournamentId;
        public ObservableCollection<ButtonItem> ListView { get; set; }
        public RoundViewModel(int tournamentId)
        {
            _tournamentId = tournamentId;
        }

        private object _ageClassView;
        public object AgeClassView { get { return _ageClassView; } set { _ageClassView = value; RaisePropertyChangedEvent("AgeClassView"); } }

        private object _weightClassView;
        public object WeightClassView { get { return _weightClassView; } set { _weightClassView = value; RaisePropertyChangedEvent("WeightClassView"); } }

        private object _currentView;
        public object Current { get { return _currentView; } set { _currentView = value; RaisePropertyChangedEvent("CurrentView"); } }


        public void InitiateListView()
        {
            ListView = new ObservableCollection<ButtonItem>()
            {
                new ButtonItem() {Label = "CATEGORIES", Command = GoToCategoriesCommand},
                new ButtonItem() {Label = "MATCHES",  Command = GoToMatchesCommand}
            };
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
