using HospitalLibrary.Core.Model;
using HospitalLibrary.Settings;
using System.Collections.Generic;
using System.Linq;

namespace HospitalLibrary.Core.Repository
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly HospitalDbContext _context;

        public DoctorRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Doctor> GetAll()
        {
            return _context.Doctors.ToList();
        }

        public Doctor GetById(int id)
        {
            return _context.Doctors.Find(id);
        }

        public List<Doctor> GetAllDoctorsBySpecialization(int specialization)
        {
            return _context.Doctors.Where(d => d.SpecializationId == specialization).ToList();
        }
    }
}