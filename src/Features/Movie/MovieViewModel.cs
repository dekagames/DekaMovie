using DekaMovie.Helpers;

namespace DekaMovie.Features;

public partial class MovieViewModel(IMovieService searchService) : BaseViewModel
{
    private readonly IMovieService _searchService = searchService;
    [ObservableProperty]
    ObservableCollection<Movie> _movies = [];

    [ObservableProperty]
    Movie _selectedMovie;

    [RelayCommand]
    async Task Search(string query)
    {
        if (string.IsNullOrWhiteSpace(query)) return;

        var movies = await _searchService.SearchMoviesAsync(query);
        Movies.Clear();

        foreach (var movie in movies)
        {
            movie.PosterPath = ImageHelper.GetImageUrl(movie.PosterPath!);
            Movies.Add(movie);
        }
    }

    [RelayCommand]
    public async Task SelectMovie(Movie movie)
    {
        await GoToMovieDetailsAsync(movie);
        SelectedMovie = null!;
    }
            
    async Task GoToMovieDetailsAsync(Movie movie)
    {
        if (movie == null) return;

        var navigationParameter = new Dictionary<string, object>
        {
            { "Movie", movie}
        };
        await Shell.Current.GoToAsync($"//{nameof(MoviePage)}/{nameof(MovieDetailsPage)}", navigationParameter);
        
    }
}