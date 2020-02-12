﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender.lib.Entities;

namespace MailSender.lib.Services.Interfaces
{
    public interface IRecipientsManager
    {
        IEnumerable<Recipient> GetAll();
        void Add(Recipient NewRecipient);
        void Edit(Recipient Recipient);
        void SaveChanges();
    }

}
