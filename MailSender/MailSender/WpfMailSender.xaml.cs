using MailSender.Data;
using MailSender.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
using MailSender.lib;

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

        private void btnSendEmail_Click(object sender, RoutedEventArgs e)
        {
            //SmtpData.from = tbFrom.Text;
            //SmtpData.to = tbTo.Text;
            //SmtpData.subject = tbSubject.Text;
            //SmtpData.smtpServer = tbSmptServer.Text;
            //SmtpData.smtpPort = Convert.ToInt32(tbSmptPort.Text);
            //SmtpData.userName = tbUserName.Text;
            //SmtpData.password = passwordBox.Password;
            //SmtpData.message = tbMessage.Text;
            //EmailSendServiceClass essc = new EmailSendServiceClass();
            //SendEndWindow sew = new SendEndWindow();
            //sew.ShowDialog();
        }

        private void miExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnSend_Click(object _sender, RoutedEventArgs e)
        {
            if (!(SendersList.SelectedItem is Sender sender)) return;
            if (!(RecipientsList.SelectedItem is Recipient recipient)) return;
            if (!(ServersList.SelectedItem is Server server)) return;
            if (!(MessagesList.SelectedItem is Message message)) return;

            var send_service = new MailSenderService
            {
                ServerAddress = server.Address,
                ServerPort = server.Port,
                UseSSL = server.UseSSL,
                Login = server.Login,
                Password = server.Password
            };

            try
            {
                send_service.SendMessage(sender.Address, recipient.Address,
                    message.Subject, message.Body);
            }
            catch (SmtpException error)
            {
                MessageBox.Show("Error during the mail`s sending " + error.Message, "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
