using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using HospitalLibrary.Core.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HospitalTests.Unit
{
    public class BloodTests
    {

        [Fact]
        public void Get_blood()
        {
            List<Blood> bloods = GetBlood();
            BloodService service = new(CreateBloodRepository(bloods));

            IEnumerable<Blood> ret = service.GetAll();

            Xunit.Assert.Equal(ret, bloods);
        }


        [Fact]
        public void Get_blood_by_id()
        {
            List<Blood> bloods = GetBlood();
            BloodService service = new(CreateBloodRepository(bloods));

            Blood blood = service.GetById(1);

            Xunit.Assert.Equal(blood, bloods[0]);
        }

        [Fact]
        public void Get_blood_by_blood_type()
        {
            List<Blood> bloods = GetBlood();
            BloodService service = new(CreateBloodRepository(bloods));

            Blood blood = service.GetByBloodType(BloodType.O_PLUS);

            Xunit.Assert.Equal(blood, bloods[0]);
        }


/*        [Fact]
        public void Blood_change_quantity()
        {
            List<Blood> bloods = GetBlood();
            BloodService service = new(CreateBloodRepository(bloods));
            BloodUsageEvidency bloodUsageEvidency = new BloodUsageEvidency() { BloodUsageEvidencyId = 1, BloodType = BloodType.O_PLUS, QuantityUsedInMililiters = 200, DateOfUsage = new System.DateTime(2022, 12, 13), ReasonForUsage = "Hearth surgery", DoctorId = 1 };
            //service.ChangeQuantity(bloodUsageEvidency);
            Blood blood = service.GetByBloodType(BloodType.O_PLUS);
            Xunit.Assert.Equal(3.8, bloods[0].QuantityInLiters);
        }

        [Fact]
        public void Blood_change_quantity_more_tham_in_bank()
        {
            List<Blood> bloods = GetBlood();
            BloodService service = new(CreateBloodRepository(bloods));
            BloodUsageEvidency bloodUsageEvidency = new BloodUsageEvidency() { BloodUsageEvidencyId = 1, BloodType = BloodType.O_PLUS, QuantityUsedInMililiters = 20000, DateOfUsage = new System.DateTime(2022, 12, 13), ReasonForUsage = "Hearth surgery", DoctorId = 1 };
            //service.ChangeQuantity(bloodUsageEvidency);
            Blood blood = service.GetByBloodType(BloodType.O_PLUS);
            Xunit.Assert.Equal(4, bloods[0].QuantityInLiters);
        }*/


        #region private

        private static IBloodRepository CreateBloodRepository(List<Blood> blood)
        {
            var stubRepo = new Mock<IBloodRepository>();
            stubRepo.Setup(m => m.GetAll()).Returns(blood);
            stubRepo.Setup(m => m.GetById(1)).Returns(blood[0]);
            stubRepo.Setup(m => m.GetById(2)).Returns(blood[1]);
            stubRepo.Setup(m => m.GetById(3)).Returns(blood[2]);
            stubRepo.Setup(m => m.GetById(4)).Returns(blood[3]);
            stubRepo.Setup(m => m.GetById(5)).Returns(blood[4]);
            stubRepo.Setup(m => m.GetById(6)).Returns(blood[5]);
            stubRepo.Setup(m => m.GetById(7)).Returns(blood[6]);
            stubRepo.Setup(m => m.GetById(8)).Returns(blood[7]);

            stubRepo.Setup(m => m.GetByBloodType(BloodType.O_PLUS)).Returns(blood[0]);
            stubRepo.Setup(m => m.GetByBloodType(BloodType.A_PLUS)).Returns(blood[1]);
            stubRepo.Setup(m => m.GetByBloodType(BloodType.B_PLUS)).Returns(blood[2]);
            stubRepo.Setup(m => m.GetByBloodType(BloodType.AB_PLUS)).Returns(blood[3]);
            stubRepo.Setup(m => m.GetByBloodType(BloodType.O_MINUS)).Returns(blood[4]);
            stubRepo.Setup(m => m.GetByBloodType(BloodType.A_MINUS)).Returns(blood[5]);
            stubRepo.Setup(m => m.GetByBloodType(BloodType.B_MINUS)).Returns(blood[6]);
            stubRepo.Setup(m => m.GetByBloodType(BloodType.AB_MINUS)).Returns(blood[7]); 





            return stubRepo.Object;
        }

        
        private static List<Blood> GetBlood()
        {
            return new()
            {
                new Blood() { BloodId = 1, BloodType = BloodType.O_PLUS, QuantityInLiters = 4 },
                new Blood() { BloodId = 2, BloodType = BloodType.A_PLUS, QuantityInLiters = 4 },
                new Blood() { BloodId = 3, BloodType = BloodType.B_PLUS, QuantityInLiters = 4 },
                new Blood() { BloodId = 4, BloodType = BloodType.AB_PLUS, QuantityInLiters = 4 },
                new Blood() { BloodId = 5, BloodType = BloodType.O_MINUS, QuantityInLiters = 4 },
                new Blood() { BloodId = 6, BloodType = BloodType.A_MINUS, QuantityInLiters = 4 },
                new Blood() { BloodId = 7, BloodType = BloodType.B_MINUS, QuantityInLiters = 4 },
                new Blood() { BloodId = 8, BloodType = BloodType.AB_MINUS, QuantityInLiters = 4 }
            };
        }

        #endregion
   
   
        }
}
