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

namespace homework1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class WpfMailSender : Window
    {
        public WpfMailSender()
        {
            InitializeComponent();
            EmailSendServiceClass.Form = this;
        }

        private void btnSendEmail_Click(object sender, RoutedEventArgs e)
        {
            List<string> listStrMails = EmailSendServiceClass.FormListStrMails();
              
            foreach (string mail in listStrMails)
            {
                // Используем using, чтобы гарантированно удалить объект MailMessage после использования
                using (MailMessage mm = new MailMessage("roshupkin.ilya2012@yandex.ru", mail))
                {
                    EmailSendServiceClass.FormMessage(mm);
                    using (SmtpClient sc = new SmtpClient(ConnectionData.smtpServer, ConnectionData.smtpPort))
                    {
                        EmailSendServiceClass.FormClient(sc,passwordBox.Password);
                        try
                        {
                            sc.Send(mm);
                        }
                        catch (Exception ex)
                        {
                            SendErrorWindow serror = new SendErrorWindow(ex.Message);
                            serror.ShowDialog();
                        }
                    }
                } //using (MailMessage mm = new MailMessage("roshupkin.ilya2012@yandex.ru", mail))
            }
            SendEndWindow sew = new SendEndWindow();
            sew.ShowDialog();
        }
    }
}
