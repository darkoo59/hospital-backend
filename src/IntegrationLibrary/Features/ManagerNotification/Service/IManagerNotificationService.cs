using IntegrationLibrary.Features.ManagerNotification.DTO;
using IntegrationLibrary.Features.ManagerNotification.Model;
using IntegrationLibrary.Features.MonthlyBloodSubscription.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Features.ManagerNotification.Service
{
    public interface IManagerNotificationService
    {
        IEnumerable<ManagersNotification> GetAll();
        void Remove(int id);
        void ReceiveNotification(ReceivedNotificationDTO notificationDTO);
    }
}
