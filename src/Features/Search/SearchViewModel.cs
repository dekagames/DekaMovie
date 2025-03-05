namespace DekaMovie.Features;

public partial class SearchViewModel : BaseViewModel
{
    [ObservableProperty]
    ObservableCollection<Movie> _movies = [];
}