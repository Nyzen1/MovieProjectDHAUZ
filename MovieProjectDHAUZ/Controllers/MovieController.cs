using Microsoft.AspNetCore.Mvc;
using MovieProjectDHAUZ.DataModel;
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

        [HttpPost]
        public async Task<IActionResult> Add(MovieRequestDto movie)
        {
            var addedMovie = await _movieService.Add(movie);

            return new OkObjectResult(addedMovie);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var movies = await _movieService.GetAllMovies();

            if (movies?.Any() ?? false)
                return new OkObjectResult(movies);

            return NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, MovieRequestDto movieDto)
        {
            var updatedMovie = await _movieService.UpdateMovie(id, movieDto);

            if (updatedMovie == null)
                return BadRequest("Por favor, valide os parametros e tente novamente");

            return new OkObjectResult(updatedMovie);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _movieService.DeleteMovie(id))
                return Ok();

            return NotFound();
        }
    }
}
