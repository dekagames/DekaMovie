namespace DekaMovie.Features;

public partial class HomePage : ContentPage
{
	public HomePage(HomeViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}