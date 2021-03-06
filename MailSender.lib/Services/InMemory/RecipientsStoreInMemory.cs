﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender.lib.Entities;
using MailSender.lib.Data;
using MailSender.lib.Services.Interfaces;
using MailSender.lib.Services.InMemory;

namespace MailSender.lib.Services
{
    public class RecipientsStoreInMemory : DataStoreInMemory<Recipient>, IRecipientsStore
    {
        public RecipientsStoreInMemory() : base(TestData.Recipients) { }

        public override void Edit(int id, Recipient recipient)
        {
            var db_recipient = GetById(id);
            if (db_recipient is null) return;

            db_recipient.Name = recipient.Name;       // Притворяемся, что мы работаем не с объектами в памяти, а с объектам в БД
            db_recipient.Address = recipient.Address;
        }
    }
}
