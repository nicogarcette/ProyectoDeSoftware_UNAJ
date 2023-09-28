using NgCinema.Application.DTOs.Genre;

namespace NgCinema.Application.DTOs.Movie
{
    public class MovieDto
    {
        public int IdMovie { get; set; }
        public string Title { get; set; }
        public string Poster { get; set; }
        public GenreDto Genre { get; set; }
    }
}
