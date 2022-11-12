using IntegrationLibrary.Features.BloodBankNews.Model;
using System.Collections.Generic;

namespace IntegrationLibrary.Features.BloodBankNews.Service
{
    public interface IBankNewsService
    {
        IEnumerable<BankNews> GetAll();
        IEnumerable<BankNews> GetAllByState(NewsStateEnum state);
        void ApproveNews(int id);
        void DisapproveNews(int id);
        BankNews GetById(int id);
        void AddNews(BankNews bankNews);
    }
}
