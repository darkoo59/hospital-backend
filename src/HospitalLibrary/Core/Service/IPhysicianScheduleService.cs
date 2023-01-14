using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service
{
    public interface IPhysicianScheduleService
    {
        IEnumerable<PhysicianSchedule> GetAll();
        PhysicianSchedule GetById(int id);
        void Create(PhysicianSchedule physicianSchedule);
        void Update(PhysicianSchedule physicianSchedule);
        void Delete(PhysicianSchedule physicianSchedule);
        List<Appointment> GetAvailableAppointments(int doctorId, DateTime date);
        bool Schedule(int doctorId, Appointment appointment);
        void TransferAppointment(int doctorId, Appointment appointment);
        PhysicianSchedule Get(int doctorId);
        List<Appointment> GetAppointments(int doctorId);
    }
}
