using Xunit;

namespace StageRaceFantasy.E2eTests.Shared.WebApplicationFactory;

[CollectionDefinition(Name)]
public class CustomWebApplicationCollection : ICollectionFixture<CustomWebApplicationFixture>
{
    public const string Name = "waf";
}
