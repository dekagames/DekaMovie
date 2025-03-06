namespace DekaMovie.Features;
public partial class MovieDetailsViewModel(IMovieService movieService) : BaseViewModel
{
    private readonly IMovieService _movieService = movieService;
    
    
    [ObservableProperty]
    MovieDetail _movieDetail;

    public override void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query["Movie"] is Movie movie)
        {    
            Task.Run(async () => await LoadMovie(movie.Id));
        }
    }

    [RelayCommand]
    async Task LoadMovie(int movieId)
    {
        try
        {
            MovieDetail = await _movieService.GetMovieDetailAsync(movieId);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao autenticar: {ex.Message}");
        }        
    }
    [RelayCommand]
    private void AddToFavorites()
    {
    
    }
}