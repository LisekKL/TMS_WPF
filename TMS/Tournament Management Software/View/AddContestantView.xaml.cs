﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GalaSoft.MvvmLight.Messaging;
using Tournament_Management_Software.Helpers;

namespace Tournament_Management_Software.View
{
    /// <summary>
    /// Interaction logic for ContestantEditView.xaml
    /// </summary>
    public partial class AddContestantView : UserControl
    {
        public AddContestantView()
        {
            Messenger.Default.Register<ActiveTournamentId>(this, DoNothing);
            InitializeComponent();           
        }
        public void DoNothing(ActiveTournamentId action) { }

    }
}
