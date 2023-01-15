using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Features.Blood.DTO;
using IntegrationLibrary.Features.BloodBank.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IntegrationLibrary.Features.BloodBank
{
    public interface IBloodBankService
    {
        Task SendEmail(MailContent mailContent);

        Task<string> GenerateApiKey(User user);
        Task<string> ConfirmTender(User user, ICollection<BloodDTO> data);
    }
}
