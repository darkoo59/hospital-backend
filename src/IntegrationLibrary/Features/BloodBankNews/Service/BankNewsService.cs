using IntegrationLibrary.Features.BloodBankNews.Enums;
using IntegrationLibrary.Features.BloodBankNews.Model;
using IntegrationLibrary.Features.BloodBankNews.Repository;
using System.Collections.Generic;

namespace IntegrationLibrary.Features.BloodBankNews.Service
{
    public class BankNewsService : IBankNewsService
    {
        private readonly IBankNewsRepository _bankNewsRepository;

        public BankNewsService(IBankNewsRepository repo) {
            _bankNewsRepository = repo;
        }

        public void AddNews(BankNews bankNews)
        {
            _bankNewsRepository.Add(bankNews);
        }

        public void ApproveNews(int id)
        {
            BankNews news = _bankNewsRepository.GetById(id);
            if(news == null)
            {
                throw new BankNews.BankNewsException("News with the supplied id have not been found.");
            }
            news.State = NewsState.APPROVED;
            _bankNewsRepository.Update(news);
        }

        public void DeclineNews(int id)
        {
            BankNews news = _bankNewsRepository.GetById(id);
            if (news == null)
            {
                throw new BankNews.BankNewsException("News with the supplied id have not been found.");
            }
            news.State = NewsState.DECLINED;
            _bankNewsRepository.Update(news);
        }

        public IEnumerable<BankNews> GetAll()
        {
            return _bankNewsRepository.GetAll();
        }

        public IEnumerable<BankNews> GetAllByState(NewsState state)
        {
            List<BankNews> res = new();
            foreach (BankNews news in GetAll())
            {
                if (news.State == state) res.Add(news);
            }
            return res;
        }

        public BankNews GetById(int id)
        {
            return _bankNewsRepository.GetById(id);
        }
    }
}
