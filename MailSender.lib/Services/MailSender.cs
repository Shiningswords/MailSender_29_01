using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.Diagnostics;

namespace MailSender.lib.Services
{
    public class MailSender
    {
        private readonly string _ServerAddress;
        private readonly int _Port;
        private bool _UseSsl;
        private string _Login;
        private string _Password;
        public MailSender(string ServerAddress, int Port, bool UseSsl, string Login, string Password)
        {
            _ServerAddress = ServerAddress;
            _Port = Port;
            _UseSsl = UseSsl;
            _Login = Login;
            _Password = Password;

        }
        public void Send(string Subject, string Body, string From, string To)
        {
            using(var message = new MailMessage(From, To))
            {
                message.Subject = Subject;
                message.Body = Body;
                var login = new NetworkCredential(_Login, _Password);
                using (var client = new SmtpClient(_ServerAddress, _Port) { EnableSsl = _UseSsl, Credentials = login })
                {
                    client.Send(message);
                }

            }
        }
    }
    public class DebugMailSender
    {
        private readonly string _ServerAddress;
        private readonly int _Port;
        private bool _UseSsl;
        private string _Login;
        private string _Password;
        public DebugMailSender(string ServerAddress, int Port, bool UseSsl, string Login, string Password)
        {
            _ServerAddress = ServerAddress;
            _Port = Port;
            _UseSsl = UseSsl;
            _Login = Login;
            _Password = Password;

        }
        public void Send(string Subject, string Body, string From, string To)
        {
            Debug.WriteLine($"Отправка почты от {From} к {To} через {_ServerAddress}:{_Port}[Использвание SSL:{_UseSsl}] \r\n{Subject}:{Body}");
        }
    }
}
