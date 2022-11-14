using HospitalLibrary.Core.Model;
using HospitalLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Repository
{
    public class BloodUsageEvidencyRepository : IBloodUsageEvidencyRepository
    {
        private readonly HospitalDbContext _context;

        public BloodUsageEvidencyRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public void Create(BloodUsageEvidency bloodUsageEvidency)
        {
            _context.BloodUsageEvidencies.Add(bloodUsageEvidency);
            _context.SaveChanges();
        }


        public void Delete(BloodUsageEvidency bloodUsageEvidency)
        {
            throw new NotImplementedException();
        }


        public void Update(BloodUsageEvidency bloodUsageEvidency)
        {
            throw new NotImplementedException();
        }

        IEnumerable<BloodUsageEvidency> IBloodUsageEvidencyRepository.GetAll()
        {
            return _context.BloodUsageEvidencies.ToList();
        }

        public BloodUsageEvidency GetById(int id)
        {
            return _context.BloodUsageEvidencies.Find(id);
        }
    }
}
