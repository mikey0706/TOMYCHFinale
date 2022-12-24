using MimeKit;
using Services.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Interfaces
{
    public interface IEmailService
    {
        MimeMessage CreateEmailMessage(Message message);
        void Send(MimeMessage mailMessage);
    }
}
