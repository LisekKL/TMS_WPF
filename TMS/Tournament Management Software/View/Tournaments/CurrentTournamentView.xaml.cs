using System.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;
using Tournament_Management_Software.Helpers.Messages;
using Tournament_Management_Software.ViewModels.Tournaments;

namespace Tournament_Management_Software.View.Tournaments
{
    /// <summary>
    /// Interaction logic for CurrentTournamentView.xaml
    /// </summary>
    public partial class CurrentTournamentView : UserControl
    {
        public CurrentTournamentView()
        {
            Messenger.Default.Register<ActiveTournamentId>(this, SetDataContext);
            InitializeComponent();
        }

        public void SetDataContext(ActiveTournamentId activeTournamentId)
        {
            DataContext = new CurrentTournamentViewModel(activeTournamentId.Message);
        }
    }
}
