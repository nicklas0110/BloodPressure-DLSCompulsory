using FeatureHubSDK;

namespace FeatureHub;

public class FeatureHubClient
{
    private readonly IFeatureHubConfig _config;

    public FeatureHubClient(string apikey)
    {
        FeatureLogging.DebugLogger += (sender, s) => Console.WriteLine("Debug: " + s);
        FeatureLogging.TraceLogger += (sender, s) => Console.WriteLine("Trace: " + s);
        FeatureLogging.InfoLogger   += (sender, s) => Console.WriteLine("Info: " + s);
        FeatureLogging.ErrorLogger  += (sender, s) => Console.WriteLine("Error: " + s);

        _config = new EdgeFeatureHubConfig("http://featurehub:8085", apikey);
    }
}