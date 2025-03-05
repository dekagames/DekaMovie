namespace DekaMovie.Features;

public interface ILoginService
{    
    Task<string> GetTokenAsync();
    Task<string> GetSessionIdAsync(string requestToken);
}

public class LoginService(IApiRestfull api) : ILoginService
{
    readonly IApiRestfull _api = api;

    public async Task<string> GetTokenAsync()
    {
        var result = await _api.GetRequestTokenAsync();
        return result != null ? result?.RequestToken! : null!;
    } 

    public async Task<string> GetSessionIdAsync(string requestToken)
    {
        if (string.IsNullOrWhiteSpace(BaseService.BaseUrl) || string.IsNullOrWhiteSpace(BaseService.ApiKey))
            BaseService.InitializeAsync().Wait();

        var url = $"{BaseService.BaseUrl}/authentication/session/new?api_key={BaseService.ApiKey}";

        var content = JsonSerializer.Serialize(new { request_token = requestToken });
        //var response = await _httpClient.PostAsync(url, new StringContent(content));

        //if (!response.IsSuccessStatusCode) return null;
        //var json = await response.Content.ReadAsStringAsync();
        //var result = JsonSerializer.Deserialize<SessionResponse>(json);
        //        return result?.SessionId!;
        return url;
    }
}
