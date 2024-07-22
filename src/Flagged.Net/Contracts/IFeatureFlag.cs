using JetBrains.Annotations;

namespace Flagged.Net.Contracts;

[PublicAPI]
public interface IFeatureFlag<in TContext>
{
    bool IsEnabled { get; set; }
    bool Check(TContext context);
}

public abstract class FeatureFlagBase<TContext> : IFeatureFlag<TContext>
{
    public bool IsEnabled { get; set; } = true;
    public abstract bool Check(TContext context);
}