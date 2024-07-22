using Flagged.Net.Cache;
using Flagged.Net.Contracts;
using Flagged.Net.Stores;

namespace Flagged.Net.Test.Stores;

public class InMemoryStoreTests
{
    [Fact]
    public void TryAdd_ShouldThrow_WhenSameKey()
    {
        var cache = new InMemoryCache<string, object>();
        var store = new InMemoryStore(cache);
        
        store.AddFlag(new StringFlag());

        Assert.Throws<Exception>(() => store.AddFlag(new StringFlag()));
    }
    
    private class StringFlag : FeatureFlagBase<string>
    {
        public override bool Check(string context)
            => context == "Foo";
    }
}