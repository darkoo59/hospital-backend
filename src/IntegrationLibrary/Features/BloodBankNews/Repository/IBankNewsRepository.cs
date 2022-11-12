using IntegrationLibrary.Features.BloodBankNews.Model;
using System.Collections.Generic;

namespace IntegrationLibrary.Features.BloodBankNews.Repository
{
    public interface IBankNewsRepository
    {
        IEnumerable<BankNews> GetAll();
        BankNews GetById(int id);
        void Update(BankNews news);
        void Add(BankNews bankNews);
    }
}
