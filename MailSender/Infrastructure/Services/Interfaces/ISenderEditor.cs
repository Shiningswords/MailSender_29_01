using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender.lib.Entities;

namespace MailSender.Infrastructure.Services.Interfaces
{
    public interface ISenderEditor
    {
        void Edit(Sender sender);
    }
}
