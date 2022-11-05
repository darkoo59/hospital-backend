using IntegrationLibrary.Features.BloodBankNews.Model;
using System.Collections.Generic;

namespace IntegrationLibrary.Features.BloodBankNews.Service
{
    public interface IBankNewsService
    {
        IEnumerable<BankNews> GetAll();
        IEnumerable<BankNews> GetAllByState(NewsStateEnum state);
        void ApproveNews(int id);
        void DispproveNews(int id);
    }
}
