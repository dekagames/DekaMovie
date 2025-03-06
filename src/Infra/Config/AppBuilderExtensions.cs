namespace DekaMovie.Infra;
public static class AppBuilderExtensions
{    
    public static MauiAppBuilder RegisterService(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<ITmdbApiService, TmdbApiService>();
        builder.Services.AddSingleton<ILoginService, LoginService>();
        builder.Services.AddSingleton<IMovieService, MovieService>();
        builder.Services.AddSingleton<IStoreService, StoreService>();
        return builder;
    }

    public static MauiAppBuilder RegisterServiceViewModel(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<AppShell>();
        builder.Services.AddSingleton<AppShellViewModel>();

        builder.Services.AddSingleton<LoginPage>();
        builder.Services.AddSingleton<LoginViewModel>();

        builder.Services.AddSingleton<HomePage>();
        builder.Services.AddSingleton<HomeViewModel>();
        
        builder.Services.AddSingleton<MoviePage>();
        builder.Services.AddSingleton<MovieViewModel>();

        builder.Services.AddSingleton<MovieDetailsPage>();
        builder.Services.AddSingleton<MovieDetailsViewModel>();

        return builder;
    }
}
