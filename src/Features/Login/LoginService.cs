namespace DekaMovie.Features;

public interface ILoginService
{
    Task<string> GetTokenAsync();
    Task<string> GetSessionIdAsync(string requestToken);
    Task<bool> LogoutSessionAsync();
    Task<string> GuestSessionIdAsync();
}

public class LoginService(ITmdbApiService api) : ILoginService
{
    readonly ITmdbApiService _api = api;
    readonly IPreferences _preferences = Preferences.Default;

    public async Task<string> GetTokenAsync()
    {
        var result = await _api.GetRequestTokenAsync();
        return result != null ? result?.RequestToken! : null!;
    }

    public async Task<string> GetSessionIdAsync(string requestToken)
    {
        var result = await _api.CreateSessionAsync(requestToken);
                
        return result != null ? result?.SessionId! : null!;
    }

    public async Task<string> GuestSessionIdAsync()
    {
        var result = await _api.CreateGuestSessionAsync();

        return result != null ? result?.GuestSessionId! : null!;
    }

    public async Task<int> GetAccountId()
    {
        var result = await _api.GetAccountDetails();

        return result.Id; 
    }

    public async Task<bool> LogoutSessionAsync()
    {
        string sessionId = _preferences.Get("SessionId", string.Empty);
        if (!string.IsNullOrEmpty(sessionId))
        {
            var result = await _api.DeleteSessionAsync(sessionId);
            return result.Sucess;
        }
        return false;
    }
}
