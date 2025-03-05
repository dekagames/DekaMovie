namespace DekaMovie.Infra;
public class AppSettings
{
    public string? TMDbApiKey { get; set; }
    public string? TMDbBaseUrl { get; set; }
    public string? TMDbAccessToken { get; set; }    
}

public static class ConfigService
{
    private static AppSettings? _settings;

    public static async Task<AppSettings> LoadSettingsAsync()
    {
        if (_settings != null) return _settings;
        
        var assembly = Assembly.GetExecutingAssembly();
        var resourceName = "DekaMovie.Resources.Raw.appsettings.json";

        using var stream = assembly.GetManifestResourceStream(resourceName)
            ?? throw new Exception("Arquivo appsettings.json não encontrado!");

        using var reader = new StreamReader(stream);
        
        return JsonSerializer.Deserialize<AppSettings>(await reader.ReadToEndAsync())!;
    }
}