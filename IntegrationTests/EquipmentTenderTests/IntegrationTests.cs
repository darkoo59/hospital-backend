using Xunit.Priority;
using Xunit;

namespace IntegrationTests.EquipmentTenderTests
{
    [TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
    [Collection("collection")]
    public class IntegrationTests
    {

    }
}
