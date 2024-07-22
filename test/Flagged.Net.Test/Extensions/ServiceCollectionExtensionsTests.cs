using Flagged.Net.Contracts;
using Flagged.Net.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Flagged.Net.Test.Extensions;

public class ServiceCollectionExtensionsTests
{
    [Fact]
    public void AddFlaggedNet_ShouldAddServices_InMemory()
    {
        var sc = new ServiceCollection();
        sc.AddFlaggedNet();

        Assert.Single(sc.Where(x => x.ServiceType == typeof(IFeatureFlagManager)));
        Assert.Single(sc.Where(x => x.ServiceType == typeof(IFeatureFlagStore)));
    }
    
    [Fact]
    public void AddFlaggedNet_ShouldAddServices_Database()
    {
        var sc = new ServiceCollection();
        sc.AddFlaggedNet(opts => opts.DatabaseConnectionString = "Foo");

        Assert.Single(sc.Where(x => x.ServiceType == typeof(IFeatureFlagManager)));
        Assert.Single(sc.Where(x => x.ServiceType == typeof(IFeatureFlagStore)));
    }
}