﻿namespace DekaMovie.Features;

public class MovieDetail : Movie
{
    [JsonPropertyName("budget")]
    public int Budget { get; set; }    

    [JsonPropertyName("homepage")]
    public string? HomePage { get; set; }
    
    [JsonPropertyName("imdb_id")]
    public string? ImdbId { get; set; }    
    
    [JsonPropertyName("revenue")]
    public int Revenue { get; set; }
    
    [JsonPropertyName("runtime")]
    public int Runtime { get; set; }    
    
    [JsonPropertyName("status")]
    public string? Status { get; set; }
    
    [JsonPropertyName("tagline")]
    public string? TagLine { get; set; }

    [JsonPropertyName("genres")]
    public Genre[] Genres { get; set; } = [];

    [JsonPropertyName("origin_country")]
    public string[] OriginCountry { get; set; } = [];   

    [JsonPropertyName("production_companies")]
    public ProductionCompanies[] ProductionCompanies { get; set; } = [];
    
    [JsonPropertyName("production_countries")]
    public ProductionCountries[] ProductionCountries { get; set; } = [];

    [JsonPropertyName("spoken_languages")]
    public SpokenLanguages[] SpokenLanguages { get; set; } = [];

    [JsonPropertyName("belongs_to_collection")]
    public BelongsToCollection? BelongsToCollection { get; set; }
}
public class BelongsToCollection
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("poster_path")]
    public string? PosterPath { get; set; }

    [JsonPropertyName("backdrop_path")]
    public string? BackdropPath { get; set; }
}

public class Genre
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }
}

public class ProductionCompanies
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("logo_path")]
    public string? LogoPath { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("origin_country")]
    public string? OriginCountry { get; set; }
}

public class ProductionCountries
{
    [JsonPropertyName("iso_3166_1")]
    public string? Iso_3166_1 { get; set; }
    [JsonPropertyName("name")]
    public string? Name { get; set; }
}

public class SpokenLanguages
{
    [JsonPropertyName("english_name")]
    public string? EnglishName { get; set; }

    [JsonPropertyName("iso_639_1")]
    public string? Iso_639_1 { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }
}