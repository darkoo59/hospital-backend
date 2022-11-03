using IntegrationLibrary.Features.BloodBankNews.Model;
using IntegrationLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IntegrationLibrary.Features.BloodBankNews.Repository
{
    public class BankNewsRepository : IBankNewsRepository
    {
        private readonly IntegrationDbContext _context;

        public BankNewsRepository(IntegrationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<BankNews> GetAll()
        {
            return _context.BankNews.ToList();
        }
    }
}
