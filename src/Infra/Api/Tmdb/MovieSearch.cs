namespace DekaMovie.Infra;

public class MovieSearch
{
    [JsonPropertyName("results")]
    public Movie[] Results { get; set; } = [];

    [JsonPropertyName("page")]
    public int Page { get; set; }

    [JsonPropertyName("total_pages")]
    public int TotalPages { get; set; }

    [JsonPropertyName("total_results")]
    public int TotalResults { get; set; }
}