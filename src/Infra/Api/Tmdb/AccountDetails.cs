namespace DekaMovie.Infra;

public class AccountDetails
{
    [JsonPropertyName("avatar")]
    public Avatar? Avatar { get; set; }

    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("iso_639_1")]
    public string? Iso_639_1 { get; set; }

    [JsonPropertyName("iso_3166_1")]
    public string? Iso_3166_1 { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("include_adult")]
    public bool IncludeAdult { get; set; }

    [JsonPropertyName("username")]
    public string? Username { get; set; }
}

public class Avatar
{
    [JsonPropertyName("gravatar")]
    public Gravatar? Gravatar { get; set; }

    [JsonPropertyName("tmdb")]
    public Tmdb? Tmdb { get; set; }
}

public class Gravatar
{
    [JsonPropertyName("hash")]

    public string? Hash { get; set; }
}

public class Tmdb
{
    [JsonPropertyName("avatar_path")]
    public object? AvatarPath { get; set; }
}