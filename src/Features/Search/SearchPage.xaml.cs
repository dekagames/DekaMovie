namespace DekaMovie.Features;

public partial class SearchPage : ContentPage
{
	public SearchPage(SearchViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}