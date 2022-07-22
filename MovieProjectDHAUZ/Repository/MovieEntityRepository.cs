using MovieProjectDHAUZ.Context;
using MovieProjectDHAUZ.DataModel;
using MovieProjectDHAUZ.Repository.Interface;

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
    }
}
