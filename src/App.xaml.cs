namespace DekaMovie;
public partial class App : Application
{
    readonly ITmdbApiService _tmdb;    
    readonly ILoginService _loginService;
    
    public App(ITmdbApiService tmdb, ILoginService loginService)
    {
        InitializeComponent();
        _tmdb = tmdb;
        _loginService = loginService;
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new AppShell(_tmdb, _loginService));
    }   
}