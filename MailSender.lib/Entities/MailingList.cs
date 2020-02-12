using MailSender.lib.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Entities
{
    public class MailingList: NamedEntity
    {
        public ICollection<Recipient> Recipients = new List<Recipient>();
    }
}
