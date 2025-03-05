namespace DekaMovie.Features;

public interface ISearchService
{
    Task<List<Movie>> SearchMoviesAsync(string query);
}

public class SearchService : ISearchService
{
    private readonly HttpClient _httpClient = new();
    
    public SearchService() => Task.Run(BaseService.InitializeAsync);

    public async Task<List<Movie>> SearchMoviesAsync(string query)
    {

        
        var url = $"{BaseService.BaseUrl}/search/movie?api_key={BaseService.ApiKey}&query={query}&language=pt-BR";
        var response = await _httpClient.GetAsync(url);

        if (!response.IsSuccessStatusCode) return null!;

        var json = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<MovieSearchResult>(json);
        return result?.Results!;
    }    
}