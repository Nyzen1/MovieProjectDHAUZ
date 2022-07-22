using MovieProjectDHAUZ.DTOs.Request;
using MovieProjectDHAUZ.DTOs.Response;

namespace MovieProjectDHAUZ.Service.Interface
{
    public interface IMovieService
    {
        Task<MovieResponseDto> Add(MovieRequestDto movieDto);
    }
}
