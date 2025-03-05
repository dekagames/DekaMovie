namespace DekaMovie.Features;

public class BaseResponse
{
    [JsonPropertyName("success")]  
    public bool Sucess { get; set; } = false;
}
