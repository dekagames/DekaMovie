namespace DekaMovie.Features;

public partial class LoginViewModel(ILoginService loginService) : BaseViewModel
{
    private readonly ILoginService _loginService = loginService;
    private readonly IPreferences _preferences = Preferences.Default;

    [RelayCommand]
    async Task LoginAsync()
    {
        try
        {
            var requestToken = await _loginService.GetTokenAsync();
            if (string.IsNullOrEmpty(requestToken)) return;

            _preferences.Set("RequestToken", requestToken);
            
            await Browser.Default.OpenAsync($"https://www.themoviedb.org/authenticate/{requestToken}", BrowserLaunchMode.SystemPreferred);
            // Espera a autenticação e verifica a sessão
            await Task.Delay(5000); // Ajustar conforme necessário
            
            await CheckSessionAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao autenticar: {ex.Message}");
        }
    }

    [RelayCommand]
    async Task CheckSessionAsync()
    {
        try
        {
            var requestToken = _preferences.Get("RequestToken", string.Empty);
            if (string.IsNullOrEmpty(requestToken)) return;

            var sessionId = await _loginService.GetSessionIdAsync(requestToken);
            if (!string.IsNullOrEmpty(sessionId))
            {
                _preferences.Set("SessionId", sessionId);
                await Shell.Current.GoToAsync(nameof(SearchPage));
            }        
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao verificar sessão: {ex.Message}");
        }
    }
}