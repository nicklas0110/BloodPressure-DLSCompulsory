namespace FeatureHub;

public class FeatureHubFactory
{
    public static FeatureHubClient CreateFeatureHub()
    {
        const string apikey = "c4d231ae-e411-44f9-863b-9ec880abed4e/Ir0mH6xQzjSRdlAj85tLRztNwywcfrETo4PdV7RW";
        return new FeatureHubClient(apikey);
    }
}