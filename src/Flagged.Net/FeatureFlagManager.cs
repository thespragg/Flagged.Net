using Flagged.Net.Contracts;

namespace Flagged.Net;

internal class FeatureFlagManager(
    IFeatureFlagStore flagStore
) : IFeatureFlagManager
{
    public bool IsFlagged<T, TContext>(
        TContext context
    ) where T : IFeatureFlag<TContext>
    {
        var flag = flagStore.Find<T, TContext>();
        if (flag is null) return false;

        return flag.IsEnabled && flag.Check(context);
    }
    
    public void ToggleFeature<TFlag, TContext>() where TFlag : IFeatureFlag<TContext>
    {
        var flag = flagStore.Find<TFlag, TContext>();
        if (flag != null)
        {
            flag.IsEnabled = !flag.IsEnabled;
        }
    }
}