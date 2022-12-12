using HospitalLibrary.Core.Model;
using HospitalLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Registration.Repository
{
    public class MedicalRecordRepository : IMedicalRecordRepository
    {

        private readonly HospitalDbContext _context;

        public MedicalRecordRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public void Register(MedicalRecord medicalRecord)
        {
            _context.MedicalRecords.Add(medicalRecord);
            _context.SaveChanges();
        }

        public void Delete(MedicalRecord medicalRecord)
        {
            _context.MedicalRecords.Remove(medicalRecord);
            _context.SaveChanges();
        }

        public IEnumerable<MedicalRecord> GetAll()
        {
            return _context.MedicalRecords.ToList();
        }

        public MedicalRecord GetById(int id)
        {
            return _context.MedicalRecords.Find(id);
        }

        public void Update(MedicalRecord medicalRecord)
        {
            _context.MedicalRecords.Update(medicalRecord);
            _context.SaveChanges();
        }





    }
}
