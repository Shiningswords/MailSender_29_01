using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.Diagnostics;
using System.Threading;
using MailSender.lib.Entities;

namespace MailSender.lib.Services
{
    public class MailSender
    {
        private readonly Server _Server;

        public MailSender(Server Server) => _Server = Server;

        public void Send(Mail Mail, Sender From, Recipient To)
        {
            using (var message = new MailMessage(new MailAddress(From.Address, From.Name), new MailAddress(To.Address, To.Name)))
            {
                message.Subject = Mail.Subject;
                message.Body = Mail.Body;

                var login = new NetworkCredential(_Server.Login, _Server.Password);
                using (var client = new SmtpClient(_Server.Address, _Server.Port) { EnableSsl = _Server.UseSsl, Credentials = login })
                    client.Send(message);
            }
        }

        public void Send(Mail Message, Sender From, IEnumerable<Recipient> To)
        {
            foreach (var recipient in To)
                Send(Message, From, recipient);
        }

        public void SendParallel(Mail Message, Sender From, IEnumerable<Recipient> To)
        {
            foreach (var recipient in To)
                ThreadPool.QueueUserWorkItem(_ => Send(Message, From, recipient));
        }
        public async Task SendAsync(Mail Mail, Sender From, Recipient To)
        {
            using (var message = new MailMessage(new MailAddress(From.Address, From.Name), new MailAddress(To.Address, To.Name)))
            {
                message.Subject = Mail.Subject;
                message.Body = Mail.Body;

                var login = new NetworkCredential(_Server.Login, _Server.Password);
                using (var client = new SmtpClient(_Server.Address, _Server.Port) { EnableSsl = _Server.UseSsl, Credentials = login })
                    //client.Send(message);
                    await client.SendMailAsync(message).ConfigureAwait(false);
            }
        }
        //public async Task SendAsync(Mail Message, Sender From, IEnumerable<Recipient> To)
        //{
        //    await Task.WhenAll(To.Select(to => SendAsync(Message, From, to))).ConfigureAwait(false);
        //}

        public async Task SendAsync(Mail Message, Sender From, IEnumerable<Recipient> To, CancellationToken Cancel = default)
        {
            foreach (var recipient in To)
            {
                Cancel.ThrowIfCancellationRequested();
                await SendAsync(Message, From, recipient).ConfigureAwait(false);
            }
        }
    }
}

