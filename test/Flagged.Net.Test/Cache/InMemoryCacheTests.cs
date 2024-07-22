using Flagged.Net.Cache;

namespace Flagged.Net.Test.Cache;

public class InMemoryCacheTests
{
     [Fact]
    public void TryAdd_ShouldAddItemToCache()
    {
        var cache = new InMemoryCache<string, int>();
        var added = cache.TryAdd("key1", 1);
        Assert.True(added);
        Assert.True(cache.HasKey("key1"));
    }

    [Fact]
    public void TryAdd_ShouldNotAddDuplicateKey()
    {
        var cache = new InMemoryCache<string, int>();
        cache.TryAdd("key1", 1);
        var added = cache.TryAdd("key1", 2);
        Assert.False(added);
    }

    [Fact]
    public void TryGet_ShouldRetrieveAddedItem()
    {
        var cache = new InMemoryCache<string, int>();
        cache.TryAdd("key1", 1);
        var retrieved = cache.TryGet("key1", out var value);
        Assert.True(retrieved);
        Assert.Equal(1, value);
    }

    [Fact]
    public void TryGet_ShouldReturnFalseForNonExistentKey()
    {
        var cache = new InMemoryCache<string, int>();
        var retrieved = cache.TryGet("nonexistent", out var value);
        Assert.False(retrieved);
        Assert.Equal(default, value);
    }
    
    [Fact]
    public void HasKey_ShouldReturnTrueForExistingKey()
    {
        var cache = new InMemoryCache<string, int>();
        cache.TryAdd("key1", 1);
        Assert.True(cache.HasKey("key1"));
    }

    [Fact]
    public void HasKey_ShouldReturnFalseForNonExistentKey()
    {
        var cache = new InMemoryCache<string, int>();
        Assert.False(cache.HasKey("nonexistent"));
    }
}