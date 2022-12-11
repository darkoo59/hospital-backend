using IntegrationLibrary.Features.EquipmentTenders.Domain;
using IntegrationLibrary.Features.EquipmentTenders.Domain.ValueObjects;
using IntegrationLibrary.Features.EquipmentTenders.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace IntegrationTests.EquipmentTenderTests
{
    public class UnitTests
    {
        [Fact]
        public void Title_Null_Test()
        {
            Assert.Throws<EquipmentTender.InvalidDataException>(() => new EquipmentTender(null, new DateTime(), "1", null));
        }

        [Fact]
        public void Add_Application_Test()
        {
            TenderApplication ta = new("123", 5, 0, new List<TenderOffer>());
            EquipmentTender et = new();
            et.AddApplication(ta);

            Assert.True(et.TenderApplications.FirstOrDefault(a => a == ta) != null);
        }

        [Fact]
        public void Set_Invalid_State_Test()
        {
            EquipmentTender et = new();
            et.SetState(TenderState.PENDING);
            et.SetState(TenderState.CLOSED);
            Assert.Throws<Exception>(() => et.SetState(TenderState.OPEN));
            Assert.Throws<Exception>(() => et.SetState(TenderState.PENDING));
        }

        [Fact]
        public void Create_Money_Test()
        {
            Assert.Throws<Money.InvalidDataException>(() => new Money(-20));
        }
    }
}
