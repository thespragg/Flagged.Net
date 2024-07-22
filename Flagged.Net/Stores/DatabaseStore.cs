using Flagged.Net.Contracts;

namespace Flagged.Net.Stores;

public class DatabaseStore : IFeatureFlagStore
{
    public T? Find<T, TContext>() where T : IFeatureFlag<TContext>
    {
        throw new NotImplementedException();
    }

    public void AddFlag<TContext>(IFeatureFlag<TContext> flag)
    {
        throw new NotImplementedException();
    }
}