using HospitalLibrary.Core.Model;
using HospitalLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalLibrary.Core.Repository
{
    public class BloodRequestRepository : IBloodRequestRepository
    {
        private readonly HospitalDbContext _context;

        public BloodRequestRepository(HospitalDbContext context)
        {
            _context = context;
        }
        public void Create(BloodRequest bloodRequest)
        {
            _context.BloodRequests.Add(bloodRequest);
            _context.SaveChanges();
        }

        public void Delete(BloodRequest bloodRequest)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BloodRequest> GetAll()
        {
            return _context.BloodRequests.ToList();
        }

        public BloodRequest GetById(int id)
        {
            return _context.BloodRequests.Find(id);
        }

        public void Update(BloodRequest bloodRequest)
        {
            throw new NotImplementedException();
        }
    }
}
