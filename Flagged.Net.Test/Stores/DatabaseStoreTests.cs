using Flagged.Net.Contracts;
using Flagged.Net.Stores;

namespace Flagged.Net.Test.Stores;

public class DatabaseStoreTests
{
    [Fact]
    public void TryAdd_ShouldThrow_WhenSameKey()
    {
        var store = new DatabaseStore();
        Assert.Throws<NotImplementedException>(() => store.AddFlag(new StringFlag()));
    }
    
    [Fact]
    public void Find_ShouldThrow_WhenSameKey()
    {
        var store = new DatabaseStore();
        Assert.Throws<NotImplementedException>(() => store.Find<StringFlag, string>());
    }
    
    private class StringFlag : FeatureFlagBase<string>
    {
        public override bool Check(string context)
            => context == "Foo";
    }
}