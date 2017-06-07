using System.Windows;
using Tournament_Management_Software.ViewModels.Tournaments;

namespace Tournament_Management_Software.View.Tournaments
{
    /// <summary>
    /// Interaction logic for AddTournamentWindow.xaml
    /// </summary>
    public partial class AddTournamentWindow : Window
    {
        public AddTournamentWindow()
        {
            DataContext = new AddTournamentViewModel();
            InitializeComponent();
        }
    }
}
