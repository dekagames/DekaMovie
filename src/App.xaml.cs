namespace DekaMovie;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        BaseService.InitializeAsync().Wait();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new AppShell());
    }
}