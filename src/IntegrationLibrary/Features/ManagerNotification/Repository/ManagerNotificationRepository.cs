using IntegrationLibrary.Features.ManagerNotification.Model;
using IntegrationLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Features.ManagerNotification.Repository
{
    public class ManagerNotificationRepository : IManagerNotificationRepository
    {
        private readonly IntegrationDbContext _context;
        public ManagerNotificationRepository(IntegrationDbContext context)
        {
            _context = context;
        }

        public void Create(ManagersNotification notification)
        {
            _context.ManagerNotification.Add(notification);
            _context.SaveChanges();
        }

        public IEnumerable<ManagersNotification> GetAll()
        {
            return _context.ManagerNotification.ToList();
        }

        public ManagersNotification GetById(int id)
        {
            return _context.ManagerNotification.Find(id);
        }

        public void Remove(ManagersNotification notification)
        {
            _context.ManagerNotification.Remove(notification);
            _context.SaveChanges();
        }
    }
}
