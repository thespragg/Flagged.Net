namespace Flagged.Net.Cache;

internal interface IInMemoryCache<in TKey, TValue> where TKey : notnull
{
    bool HasKey(TKey key);
    bool TryGet(TKey key, out TValue? value);
    bool TryAdd(TKey key, TValue value);
}