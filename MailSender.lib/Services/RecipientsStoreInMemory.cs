using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender.lib.Entities;
using MailSender.lib.Data;

namespace MailSender.lib.Services
{
    public class RecipientsStoreInMemory
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
