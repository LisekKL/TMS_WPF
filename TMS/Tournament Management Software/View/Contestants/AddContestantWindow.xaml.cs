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
using System.Windows.Shapes;
using GalaSoft.MvvmLight.Messaging;
using Tournament_Management_Software.Helpers.Messages;
using Tournament_Management_Software.ViewModels.Contestants;

namespace Tournament_Management_Software.View.Contestants
{
    /// <summary>
    /// Interaction logic for AddContestantWindow.xaml
    /// </summary>
    public partial class AddContestantWindow : Window
    {
        public AddContestantWindow()
        {
            
            InitializeComponent();
            DataContext = new AddContestantViewModel(1);
        }

    }
}
