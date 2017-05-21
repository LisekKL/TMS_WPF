using System.Collections.ObjectModel;

namespace Tournament_Management_Software.Helpers.Messages
{
    public class ChangeListView
    {
        public ObservableCollection<ButtonItem> Message { get; set; }
        public string Title { get; set; }
    }
}
