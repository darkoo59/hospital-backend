using IntegrationLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Features.BloodBankRegister
{
    public interface IBloodBankService
    {
        Task SendEmail(MailContent mailContent);
    }
}
