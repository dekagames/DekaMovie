
namespace DekaMovie
{
    public partial class AppShell : Shell
    {
        readonly ITmdbApiService _tmdb;
        readonly ILoginService _loginService;

        readonly AppShellViewModel _viewModel;

        public AppShell(ITmdbApiService tmdb, ILoginService loginService)
        {
            InitializeComponent();
            _loginService = loginService;
            _tmdb = tmdb;
            BindingContext = _viewModel = new AppShellViewModel(_loginService);
            RegisterRoute();
        }

        private void RegisterRoute()
        {
            Routing.RegisterRoute($"//{nameof(MoviePage)}", typeof(MoviePage));
            Routing.RegisterRoute($"//{nameof(MoviePage)}/{nameof(MovieDetailsPage)}", typeof(MovieDetailsPage));
        }

        protected override void OnAppearing()
        { 
            _tmdb.Initialize();        
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            _viewModel.LogoutCommand.Execute(null);
            base.OnDisappearing();
        }
    }
}
