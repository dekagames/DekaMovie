namespace DekaMovie.Features;
public class TokenResponse : BaseResponse
{
    [JsonPropertyName("request_token")]
    public string RequestToken { get; set; } = string.Empty;
    
    [JsonPropertyName("expires_at")]
    public string ExpiresAt { get; set; } = string.Empty;
}

public class AuthResponse : BaseResponse
{
    [JsonPropertyName("status_message")]
    public string StatusMessage { get; set; } = string.Empty;
    
    [JsonPropertyName("status_code")]
    public string StatusCode { get; set; } = string.Empty;
}

public class SessionResponse
{
    [JsonPropertyName("session_id")]
    public string SessionId { get; set; } = string.Empty;
}