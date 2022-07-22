using MovieProjectDHAUZ.DataModel;

namespace MovieProjectDHAUZ.Repository.Interface
{
    public interface IMovieEntityRepository
    {
        Task SaveChanges();
        Task<MovieDataModel> AddMovie(MovieDataModel movie);
    }
}
