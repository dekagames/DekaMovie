namespace DekaMovie
{
    public partial class AppShellViewModel(ILoginService loginService) : BaseViewModel
    {
        readonly ILoginService _loginService = loginService;

        [RelayCommand]
        void Logout()
        {
            _loginService.LogoutSessionAsync();
            Preferences.Default.Clear();
            Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
