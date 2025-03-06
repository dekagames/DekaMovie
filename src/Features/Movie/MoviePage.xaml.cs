namespace DekaMovie.Features;

public partial class MoviePage : ContentPage
{
	public MoviePage(MovieViewModel viewModel)
	{
		InitializeComponent();        
		BindingContext = viewModel;
    }
}