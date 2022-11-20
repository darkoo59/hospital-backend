using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service
{
    public interface IBloodUsageEvidencyService
    {
        public IEnumerable<BloodUsageEvidency> GetAll();
        public BloodUsageEvidency GetById(int id);
        public void Create(BloodUsageEvidency bloodUsageEvidency);
        public void Update(BloodUsageEvidency bloodUsageEvidency);
        public void Delete(BloodUsageEvidency bloodUsageEvidency);

    }
}
