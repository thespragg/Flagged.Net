using Flagged.Net.Contracts;

namespace Flagged.Net.Configuration;

internal class FlaggedNetBuilder(
    IFeatureFlagStore flagStore
) : IFlaggedNetBuilder
{
    public IFlaggedNetBuilder AddFlag<TFlag, TContext>() where TFlag : IFeatureFlag<TContext>, new()
    {
        TFlag flag = new();
        flagStore.AddFlag(flag);
        return this;
    }
}