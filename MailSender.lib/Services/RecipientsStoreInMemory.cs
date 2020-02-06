using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender.lib.Entities;
using MailSender.lib.Data;
using MailSender.lib.Services.Interfaces;

namespace MailSender.lib.Services
{
    public class RecipientsStoreInMemory: IRecipientsStore
    {
        
        public IEnumerable<Recipient> Get() => TestData.Recipients;
        public void Edit(int id, Recipient recipient) {
            //БД
        }
        public void SaveChanges()
        { 
            //БД
        }
    }
}
