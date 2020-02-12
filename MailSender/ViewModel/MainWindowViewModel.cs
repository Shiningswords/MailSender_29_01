using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using MailSender.lib.Services;
using MailSender.lib.Entities;
using MailSender.lib.MVVM;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using MailSender.lib.Services.Interfaces;
using MailSender.Infrastructure.Services.Interfaces;


namespace MailSender.ViewModel
{
    public class MainWindowViewModel: ViewModelBase
    {
        private readonly IRecipientsManager _RecipientsManager;
        private readonly ISendersStore _SendersStore;
        private readonly IServersStore _ServersStore;
        private readonly IMailsStore _MailsStore;

        private readonly ISenderEditor _SenderEditor;


        private string _Title = "Рассыльщик почты";
        public string Title
        {
            get => _Title;
            set => _Title = value;
        }
        private ObservableCollection<Recipient> _Recipients;

        public ObservableCollection<Recipient> Recipients
        {
            get => _Recipients;
            set => Set(ref _Recipients, value);
        }
        private ObservableCollection<Sender> _Senders;

        public ObservableCollection<Sender> Senders
        {
            get => _Senders;
            private set => Set(ref _Senders, value);
        }

        private ObservableCollection<Server> _Servers;

        public ObservableCollection<Server> Servers
        {
            get => _Servers;
            private set => Set(ref _Servers, value);
        }

        private ObservableCollection<Mail> _Mails;

        public ObservableCollection<Mail> Mails
        {
            get => _Mails;
            private set => Set(ref _Mails, value);
        }
        public MainWindowViewModel(
            IRecipientsManager RecipientsManager,
            ISendersStore SendersStore,
            IServersStore ServersStore,
            IMailsStore MailsStore,
            ISenderEditor SenderEditor)
        {
            LoadRecipientsDataCommand = new RelayCommand(OnLoadRecipientsDataCommandExecute, CanLoadRecipientsDataCommandExecute);
            SaveRecipientChangesCommand = new RelayCommand<Recipient>(OnSaveRecipientChangesCommandExecute, CanSaveRecipientChangesCommandExecute);
            SenderEditCommand = new RelayCommand<Sender>(OnSenderEditCommandExecuted, CanSenderEditCommandExecute);

            _RecipientsManager = RecipientsManager;
            _SendersStore = SendersStore;
            _ServersStore = ServersStore;
            _MailsStore = MailsStore;
            _SenderEditor = SenderEditor;

        }
        private Recipient _SelectedRecipient;
        public Recipient SelectedRecipient
        {
            get => _SelectedRecipient;
            set => Set(ref _SelectedRecipient, value);

        }
        private Sender _SelectedSender;
        public Sender SelectedSender
        {
            get => _SelectedSender;
            set => Set(ref _SelectedSender, value);
        }
        private Server _SelectedServer;
        public Server SelectedServer
        {
            get => _SelectedServer;
            set => Set(ref _SelectedServer, value);
        }
        private Mail _SelectedMail;
        public Mail SelectedMail
        {
            get => _SelectedMail;
            set => Set(ref _SelectedMail, value);
        }

        #region Команды
        public ICommand LoadRecipientsDataCommand { get; }
        public ICommand SaveRecipientChangesCommand { get; }
        public ICommand SenderEditCommand { get; }
        #endregion
        private bool CanLoadRecipientsDataCommandExecute() => true;
        private void OnLoadRecipientsDataCommandExecute()
        {
            Recipients = new ObservableCollection<Recipient>(_RecipientsManager.GetAll());
            Senders = new ObservableCollection<Sender>(_SendersStore.GetAll());
            Servers = new ObservableCollection<Server>(_ServersStore.GetAll());
            Mails = new ObservableCollection<Mail>(_MailsStore.GetAll());
        }
        private bool CanSenderEditCommandExecute(Sender sender) => sender != null;

        private void OnSenderEditCommandExecuted(Sender sender) => _SenderEditor.Edit(sender);
        private bool CanSaveRecipientChangesCommandExecute(Recipient recipient) => recipient != null;
        private void OnSaveRecipientChangesCommandExecute(Recipient recipient)
        {
            _RecipientsManager.Edit(recipient);
            _RecipientsManager.SaveChanges();
        }
    }
}
