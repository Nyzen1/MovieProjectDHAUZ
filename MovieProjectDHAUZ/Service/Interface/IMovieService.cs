using MovieProjectDHAUZ.DataModel;
using MovieProjectDHAUZ.DTOs.Request;
using MovieProjectDHAUZ.DTOs.Response;

namespace MovieProjectDHAUZ.Service.Interface
{
    public interface IMovieService
    {
        Task<MovieResponseDto> Add(MovieRequestDto movieDto);
        Task<IEnumerable<MovieDataModel>> GetAllMovies();
        Task<MovieDataModel> UpdateMovie(int id, MovieRequestDto movieData);
        Task<bool> DeleteMovie(int id);
    }
}
