namespace DekaMovie.Infra;
public interface IApiRestfull
{
    #region Login
    Task<TokenResponse> GetRequestTokenAsync();
    Task<AuthResponse> CreateSessionAsync(string requestToken);
    #endregion
}

public class ApiRestfull : IApiRestfull
{
    public ApiRestfull()
    {
        if (string.IsNullOrWhiteSpace(BaseService.BaseUrl) || string.IsNullOrWhiteSpace(BaseService.ApiKey) || string.IsNullOrWhiteSpace(BaseService.AccessToken))
            BaseService.InitializeAsync().Wait();
    }

    #region Login
    public async Task<TokenResponse> GetRequestTokenAsync()
    {
        return await BaseService.BaseUrl
            .WithHeader("accept", "application/json")
            .WithOAuthBearerToken(BaseService.AccessToken)
            .AppendPathSegment("/authentication/token/new")
            .GetJsonAsync<TokenResponse>();
    }

    public Task<AuthResponse> CreateSessionAsync(string requestToken)
    {
        throw new NotImplementedException();
    }
 
    #endregion
}