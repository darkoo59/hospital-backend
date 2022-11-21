using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service
{
    public interface IBloodService
    {
        IEnumerable<Blood> GetAll();
        Blood GetById(int id);
        Blood GetByBloodType(BloodType bloodType);

        void Create(Blood blood);
        void Update(Blood blood);
        void Delete(Blood blood);
        public void ChangeQuantity(BloodUsageEvidency bloodUsageEvidency);
        bool IsThereEnoughBlood(BloodTherapy bloodTherapy);
        public Boolean ChangeQuantity(BloodUsageEvidency bloodUsageEvidency);
    }
}
