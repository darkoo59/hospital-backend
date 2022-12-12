using IntegrationLibrary.Features.ManagerNotification.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Features.ManagerNotification.Repository
{
    public interface IManagerNotificationRepository
    {
        void Create(ManagersNotification notification);
        IEnumerable<ManagersNotification> GetAll();
        ManagersNotification GetById(int id);
        void Remove(ManagersNotification notification);
    }
}
