using FeatureHubSDK;
using IO.FeatureHub.SSE.Model;

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
    
    public async Task<bool> IsCountryAllowed(string country)
    {
        StrategyAttributeCountryName countryName;
    
        if (!Enum.TryParse(country, true, out countryName)) throw new ArgumentException("Could not find country");
        
        var featureToggle = await _config.NewContext().Country(countryName).Build();
        
        
        return featureToggle["countryAllowed"].IsEnabled;
    }
}