using System.Collections.Concurrent;

namespace Flagged.Net.Cache;

internal class InMemoryCache
{
    internal static readonly SemaphoreSlim GlobalStaticLock = new(1);
}

internal sealed class InMemoryCache<TKey, TValue> : InMemoryCache, IInMemoryCache<TKey, TValue> where TKey : notnull
{
    private readonly ConcurrentDictionary<TKey, CacheValue> _dict = new();
    
    public bool HasKey(TKey key)
        => _dict.ContainsKey(key);

    public bool TryGet(TKey key, out TValue? value)
    {
        value = default;

        if (!_dict.TryGetValue(key, out var ttlValue))
            return false;

        value = ttlValue.Value;
        return true;
    }
    
    public bool TryAdd(TKey key, TValue value)
        => !TryGet(key, out _) && _dict.TryAdd(key, new CacheValue(value));

    private record CacheValue(TValue Value);
}