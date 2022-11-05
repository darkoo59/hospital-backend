using IntegrationLibrary.Features.BloodBankNews.Model;
using IntegrationLibrary.Features.BloodBankNews.Repository;
using System;
using System.Collections.Generic;

namespace IntegrationLibrary.Features.BloodBankNews.Service
{
    public class BankNewsService : IBankNewsService
    {
        private readonly IBankNewsRepository _bankNewsRepository;

        public BankNewsService(IBankNewsRepository repo) {
            _bankNewsRepository = repo;
        }

        public void ApproveNews(int id)
        {
            throw new NotImplementedException();
        }

        public void DispproveNews(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BankNews> GetAll()
        {
            return _bankNewsRepository.GetAll();
        }

        public IEnumerable<BankNews> GetAllByState(NewsStateEnum state)
        {
            throw new NotImplementedException();
        }
    }
}
