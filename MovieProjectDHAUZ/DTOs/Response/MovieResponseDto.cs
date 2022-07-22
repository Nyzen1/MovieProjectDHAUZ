using MovieProjectDHAUZ.DataModel;

namespace MovieProjectDHAUZ.DTOs.Response
{
    public class MovieResponseDto
    {
        public MovieResponseDto()
        {
        }

        public MovieResponseDto(MovieDataModel movieDataModel, List<Rating> scores)
        {
            Id = movieDataModel.Id;
            IdImdb = movieDataModel.IdImdb;
            Name = movieDataModel.Name;
            Description = movieDataModel.Description;
            ReleaseDate = movieDataModel.ReleaseDate;
            Genre = movieDataModel.Genre;
            Watched = movieDataModel.Watched;
            UserScore = movieDataModel.UserScore;
            ScoreMdb = scores;
        }

        public int Id { get; set; }
        public string IdImdb { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public bool Watched { get; set; }
        public float UserScore { get; set; }
        public List<Rating> ScoreMdb { get; set; }
    }
}
