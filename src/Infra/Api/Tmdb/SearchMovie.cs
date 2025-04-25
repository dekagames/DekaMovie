namespace DekaMovie.Infra;
public class SearchMovie
{
    [JsonPropertyName("query")]
    public string Query { get; set; } = string.Empty;

    [JsonPropertyName("include_adult")]
    public bool IncludeAdult { get; set; } = false;

    [JsonPropertyName("language")]
    public string Language { get; set; } = CultureInfo.CurrentCulture.Name;

    [JsonPropertyName("primary_release_year")]
    public string PrimaryReleaseYear { get; set; } = string.Empty;

    [JsonPropertyName("page")]
    public int Page { get; set; } = 1;

    [JsonPropertyName("region")]
    public string Region { get; set; } = string.Empty;

    [JsonPropertyName("year")]
    public string Year { get; set; } = string.Empty;
}

