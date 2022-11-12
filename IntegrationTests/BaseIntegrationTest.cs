using IntegrationAPI;
using Xunit;

namespace IntegrationTests
{
    [CollectionDefinition("collection")]
    public class BaseIntegrationTest : ICollectionFixture<TestDatabaseFactory<Startup>>
    {
    }
}
