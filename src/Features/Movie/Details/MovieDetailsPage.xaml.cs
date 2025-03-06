namespace DekaMovie.Features;

public partial class MovieDetailsPage : ContentPage
{
	public MovieDetailsPage(MovieDetailsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
    }
}