using IntegrationLibrary.Features.BloodBankNews.Model;
using System.Collections.Generic;

namespace IntegrationLibrary.Features.BloodBankNews.Service
{
    public interface IBankNewsService
    {
        IEnumerable<BankNews> GetAll();
    }
}
