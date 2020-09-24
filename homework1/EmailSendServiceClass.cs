using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace homework1
{
    public class EmailSendServiceClass
    {
        internal static WpfMailSender Form;

        public static void FormMessage(MailMessage mm)
        {
            // Формируем письмо
            mm.Subject = Form.tbMesTitle.Text;
            mm.Body = Form.tbMesText.Text;
            mm.IsBodyHtml = false;
        }

        public static void FormClient(SmtpClient sc,string strPassword)
        {
            sc.EnableSsl = true;
            sc.Credentials = new NetworkCredential("roshupkin.ilya2012@yandex.ru", strPassword);
        }

        internal static List<string> FormListStrMails()
        {
            return new List<string> {
                "roshupkin.ilya@gmail.com", "roshupkin.ilya2012@yandex.ru" };
        }

        //        List<string> listStrMails = new List<string> {
        //                "roshupkin.ilya@gmail.com", "roshupkin.ilya2012@yandex.ru" };  // Список email'ов 
        //                                                                               //кому мы отправляем письмо
        //        string strPassword = passwordBox.Password;  
        //            foreach (string mail in listStrMails)
        //            {
        //                // Используем using, чтобы гарантированно удалить объект MailMessage после использования
        //                using (MailMessage mm = new MailMessage("roshupkin.ilya2012@yandex.ru", mail))
        //                {
        //                    
        //                    using (SmtpClient sc = new SmtpClient(ConnectionData.smtpServer, ConnectionData.smtpPort))
        //                    {
        //                        sc.EnableSsl = true;
        //                        sc.Credentials = new NetworkCredential("roshupkin.ilya2012@yandex.ru", strPassword);
        //                        try
        //                        {
        //                            sc.Send(mm);
        //                        }
        //                        catch (Exception ex)
        //                        {
        //                            MessageBox.Show("Невозможно отправить письмо " + ex.ToString());
        //                        }
        //                    }
        //                } //using (MailMessage mm = new MailMessage("roshupkin.ilya2012@yandex.ru", mail))
        //            }
        //            SendEndWindow sew = new SendEndWindow();
        //sew.ShowDialog();

    }
}
