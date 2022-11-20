using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service
{
    public class BloodUsageEvidencyService : IBloodUsageEvidencyService
    {
        private readonly IBloodUsageEvidencyRepository _bloodUsageEvidencyRepository;

        public BloodUsageEvidencyService(IBloodUsageEvidencyRepository bloodUsageEvidencyRepository)
        {
            _bloodUsageEvidencyRepository = bloodUsageEvidencyRepository;
        }

        public void Create(BloodUsageEvidency bloodUsageEvidency)
        {
            bloodUsageEvidency.DateOfUsage = DateTime.Now;
            _bloodUsageEvidencyRepository.Create(bloodUsageEvidency);
        }

        public void Delete(BloodUsageEvidency bloodUsageEvidency)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BloodUsageEvidency> GetAll()
        {
            return _bloodUsageEvidencyRepository.GetAll();
        }

        public BloodUsageEvidency GetById(int id)
        {
            return _bloodUsageEvidencyRepository.GetById(id);
        }

        public void Update(BloodUsageEvidency bloodUsageEvidency)
        {
            throw new NotImplementedException();
        }
    }
}
