﻿using System.Windows;

namespace MailSender
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class WpfMailSender : Window
    {
        public WpfMailSender()
        {
            InitializeComponent();
        }

        private void btnGoToPlan_Click(object sender, RoutedEventArgs e)
        {
            planner.IsSelected = true;
        }

        private void miExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
