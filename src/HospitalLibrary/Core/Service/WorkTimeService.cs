using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalLibrary.Core.Service
{
    public class WorkTimeService : IWorkTimeService
    {
        private readonly IWorkTimeRepository _workTimeRepository;

        public WorkTimeService(IWorkTimeRepository workTimeRepository)
        {
            _workTimeRepository = workTimeRepository;
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
            return _workTimeRepository.GetAll();
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
