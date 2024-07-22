using JetBrains.Annotations;

namespace Flagged.Net.Configuration;

[PublicAPI]
public class FlaggedNetOptions
{
    public string? DatabaseConnectionString { get; set; }
}