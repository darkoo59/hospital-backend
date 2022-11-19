using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service
{
    public class BloodService : IBloodService
    {
        private readonly IBloodRepository _bloodRepository;



        public BloodService(IBloodRepository bloodRepository)
        {
            _bloodRepository = bloodRepository;
        }

        public void Create(Blood blood)
        {
            _bloodRepository.Create(blood);
        }

        public void Delete(Blood blood)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Blood> GetAll()
        {
            return _bloodRepository.GetAll();
        }

        public Blood GetById(int id)
        {
            return _bloodRepository.GetById(id);
        }


        public void Update(Blood blood)
        {
              _bloodRepository.Update(blood);
              
        }


        public bool IsEnoughBlood(Blood blood, double usedQuantityInMililitersLiters)
        {
            return blood.QuantityInLiters >= (usedQuantityInMililitersLiters/1000);
        }

        public void ChangeQuantity(BloodUsageEvidency bloodUsageEvidency)
        {

            Blood blood = _bloodRepository.GetByBloodType(bloodUsageEvidency.BloodType);
            if(IsEnoughBlood(blood, bloodUsageEvidency.QuantityUsedInMililiters))
            {
                 blood.QuantityInLiters = Math.Round(blood.QuantityInLiters - bloodUsageEvidency.QuantityUsedInMililiters/1000 , 3);
                _bloodRepository.Update(blood);
            }
            else
            {
                throw new ArgumentOutOfRangeException("Blood amount is out of range.");

            }



        }

        public Blood GetByBloodType(BloodType bloodType)
        {
            return _bloodRepository.GetByBloodType(bloodType);
        }
    }

}
