using JetBrains.Annotations;

namespace Flagged.Net.Contracts;

[PublicAPI]
public interface IFeatureFlagManager
{
    bool IsFlagged<T, TContext>(TContext context) where T : IFeatureFlag<TContext>;
    void ToggleFeature<TFlag, TContext>() where TFlag : IFeatureFlag<TContext>;
}