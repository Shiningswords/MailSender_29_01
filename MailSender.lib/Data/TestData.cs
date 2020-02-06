using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender.lib.Entities;
using MailSender.lib.Service;

namespace MailSender.lib.Data
{
    public static class TestData
    {
        /*
        public static List<Server> Servers { get; } = new List<Server>
        {
            new Server{Name = "Яндекс", Address="smtp.yandex.ru", Port=587, Login="UserName", Password="Password".Encode(3)},
            new Server{Name = "Mail.ru", Address="smtp.mail.ru", Port=587, Login="UserName", Password="Password".Encode(3)},
            new Server{Name = "GMail", Address="smtp.gmail.com", Port=587, Login="UserName", Password="Password".Encode(3)}
        };
        */

        public static List<Sender> Senders { get; } = new List<Sender>
        {
            new Sender{Id=0,Name = "Иванов", Address="ivanov@server.ru"},
            new Sender{Id=1,Name = "Петров", Address="petrov@server.ru"},
            new Sender{Id=2,Name = "Сидоров", Address="sidorov@server.ru"}
        };
        public static List<Recipient> Recipients { get; } = new List<Recipient>
        {
            new Recipient{Id=0,Name = "Иванов", Address="ivanov@server.ru"},
            new Recipient{Id=1,Name = "Петров", Address="petrov@server.ru"},
            new Recipient{Id=2,Name = "Сидоров", Address="sidorov@server.ru"}
        };
        public static Dictionary<string, int> Servers
        {
            get { return dicServers; }
        }
        private static Dictionary<string, int> dicServers = new Dictionary<string, int>()
        {
            { "smtp.yandex.ru",587 },
            { "smtp.mail.ru",587 },
            { "smtp.gmail.com",587 }
        };
    }
}
