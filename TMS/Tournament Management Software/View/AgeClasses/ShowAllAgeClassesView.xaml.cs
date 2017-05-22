using System.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;
using Tournament_Management_Software.Helpers.Messages;
using Tournament_Management_Software.ViewModels.AgeClasses;

namespace Tournament_Management_Software.View.AgeClasses
{
    /// <summary>
    /// Interaction logic for ShowAllAgeClassesView.xaml
    /// </summary>
    public partial class ShowAllAgeClassesView : UserControl
    {
        public ShowAllAgeClassesView()
        {
            InitializeComponent();
            Messenger.Default.Register<ActiveTournamentId>(this, SetDataContext);
        }

        public void SetDataContext(ActiveTournamentId action)
        {
            DataContext = new ShowAllAgeClassesViewModel(action.Message);
        }           
    }
}
