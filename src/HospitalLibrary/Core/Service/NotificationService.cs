using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;

namespace HospitalLibrary.Core.Service
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IDoctorRepository _doctorRepository;

        public NotificationService(INotificationRepository notificationRepository, IDoctorRepository doctorRepository) {
            this._notificationRepository = notificationRepository;
            this._doctorRepository = doctorRepository;
        }
        public void SendUpdateNotification(Appointment appointment)
        {
            Notification notification = new Notification
            {
                PatientId = (int)appointment.PatientId,
                DoctorId = (int)appointment.DoctorId
            };
            Doctor doctor = _doctorRepository.GetById(notification.DoctorId);
            notification.Message = "Doctor " + doctor.Name + " " + doctor.Surname + " rescheduled your appointment for " + appointment.DateTime.ToString() + ".";
            _notificationRepository.Create(notification);
        }

        public void SendCancelNotification(Appointment appointment)
        {
            Notification notification = new Notification
            {
                PatientId = (int)appointment.PatientId,
                DoctorId = (int)appointment.DoctorId
            };
            Doctor doctor = _doctorRepository.GetById(notification.DoctorId);
            notification.Message = "Doctor " + doctor.Name + " " + doctor.Surname + " canceled your appointment that was scheduled for " + appointment.DateTime.ToString() + ".";
            _notificationRepository.Create(notification);
        }
    }
}
