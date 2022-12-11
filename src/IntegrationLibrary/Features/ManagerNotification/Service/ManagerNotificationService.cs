using IntegrationLibrary.Features.BloodBank.Model;
using IntegrationLibrary.Features.BloodBank.Service;
using IntegrationLibrary.Features.ManagerNotification.DTO;
using IntegrationLibrary.Features.ManagerNotification.Model;
using IntegrationLibrary.Features.ManagerNotification.Repository;
using IntegrationLibrary.Features.MonthlyBloodSubscription.DTO;
using IntegrationLibrary.Features.MonthlyBloodSubscription.Mapper;
using IntegrationLibrary.Features.MonthlyBloodSubscription.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Features.ManagerNotification.Service
{
    public class ManagerNotificationService : IManagerNotificationService
    {
        private readonly IManagerNotificationRepository _notificationRepository;
        public ManagerNotificationService(IManagerNotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }
        public IEnumerable<ManagersNotification> GetAll()
        {
            return _notificationRepository.GetAll();
        }

        public void ReceiveNotification(ReceivedNotificationDTO notificationDTO)
        {
            ManagersNotification notification = new ManagersNotification()
            {
                Title = notificationDTO.Title,
                Content = notificationDTO.Content
            };
            _notificationRepository.Create(notification);
        }

        public void Remove(int notificationId)
        {
            ManagersNotification notificaitonToRemove = _notificationRepository.GetById(notificationId);
            _notificationRepository.Remove(notificaitonToRemove);
        }
    }
}
