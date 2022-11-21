using IntegrationLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Features.BloodBank
{
    public interface IBloodBankService
    {
        Task SendEmail(MailContent mailContent);
    }
}
