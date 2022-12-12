using IntegrationLibrary.Features.MonthlyBloodSubscription.Model;
using IntegrationLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Features.MonthlyBloodSubscription.Repository
{
    public class BloodSubscriptionRepository : IBloodSubscriptionRepository
    {
        private readonly IntegrationDbContext _context;
        public BloodSubscriptionRepository(IntegrationDbContext context)
        {
            _context = context;
        }

        public void Create(BloodSubscription monthlyBloodSubscription)
        {
            _context.BloodSubscription.Add(monthlyBloodSubscription);
            _context.SaveChanges();
        }

        public IEnumerable<BloodSubscription> GetAll()
        {
            return _context.BloodSubscription.ToList();
        }

        public BloodSubscription GetByBbId(int id)
        {
            return GetAll().FirstOrDefault(subscription => subscription.BloodBankId == id);
        }

        public BloodSubscription GetById(int id)
        {
            return _context.BloodSubscription.Find(id);
        }
        public void Remove(BloodSubscription bloodSubscription)
        {
            _context.BloodSubscription.Remove(bloodSubscription);
            _context.SaveChanges();
        }
    }
}
