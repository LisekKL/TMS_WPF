using System.Collections.ObjectModel;

namespace Tournament_Management_Software.Helpers.Messages
{
    public class ChangeListView
    {
        public ObservableCollection<ButtonItem> NavigationButtonsItems { get; set; }
        public string NavigationTitle { get; set; }
    }
}
