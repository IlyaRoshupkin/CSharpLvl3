using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MailSender
{
    /// <summary>
    /// Interaction logic for SendErrorWindow.xaml
    /// </summary>
    public partial class SendErrorWindow : Window
    {

        public SendErrorWindow(Exception ex)
        {
            InitializeComponent();
            tbDescryption.Text = ex.Message;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
