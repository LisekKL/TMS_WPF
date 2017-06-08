using System.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;
using Tournament_Management_Software.Helpers.Messages;
using Tournament_Management_Software.ViewModels.Contestants;

namespace Tournament_Management_Software.View.Contestants
{
    /// <summary>
    /// Interaction logic for AllUsersView.xaml
    /// </summary>
    public partial class ShowAllContestantsView : UserControl
    {
        public ShowAllContestantsView()
        {
            Messenger.Default.Register<ActiveTournamentId>(this,  SetDataContext);
            InitializeComponent();
        }

        public void SetDataContext(ActiveTournamentId action)
        {
            DataContext = new ShowAllContestantsViewModel(action.Message);
        }
    }
}
