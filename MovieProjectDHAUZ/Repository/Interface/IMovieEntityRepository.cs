using MovieProjectDHAUZ.DataModel;
using MovieProjectDHAUZ.DTOs.Request;

namespace MovieProjectDHAUZ.Repository.Interface
{
    public interface IMovieEntityRepository
    {
        Task SaveChanges();
        Task<MovieDataModel> AddMovie(MovieDataModel movie);
        Task<IEnumerable<MovieDataModel>> GetAllMovies();
        Task<MovieDataModel> UpdateMovie(int id, MovieRequestDto movieData);
        Task<bool> DeleteMovie(int id);
    }
}
