namespace DekaMovie.Infra;

public struct ConfigurationManager
{
    public const string URL = "https://dummyjson.com";
}

public static class BaseService
{
    public static string? ApiKey;
    public static string? BaseUrl;
    public static string? AccessToken;

    public static async Task InitializeAsync()
    {
        var settings = await ConfigService.LoadSettingsAsync();
        ApiKey = settings.TMDbApiKey;
        BaseUrl = settings.TMDbBaseUrl;
        AccessToken = settings.TMDbAccessToken;
    }
}
