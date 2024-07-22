using Flagged.Net.Cache;
using Flagged.Net.Contracts;

namespace Flagged.Net.Stores;

internal class InMemoryStore(
    IInMemoryCache<string, object> cache
) : IFeatureFlagStore
{
    public T? Find<T, TContext>() where T : IFeatureFlag<TContext>
        => cache.TryGet(typeof(T).Name, out var flag) ? (T)flag! : default;

    public void AddFlag<TContext>(IFeatureFlag<TContext> flag)
    {
        var hasKey = cache.HasKey(flag.GetType().Name);
        if (hasKey)
        {
            throw new Exception(
                "A flag with that signature has already been added. If you're trying to add multiple flags that have the same context (e.g a string), box the value with a unique record or class.");
        }

        _ = cache.TryAdd(flag.GetType().Name, flag);
    }
}