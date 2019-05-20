using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;


namespace Lesson1
{
    static class EmailSendServiceClass
    {
        public static void Send(string email, string password)
        {
            using (MailMessage message = new MailMessage())
            {
                message.From = new MailAddress("kertak@yandex.ru");
                message.To.Add(new MailAddress("dimegrv@yandex.ru"));

                message.Subject = "Пушкин я помню чудное мгновенье!!! =) =) =) =)";
                message.Body = "123";
                message.IsBodyHtml = false;
                for (int i = 0; i < 10; i++)
                {
                    using (SmtpClient client = new SmtpClient("smtp.yandex.ru", 25))
                    {
                        client.EnableSsl = true;                                                //Используем SSL шифрование для соединения                 
                        client.UseDefaultCredentials = false;
                        client.Credentials = new NetworkCredential(email, password);
                        client.DeliveryMethod = SmtpDeliveryMethod.Network;
                        client.Send(message);
                    }
                }

                MessageNotification Notification = new MessageNotification();
                Notification.Show();
            }
        }
    }
}
