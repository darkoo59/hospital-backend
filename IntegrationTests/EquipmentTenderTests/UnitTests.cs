using IntegrationLibrary.Features.EquipmentTenders.Domain;
using System;
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
    }
}
