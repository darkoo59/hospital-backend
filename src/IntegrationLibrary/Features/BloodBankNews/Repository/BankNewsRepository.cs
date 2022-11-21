using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Features.BloodBankNews.Model;
using IntegrationLibrary.Settings;
using Microsoft.EntityFrameworkCore;
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

        public void Add(BankNews bankNews)
        {
            _context.BankNews.Add(bankNews);
            _context.SaveChanges();
        }

        public IEnumerable<BankNews> GetAll()
        {
            return _context.BankNews.ToList();
        }

        public BankNews GetById(int id)
        {
            foreach (BankNews bank in GetAll())
            {
                if (bank.Id == id) return bank;
            }
            return null;
        }

        public void Update(BankNews news)
        {
            _context.Entry(news).State = EntityState.Modified;
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
    }
}
