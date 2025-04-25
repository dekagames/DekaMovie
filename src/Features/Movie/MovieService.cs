using DekaMovie.Helpers;

namespace DekaMovie.Features;

public interface IMovieService
{
    Task<List<Movie>> SearchMoviesAsync(string query);
    Task<MovieDetail> GetMovieDetailAsync(int movieId);
}

public class MovieService(ITmdbApiService api, IStoreService storeService) : IMovieService
{
    readonly ITmdbApiService _api = api;
    readonly IStoreService _storeService = storeService;

    public async Task<List<Movie>> SearchMoviesAsync(string query)
    {
        var result = await _api.SearchMoviesAsync(new SearchMovie() { Query = query });
        return result?.Results.ToList()!;
    }

    public async Task<MovieDetail> GetMovieDetailAsync(int movieId)
    {
        var movie = await _api.GetMovieDetailAsync(movieId);
        movie.PosterPath = ImageHelper.GetImageUrl(movie.PosterPath!);
        return movie;
    }

    public async Task AddToFavoritesAsync(Movie movie)
    {
        if (Connectivity.NetworkAccess.Equals(NetworkAccess.Internet))
        {
            await _api.AddMovieToFavorites(movie);
        }
        _storeService.AddMovieToFavorites(movie);
    }

}