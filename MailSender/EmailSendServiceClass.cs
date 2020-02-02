using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Security;
using System.Windows;

namespace MailSender
{
    public class EmailSendServiceClass
    {
        /// <summary>
        /// Метод для отправки электронной почты
        /// </summary>
        /// <param name="from">адрес отправителя</param>
        /// <param name="to">адрес получателя</param>
        /// <param name="message_subject">Тема письма</param>
        /// <param name="message_body">Тело письма</param>
        /// <param name="server_address">Адрес сервера</param>
        /// <param name="server_port">Порт сервера</param>
        /// <param name="userName">Имя отправителя</param>
        /// <param name="securePassword">Пароль отправителя</param>
        public static void SendMail(string from, string to, string message_subject, string message_body, string server_address, int server_port, string userName, SecureString securePassword)
        {
            try
            {
                using (var message = new MailMessage(from, to))
                {
                    message.Subject = message_subject;
                    message.Body = message_body;

                    using (var client = new SmtpClient(server_address, server_port))
                    {
                        client.EnableSsl = true;

                        client.Credentials = new NetworkCredential(userName, securePassword);

                        client.Send(message);

                        InfoWindow infoWindow = new InfoWindow();
                        infoWindow.Show();
                        
                    }
                }
            }
            catch (Exception error)
            {
                ErrorWindow errWnd = new ErrorWindow(error);
                errWnd.Show();

            }
        }
    }
}
       
