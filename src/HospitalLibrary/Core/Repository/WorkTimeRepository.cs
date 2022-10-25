using HospitalLibrary.Core.Model;
using HospitalLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalLibrary.Core.Repository
{
    public class WorkTimeRepository : IWorkTimeRepository
    {
        private readonly HospitalDbContext _context;

        public WorkTimeRepository(HospitalDbContext context)
        {
            _context = context;
        }
        public void Create(WorkTime workTime)
        {
            throw new NotImplementedException();
        }

        public void Delete(WorkTime workTime)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<WorkTime> GetAll()
        {
            return _context.WorkTimes.ToList();
        }

        public WorkTime GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(WorkTime workTime)
        {
            throw new NotImplementedException();
        }
    }
}
