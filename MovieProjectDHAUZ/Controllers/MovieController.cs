using Microsoft.AspNetCore.Mvc;
using MovieProjectDHAUZ.DTOs.Request;
using MovieProjectDHAUZ.DTOs.Response;
using MovieProjectDHAUZ.Service.Interface;

namespace MovieProjectDHAUZ.Controllers
{
    [Route("[Controller]")]
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpPost(Name = "Movie")]
        public async Task<ActionResult<MovieResponseDto>> Add(MovieRequestDto movie)
        {
            return await _movieService.Add(movie);
        }
    }
}
