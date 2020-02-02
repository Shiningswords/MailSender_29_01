using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Net;
using System.Net.Mail;
using System.Security;

namespace MailSender
{
    /// <summary>
    /// Логика взаимодействия для WpfMailSender.xaml
    /// </summary>
    public partial class WpfMailSender : Window
    {
        public WpfMailSender()
        {
            InitializeComponent();
        }
        private void OnSendButtonClick(object sender, RoutedEventArgs e)
        {
            EmailSendServiceClass.SendMail(MailInfo.from, MailInfo.to, Head.Text, Body.Text, 
                MailInfo.server_address, MailInfo.server_port, UserNameEdit.Text, PasswordEdit.SecurePassword);
        }
    }
}
