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


        public void AddBloodAfterUrgentRequest(int type, double quantity)
        {
            Blood blood = _bloodRepository.GetByBloodType(ParseIntToBloodType(type));
            blood.QuantityInLiters = blood.QuantityInLiters + quantity;
            _bloodRepository.Update(blood);
            Console.WriteLine("Dodao krv");
        }

        public BloodType ParseIntToBloodType(int number)
        {
            switch(number)
            {
                case 0: return BloodType.A_PLUS;
                case 1: return BloodType.A_MINUS;
                case 2: return BloodType.B_PLUS;
                case 3: return BloodType.B_MINUS;
                case 4: return BloodType.O_PLUS;
                case 5: return BloodType.O_MINUS;
                case 6: return BloodType.AB_PLUS;
                default: return BloodType.AB_MINUS;
            }
        }

        public Boolean ChangeQuantity(BloodUsageEvidency bloodUsageEvidency)
        {

            Blood blood = _bloodRepository.GetByBloodType(bloodUsageEvidency.BloodType);
            if(IsEnoughBlood(blood, bloodUsageEvidency.QuantityUsedInMililiters))
            {
                 blood.QuantityInLiters = Math.Round(blood.QuantityInLiters - bloodUsageEvidency.QuantityUsedInMililiters/1000 , 3);
                _bloodRepository.Update(blood);
                return true;
            }
            else
            {
                return false;

            }
        
        


        }

        public Blood GetByBloodType(BloodType bloodType)
        {
            return _bloodRepository.GetByBloodType(bloodType);
        }

        public bool IsThereEnoughBlood(BloodTherapy bloodTherapy)
        {
            foreach (var blood in GetAll())
            {
                if (bloodTherapy.BloodType == blood.BloodType && bloodTherapy.QuantityInLiters < blood.QuantityInLiters)
                {
                    return true;
                }
            }
            return false;
        }

        IEnumerable<Blood> IBloodService.GetAll()
        {
            throw new NotImplementedException();
        }

        Blood IBloodService.GetById(int id)
        {
            throw new NotImplementedException();
        }

        Blood IBloodService.GetByBloodType(BloodType bloodType)
        {
            throw new NotImplementedException();
        }

        void IBloodService.Create(Blood blood)
        {
            throw new NotImplementedException();
        }

        void IBloodService.Update(Blood blood)
        {
            throw new NotImplementedException();
        }

        void IBloodService.Delete(Blood blood)
        {
            throw new NotImplementedException();
        }

        void IBloodService.ChangeQuantity(BloodUsageEvidency bloodUsageEvidency)
        {
            throw new NotImplementedException();
        }

        bool IBloodService.IsThereEnoughBlood(BloodTherapy bloodTherapy)
        {
            throw new NotImplementedException();
        }

        public void ReceiveNewBlood(Blood blood)
        {
            List<Blood> allBlood = (List<Blood>)_bloodRepository.GetAll();
            foreach(Blood bloodIte in allBlood)
            {
                if((int)bloodIte.BloodType == (int)blood.BloodType)
                {
                    bloodIte.QuantityInLiters = bloodIte.QuantityInLiters + blood.QuantityInLiters;
                    _bloodRepository.Update(bloodIte);
                    return;
                }
            }
            _bloodRepository.Create(blood);
        }

        /*bool IBloodService.ChangeQuantity(BloodUsageEvidency bloodUsageEvidency)
        {
            throw new NotImplementedException();
        }*/

        public void UpdateAfterTender(ICollection<Blood> list)
        {
            foreach (Blood tender_blood in list)
            {
                Blood blood = _bloodRepository.GetByBloodType(tender_blood.BloodType);
                blood.QuantityInLiters += tender_blood.QuantityInLiters;
                _bloodRepository.Update(blood);
            }
            
        }
    }

}
