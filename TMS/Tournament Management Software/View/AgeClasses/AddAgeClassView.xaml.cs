using System.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;
using Tournament_Management_Software.Helpers.Messages;
using Tournament_Management_Software.ViewModels.AgeClasses;

namespace Tournament_Management_Software.View.AgeClasses
{
    /// <summary>
    /// Interaction logic for AddAgeClassView.xaml
    /// </summary>
    public partial class AddAgeClassView : UserControl
    {
        public AddAgeClassView()
        {
            Messenger.Default.Register<ActiveTournamentId>(this, SetDataContext);
            InitializeComponent();
        }

        public void SetDataContext(ActiveTournamentId action)
        {
            DataContext = new AddAgeClassViewModel(action.Message);
        }
    }
}
