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
        public Boolean ChangeQuantityy(BloodUsageEvidency bloodUsageEvidency);

        public void AddBloodAfterUrgentRequest(int type, double quantity);
        void ReceiveNewBlood(Blood blood);
        void UpdateAfterTender(ICollection<Blood> blood);
    }
}
