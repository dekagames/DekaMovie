namespace DekaMovie.Infra;
public interface IStoreService
{
    void AddMovieToFavorites(Movie movie);
    void RemoveMovieFromFavorites(int movieId);
    List<Movie> GetFavoriteMovies();
    bool IsMovieFavorite(int movieId);
}

public class StoreService : IStoreService
{    
    private static ILiteCollection<T> ConfigureDatabase<T>(string collection) where T : class
    {
        LiteDatabase db = new(Path.Combine(FileSystem.AppDataDirectory, "movies.db"));
        return db.GetCollection<T>(collection);
    }

    public void AddMovieToFavorites(Movie movie)
    {
        var collection = ConfigureDatabase<Movie>("favorites");

        if (collection.FindById(movie.Id) == null)
            collection.Insert(movie);
    }

    public void RemoveMovieFromFavorites(int movieId)
    {
        var collection = ConfigureDatabase<Movie>("favorites");
        collection.Delete(movieId);
    }

    public List<Movie> GetFavoriteMovies()
    {
        var collection = ConfigureDatabase<Movie>("favorites");
        return [.. collection.FindAll()];
    }

    public bool IsMovieFavorite(int movieId)
    {
        var collection =  ConfigureDatabase<Movie>("favorites");
        return collection.FindById(movieId) != null;
    }
}
