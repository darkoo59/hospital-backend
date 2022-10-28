using HospitalLibrary.Core.Model;
using System.Collections.Generic;

namespace HospitalLibrary.Core.Repository
{
    public interface INotificationRepository
    {
        IEnumerable<Notification> GetAll();
        Notification GetById(int id);
        void Create(Notification notification);
        void Update(Notification notification);
        void Delete(Notification notification);
    }
}
