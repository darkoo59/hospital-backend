using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Repository
{
    public interface IPhysicianScheduleRepository
    {
        IEnumerable<PhysicianSchedule> GetAll();
        PhysicianSchedule GetById(int id);
        void Schedule(Appointment appointment);
        void Create(PhysicianSchedule physicianSchedule);
        void Update(PhysicianSchedule physicianSchedule);
        void Delete(PhysicianSchedule physicianSchedule);
        PhysicianSchedule Get(int doctorId);
        public PhysicianSchedule FindByDoctor(int doctorId);
        public List<Appointment> FindAppointmentsByDoctor(int doctorId);
    }
}
