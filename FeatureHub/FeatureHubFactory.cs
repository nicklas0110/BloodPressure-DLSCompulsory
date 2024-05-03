namespace FeatureHub;

public class FeatureHubFactory
{
    public static FeatureHubClient CreateFeatureHub()
    {
        const string apikey = "35860db7-904d-413a-9591-3a76d08b6462/h869xrGkd7TEkxWkGTLGnW16XCRNRsM4mkBOIrwU";
        return new FeatureHubClient(apikey);
    }
}