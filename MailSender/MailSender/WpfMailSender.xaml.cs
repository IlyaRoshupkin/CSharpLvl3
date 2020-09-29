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

        //private void btnSendEmail_Click(object sender, RoutedEventArgs e)
        //{
        //    SmtpData.from = tbFrom.Text;
        //    SmtpData.to = tbTo.Text;
        //    SmtpData.subject = tbSubject.Text;
        //    SmtpData.smtpServer = tbSmptServer.Text;
        //    SmtpData.smtpPort = Convert.ToInt32(tbSmptPort.Text);
        //    SmtpData.userName = tbUserName.Text;
        //    SmtpData.password = passwordBox.Password;
        //    SmtpData.message = tbMessage.Text;
        //    EmailSendServiceClass essc = new EmailSendServiceClass();
        //    SendEndWindow sew = new SendEndWindow();
        //    sew.ShowDialog();
        //}

        private void miExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
