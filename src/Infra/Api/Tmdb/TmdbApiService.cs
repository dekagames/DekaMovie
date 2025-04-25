namespace DekaMovie.Infra;
public interface ITmdbApiService
{
    void Initialize();

    #region Login
    Task<AuthResponse> ValidateKeyAsync();
    Task<TokenResponse> GetRequestTokenAsync();
    Task<SessionResponse> CreateSessionAsync(string requestToken);

    Task<AccountDetails> GetAccountDetails();

    Task<SessionResponse> CreateGuestSessionAsync();
    Task<BaseResponse> DeleteSessionAsync(string sessionId);
    #endregion
    #region Movie
    Task<MovieSearch> SearchMoviesAsync(SearchMovie request);
    Task<MovieDetail> GetMovieDetailAsync(int movieId);
    #endregion
    Task<bool> AddMovieToFavorites(Movie movie);
}

public class TmdbApiService : ITmdbApiService
{
    string? ApiKey;
    string? BaseUrl;
    string? AccessToken;

    #region Init

    public void Initialize()
    {
        if (string.IsNullOrWhiteSpace(BaseUrl)
            || string.IsNullOrWhiteSpace(ApiKey)
            || string.IsNullOrWhiteSpace(AccessToken))
            LoadConfigurationAsync().Wait();
    }
    async Task LoadConfigurationAsync()
    {
        var settings = await ConfigService.LoadSettingsAsync();
        ApiKey = settings.TMDbApiKey;
        BaseUrl = settings.TMDbBaseUrl;
        AccessToken = settings.TMDbAccessToken;
    }
    #endregion

    #region Login
    public async Task<TokenResponse> GetRequestTokenAsync()
    {
        return await BaseUrl
            .WithHeader("accept", "application/json")
            .WithOAuthBearerToken(AccessToken)
            .AppendPathSegment("/authentication/token/new")
            .GetJsonAsync<TokenResponse>();
    }

    public async Task<SessionResponse> CreateSessionAsync(string requestToken)
    {
        var result = await BaseUrl
            .WithHeader("accept", "application/json")
            .WithOAuthBearerToken(AccessToken)
            .AppendPathSegment("/authentication/session/new")
            .PostJsonAsync(new SessionRequest { RequestToken = requestToken })
            .ReceiveJson<SessionResponse>();
        return result;
    }

    public async Task<AccountDetails> GetAccountDetails() 
    { 
        var result = await BaseUrl
            .WithHeader("accept", "application/json")
            .WithOAuthBearerToken(AccessToken)
            .AppendPathSegment("/account/account_id")
            .GetJsonAsync<AccountDetails>();

        return result;
    }

    public async Task<SessionResponse> CreateGuestSessionAsync()
    {
        var result = await BaseUrl
            .WithHeader("accept", "application/json")
            .WithOAuthBearerToken(AccessToken)
            .AppendPathSegment("/authentication/guest_session/new")
            .GetJsonAsync<SessionResponse>();
        return result;
    }

    public async Task<BaseResponse> DeleteSessionAsync(string sessionId)
    {
        var result = await BaseUrl
            .WithHeader("accept", "application/json")
            .WithOAuthBearerToken(AccessToken)
            .AppendPathSegment("/authentication/session")
            .SendJsonAsync(HttpMethod.Delete, new SessionResponse { SessionId = sessionId })
            .ReceiveJson<BaseResponse>();
        return result;
    }

    public async Task<AuthResponse> ValidateKeyAsync()
    {
        var result = await BaseUrl
            .WithHeader("accept", "application/json")
            .WithOAuthBearerToken(AccessToken)
            .AppendPathSegment("/authentication")
            .GetJsonAsync<AuthResponse>();
        return result;
    }
    #endregion

    #region Movie
    public async Task<MovieSearch> SearchMoviesAsync(SearchMovie request)
    {
        var result = await BaseUrl
            .WithHeader("accept", "application/json")
            .WithOAuthBearerToken(AccessToken)
            .AppendPathSegment("/search/movie")
            .AppendQueryParam("query", request.Query)
            .AppendQueryParam("language", request.Language)
            .AppendQueryParam("include_adult", request.IncludeAdult)
            .AppendQueryParam("page", request.Page)
            .AppendQueryParam("primary_release_year", request.PrimaryReleaseYear)
            .AppendQueryParam("region", request.Region)
            .AppendQueryParam("year", request.Year)
            .GetJsonAsync<MovieSearch>();

        return result;
    }

    public async Task<MovieDetail> GetMovieDetailAsync(int movieId)
    {
        var result = await BaseUrl
           .WithHeader("accept", "application/json")
           .WithOAuthBearerToken(AccessToken)
           .AppendPathSegment("/movie")
           .AppendPathSegment(movieId)
           .AppendQueryParam("language", CultureInfo.CurrentCulture.Name)
           .GetJsonAsync<MovieDetail>();
        return result;
    }

    public Task<bool> AddMovieToFavorites(Movie movie)
    {
        throw new NotImplementedException();
    }
    #endregion
}