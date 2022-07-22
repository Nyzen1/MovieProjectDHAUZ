using MovieProjectDHAUZ.DTOs.Request;

namespace MovieProjectDHAUZ.DataModel
{
    public class MovieDataModel
    {
        public MovieDataModel()
        {

        }

        public MovieDataModel(MovieRequestDto request)
        {
            IdImdb = request.IdImdb;
            Name = request.Name;
            Description = request.Description;
            ReleaseDate = request.ReleaseDate ?? DateTime.Now;
            Genre = request.Genre;
            Watched = request.Watched;
            UserScore = request.UserScore;
        }

        public int Id { get; set; }
        public string IdImdb { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public bool Watched { get; set; }
        public float UserScore { get; set; }
    }
}
