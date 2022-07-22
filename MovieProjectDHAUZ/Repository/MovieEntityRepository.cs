using MovieProjectDHAUZ.Context;
using MovieProjectDHAUZ.DataModel;
using MovieProjectDHAUZ.DTOs.Request;
using MovieProjectDHAUZ.Repository.Interface;
using System.Data.Entity;

namespace MovieProjectDHAUZ.Repository
{
    public class MovieEntityRepository : IMovieEntityRepository
    {
        private readonly MovieContext _context;

        public MovieEntityRepository(MovieContext context)
        {
            _context = context;
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
        public async Task<MovieDataModel> AddMovie(MovieDataModel movie)
        {
            var createdMovie = await _context.AddAsync(movie);
            return createdMovie.Entity;
        }

        public async Task<IEnumerable<MovieDataModel>> GetAllMovies()
        {
            var listMovies = _context.MovieDataModel;
            return listMovies;
        }

        public async Task<MovieDataModel> UpdateMovie(int id, MovieRequestDto movieData)
        {
            var movieExistent = await _context.FindAsync<MovieDataModel>(id);

            if (movieExistent != null)
            {
                movieExistent.Name = movieData.Name ?? movieExistent.Name;
                movieExistent.Description = movieData.Description ?? movieExistent.Description;
                movieExistent.Genre = movieData.Genre ?? movieExistent.Genre;
                movieExistent.ReleaseDate = movieData.ReleaseDate ?? movieExistent.ReleaseDate;
                movieExistent.Watched = movieData.Watched;
                movieExistent.UserScore = movieData.UserScore ?? movieExistent.UserScore;

                return movieExistent;
            }
            return null;
        }

        public async Task<bool> DeleteMovie(int id)
        {
            var movieExistent = await _context.FindAsync<MovieDataModel>(id);

            if (movieExistent != null)
            {
                _context.MovieDataModel.Remove(movieExistent);
                return true;
            }
            return false;
        }
    }
}
