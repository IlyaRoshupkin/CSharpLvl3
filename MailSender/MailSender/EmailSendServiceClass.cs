using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace MailSender
{
    public class EmailSendServiceClass
    {
        public EmailSendServiceClass()
        {
            Send();
        }
        void Send()
        {
            using (MailMessage mm = new MailMessage(SmtpData.from, SmtpData.to))
            {
                // Формируем письмо
                mm.Subject = SmtpData.subject; 
                mm.Body = SmtpData.message; 
                mm.IsBodyHtml = false; 
                using (SmtpClient sc = new SmtpClient(SmtpData.smtpServer, SmtpData.smtpPort))
                {
                    sc.EnableSsl = true;
                    sc.Credentials = new NetworkCredential(SmtpData.userName,
                    SmtpData.password);
                    try
                    {
                        sc.Send(mm);
                    }
                    catch (Exception ex)
                    {
                        SendErrorWindow sendErrorWindow = new SendErrorWindow(ex);
                        sendErrorWindow.ShowDialog();
                    }
                }
            }
        }
        }
    }

