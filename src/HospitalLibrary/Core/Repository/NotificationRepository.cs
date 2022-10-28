using HospitalLibrary.Core.Model;
using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HospitalLibrary.Core.Repository
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly HospitalDbContext _context;

        public NotificationRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public void Create(Notification notification)
        {
            _context.Notifications.Add(notification);
            _context.SaveChanges();
        }

        public void Delete(Notification notification)
        {
            _context.Notifications.Remove(notification);
            _context.SaveChanges();
        }

        public IEnumerable<Notification> GetAll()
        {
            return _context.Notifications.ToList();
        }

        public Notification GetById(int id)
        {
            return _context.Notifications.Find(id);
        }

        public void Update(Notification notification)
        {
            _context.Entry(notification).State = EntityState.Modified;

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
