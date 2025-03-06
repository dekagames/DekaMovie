namespace DekaMovie.Helpers;
public static class ImageHelper
{
    public static string GetImageUrl(string path, int width = 500) 
        => !string.IsNullOrWhiteSpace(path) ? 
        $"https://image.tmdb.org/t/p/w{width}/{path}" 
        : "noimage.png";
}
