using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender.lib.Entities;

namespace MailSender.lib.Services.Interfaces
{
    public interface IRecipientsStore
    {
        IEnumerable<Recipient> GetAll();
        Recipient GetById(int id);
        void Edit(int id, Recipient recipient);
        Recipient Remove(int id);
        void SaveChanges();
    }
}
