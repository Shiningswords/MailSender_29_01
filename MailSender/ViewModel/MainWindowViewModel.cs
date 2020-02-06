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

namespace MailSender.ViewModel
{
    public class MainWindowViewModel: ViewModelBase
    {
        private readonly RecipientsManager _RecipientsManager;

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
        public MainWindowViewModel(RecipientsManager RecipientsManager)
        {
            _RecipientsManager = RecipientsManager;
            
            LoadRecipientsDataCommand = new RelayCommand(OnLoadRecipientsDataCommandExecute, CanLoadRecipientsDataCommandExecute);
            SaveRecipientChangesCommand = new RelayCommand<Recipient>(OnSaveRecipientChangesCommandExecute, CanSaveRecipientChangesCommandExecute);
        }
        private Recipient _SelectedRecipient;
        public Recipient SelectedRecipient
        {
            get => _SelectedRecipient;
            set => Set(ref _SelectedRecipient, value);
        }
        #region Команды
        public ICommand LoadRecipientsDataCommand { get; }
        public ICommand SaveRecipientChangesCommand { get; }
        #endregion
        private bool CanLoadRecipientsDataCommandExecute() => true;
        private void OnLoadRecipientsDataCommandExecute()
        {
            Recipients = new ObservableCollection<Recipient>(_RecipientsManager.GetAll());
        }
        private bool CanSaveRecipientChangesCommandExecute(Recipient recipient) => recipient != null;
        private void OnSaveRecipientChangesCommandExecute(Recipient recipient)
        {
            _RecipientsManager.Edit(recipient);
            _RecipientsManager.SaveChanges();
        }
    }
}
