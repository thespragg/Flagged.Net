using Flagged.Net.Cache;
using Flagged.Net.Configuration;
using Flagged.Net.Contracts;
using Flagged.Net.Stores;
using Microsoft.Extensions.DependencyInjection;

namespace Flagged.Net.Extensions;

public static class ServiceCollectionExtensions
{
    public static IFlaggedNetBuilder AddFlaggedNet(
        this IServiceCollection services
    )
    {
        services.AddTransient<IFeatureFlagManager, FeatureFlagManager>();
        var store = AddStore(new FlaggedNetOptions(), services);

        return new FlaggedNetBuilder(store);
    }
    
    public static IFlaggedNetBuilder AddFlaggedNet(
        this IServiceCollection services,
        Action<FlaggedNetOptions> configureOptions
    )
    {
        var options = new FlaggedNetOptions();
        configureOptions(options);

        services.AddTransient<IFeatureFlagManager, FeatureFlagManager>();
        var store = AddStore(options, services);

        return new FlaggedNetBuilder(store);
    }

    private static IFeatureFlagStore AddStore(
        FlaggedNetOptions opts,
        IServiceCollection services
    )
    {
        if (!string.IsNullOrEmpty(opts.DatabaseConnectionString))
        {
            services.AddSingleton<IFeatureFlagStore, DatabaseStore>();
            return new DatabaseStore();
        }

        var cache = new InMemoryCache<string, object>();
        services.AddSingleton<IFeatureFlagStore, InMemoryStore>();
        services.AddSingleton<IInMemoryCache<string, object>>(cache);
        return new InMemoryStore(cache);
    }
}