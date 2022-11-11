using IntegrationAPI;
using Xunit;

namespace IntegrationTests.Setup
{
    [CollectionDefinition("collection")]
    public class BaseIntegrationTest : ICollectionFixture<TestDatabaseFactory<Startup>>
    {
    }
}
