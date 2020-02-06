using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using MailSender.lib.Services;
using MailSender.lib.Entities;

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
            _Recipients = new ObservableCollection<Recipient>(_RecipientsManager.GetAll());
        }
    }
}
