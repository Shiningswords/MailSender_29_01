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
using MailSender.lib.Data;
using MailSender.lib.Entities;
using MailSender.lib.Service;
using MailSender.lib.Services;

namespace TestWPF2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnSendButtonClick(object Sender, RoutedEventArgs E)
        {
            var recipient = RecipientsList.SelectedItem as Recipient;
            var sender = SendersList.SelectedItem as Sender;
            var server = ServersList.SelectedItem as Server;

            if (recipient is null || server is null || sender is null) return;

            var mail_sender = new MailSender.lib.Services.DebugMailSender(server.Address, server.Port, server.UseSsl, server.Login, server.Password.Decode(3));

            mail_sender.Send(MailHeader.Text, MailBody.Text, sender.Address, recipient.Address);
        }

        private void OnSenderEditClick(object Sender, RoutedEventArgs E)
        {
            var sender = SendersList.SelectedItem as Sender;
            if (sender is null) return;

            var dialog = new SenderEditor(sender, this);

            if (dialog.ShowDialog() != true) return;

            sender.Name = dialog.NameValue;
            sender.Address = dialog.AddressValue;
        }
    }
}
