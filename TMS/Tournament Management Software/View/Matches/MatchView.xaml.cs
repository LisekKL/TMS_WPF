using System.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;
using Tournament_Management_Software.Helpers.Messages;
using Tournament_Management_Software.ViewModels.Matches;

namespace Tournament_Management_Software.View.Matches
{
    /// <summary>
    /// Interaction logic for MatchView.xaml
    /// </summary>
    public partial class MatchView : UserControl
    {
        public MatchView()
        {
            Messenger.Default.Register<ActiveTournamentId>(this,SetDataContext);
            InitializeComponent();       
        }

        public void SetDataContext(ActiveTournamentId action)
        {
            DataContext = new MatchViewModel(action.Message);
        }
    }
}
