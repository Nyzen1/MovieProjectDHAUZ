using MovieProjectDHAUZ.DataModel;
using MovieProjectDHAUZ.DTOs.Request;
using MovieProjectDHAUZ.DTOs.Response;
using MovieProjectDHAUZ.Infra;
using MovieProjectDHAUZ.Repository.Interface;
using MovieProjectDHAUZ.Service.Interface;

namespace MovieProjectDHAUZ.Service
{
    public class MovieService : IMovieService
    {
        private readonly IMovieEntityRepository _movieEntityRepository;
        private readonly RestOmdb _rest;
        public MovieService(IMovieEntityRepository movieEntityRepository)
        {
            _movieEntityRepository = movieEntityRepository;
            _rest = new RestOmdb("http://www.omdbapi.com/");
        }

        public async Task<MovieResponseDto> Add(MovieRequestDto movieDto)
        {
            var movieDetails = await _rest.GetAsync<MovieOmdbResponse>($"?i={movieDto.IdImdb}&r=json");

            if (movieDto.GetDetailsImdbToEmptyFilds)
            {
                if (string.IsNullOrEmpty(movieDto.Description))
                    movieDto.Description = movieDetails.Plot;

                if (string.IsNullOrEmpty(movieDto.Genre))
                    movieDto.Genre = movieDetails.Genre;

                if (string.IsNullOrEmpty(movieDto.Name))
                    movieDto.Name = movieDetails.Title;

                if (movieDto.ReleaseDate == null)
                {
                    DateTime releasedDate;
                    DateTime.TryParse(movieDetails.Released, out releasedDate);

                    movieDto.ReleaseDate = releasedDate;
                }
            }

            var movie = new MovieDataModel(movieDto);
            var createdMovie = await _movieEntityRepository.AddMovie(movie);

            try
            {
                await _movieEntityRepository.SaveChanges();
                return new MovieResponseDto(createdMovie, movieDetails.Ratings);
            }
            catch (Exception e)
            {
                throw new Exception("Não foi possível inserir o filme, tente novamente e revise os dados");
            }
        }

        public async Task<IEnumerable<MovieDataModel>> GetAllMovies()
        {
            var listMovies = await _movieEntityRepository.GetAllMovies();
            return listMovies;
        }

        public async Task<MovieDataModel> UpdateMovie(int id, MovieRequestDto movieData)
        {
            var updateMovie = await _movieEntityRepository.UpdateMovie(id, movieData);
            await _movieEntityRepository.SaveChanges();
            return updateMovie;
        }

        public async Task<bool> DeleteMovie(int id)
        {
            var deleteMovie = await _movieEntityRepository.DeleteMovie(id);
            await _movieEntityRepository.SaveChanges();
            return deleteMovie;
        }
    }
}
