using HospitalLibrary.Core.Model;

namespace HospitalLibrary.Core.Service
{
    public interface INotificationService
    {
        void SendUpdateNotification(Appointment appointment);
        void SendCancelNotification(Appointment appointment);
    }
}
