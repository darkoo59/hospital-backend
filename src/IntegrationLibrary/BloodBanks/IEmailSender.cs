using IntegrationLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.BloodBanks
{
    public interface IEmailSender
    {
        Task SendEmail(MailContent mailContent);
    }
}
