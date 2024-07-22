using JetBrains.Annotations;

namespace Flagged.Net.Contracts;

[PublicAPI]
public interface IFlaggedNetBuilder
{
    IFlaggedNetBuilder AddFlag<TFlag, TContext>() where TFlag : IFeatureFlag<TContext>, new();
}