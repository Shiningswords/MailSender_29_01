using System;
using System.Net;
using System.Net.Mail;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            MailMessage msg = new MailMessage("kgudochkin@yandex.ru","kvgudochkin@gmail.com");
            msg.Subject = "Тема сообщения";
            msg.Body = "Тело сообщения";
            msg.IsBodyHtml = false;
            //msg.Attachments.Add(new Attachment("c:\\File.exe"));

            SmtpClient client = new SmtpClient("smtp.yandex.ru",25);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("kgudochkin@yandex.ru", "Password");

            client.Send(msg);
            Console.WriteLine("Письмо отправлено");
            Console.ReadKey();

        }
    }
}
