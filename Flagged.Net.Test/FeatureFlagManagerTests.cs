using Flagged.Net.Contracts;
using Flagged.Net.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Flagged.Net.Test;

public class FeatureFlagManagerTests
{
    [Fact]
    public void FeatureFlagManager_ShouldCheckFlag()
    {
        var sc = new ServiceCollection();
        sc.AddFlaggedNet().AddFlag<StringFlag, string>();

        var sp = sc.BuildServiceProvider();
        var flagManager = sp.GetRequiredService<IFeatureFlagManager>();

        Assert.True(flagManager.IsFlagged<StringFlag, string>("Foo"));
        Assert.False(flagManager.IsFlagged<StringFlag, string>("Bar"));
    }
    
    [Fact]
    public void FeatureFlagManager_ShouldReturnFalse_WhenFlagNotExist()
    {
        var sc = new ServiceCollection();
        sc.AddFlaggedNet();

        var sp = sc.BuildServiceProvider();
        var flagManager = sp.GetRequiredService<IFeatureFlagManager>();

        Assert.False(flagManager.IsFlagged<StringFlag, string>("Foo"));
    }
    
    [Fact]
    public void FeatureFlagManager_ShouldToggleFlag()
    {
        var sc = new ServiceCollection();
        sc.AddFlaggedNet().AddFlag<StringFlag, string>();

        var sp = sc.BuildServiceProvider();
        var flagManager = sp.GetRequiredService<IFeatureFlagManager>();

        Assert.True(flagManager.IsFlagged<StringFlag, string>("Foo"));
        
        flagManager.ToggleFeature<StringFlag, string>();
        
        Assert.False(flagManager.IsFlagged<StringFlag, string>("Foo"));
    }

    private class StringFlag : FeatureFlagBase<string>
    {
        public override bool Check(string context)
            => context == "Foo";
    }
}