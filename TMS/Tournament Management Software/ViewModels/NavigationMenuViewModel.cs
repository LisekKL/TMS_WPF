using System.Collections.ObjectModel;
using Tournament_Management_Software.Helpers;
using Tournament_Management_Software.Helpers.Messages;

namespace Tournament_Management_Software.ViewModels
{
    public class NavigationMenuViewModel : ObservableObject
    {
        private ObservableCollection<ButtonItem> _listView;
        public ObservableCollection<ButtonItem> ListView { get { return _listView; } set { _listView = value; RaisePropertyChangedEvent("ListView"); } }
        public string NavigationMenuTitle { get; set; }
        public NavigationMenuViewModel(ChangeListView action)
        {
            _listView = action.Message;
            NavigationMenuTitle = action.Title;
        }
    }
}
