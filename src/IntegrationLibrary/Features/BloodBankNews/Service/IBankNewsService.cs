using IntegrationLibrary.Features.BloodBankNews.Enums;
using IntegrationLibrary.Features.BloodBankNews.Model;
using System.Collections.Generic;

namespace IntegrationLibrary.Features.BloodBankNews.Service
{
    public interface IBankNewsService
    {
        IEnumerable<BankNews> GetAll();
        IEnumerable<BankNews> GetAllByState(NewsState state);
        void ApproveNews(int id);
        void DeclineNews(int id);
        BankNews GetById(int id);
        void AddNews(BankNews bankNews);
    }
}
