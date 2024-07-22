namespace Flagged.Net.Contracts;

internal interface IFeatureFlagStore
{
    T? Find<T, TContext>() where T : IFeatureFlag<TContext>;
    void AddFlag<TContext>(IFeatureFlag<TContext> flag);
}