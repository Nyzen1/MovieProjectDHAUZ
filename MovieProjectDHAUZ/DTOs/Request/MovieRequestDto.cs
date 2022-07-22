namespace MovieProjectDHAUZ.DTOs.Request
{
    public class MovieRequestDto
    {

        public string IdImdb { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string Genre { get; set; }
        public bool Watched { get; set; }
        public float UserScore { get; set; }
        public bool GetDetailsImdbToEmptyFilds { get; set; }

    }
}
