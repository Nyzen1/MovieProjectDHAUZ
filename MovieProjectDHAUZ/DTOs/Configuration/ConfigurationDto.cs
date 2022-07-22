namespace MovieProjectDHAUZ.DTOs.Configuration
{
    public class ConfigurationDto
    {
        public Logging Logging { get; set; }
        public string OmdbApiKey { get; set; }
        public string OmdBaseUrl { get; set; }
        public Connectionstrings ConnectionStrings { get; set; }
    }

    public class Logging
    {
        public Loglevel LogLevel { get; set; }
    }

    public class Loglevel
    {
        public string Default { get; set; }
        public string MicrosoftAspNetCore { get; set; }
    }

    public class Connectionstrings
    {
        public string MoviesDb { get; set; }
    }

}
