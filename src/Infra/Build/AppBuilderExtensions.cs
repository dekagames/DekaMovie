namespace DekaMovie.Infra;

public static class AppBuilderExtensions
{
    //const string BaseFirebase = "";
    public static MauiAppBuilder RegisterService(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<IApiRestfull, ApiRestfull>();
        builder.Services.AddSingleton<ILoginService, LoginService>();
        builder.Services.AddSingleton<ISearchService, SearchService>();
        return builder;
    }

    public static MauiAppBuilder RegisterServiceViewModel(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<AppShell>();

        builder.Services.AddSingleton<LoginPage>();
        builder.Services.AddSingleton<LoginViewModel>();

        builder.Services.AddSingleton<HomePage>();
        builder.Services.AddSingleton<HomeViewModel>();
        
        builder.Services.AddSingleton<SearchPage>();
        builder.Services.AddSingleton<SearchViewModel>();

        return builder;
    }
}
