using NgCinema.Application.DTOs.Function;
using NgCinema.Application.DTOs.Genre;

namespace NgCinema.Application.DTOs
{
    public class GetMovie
    {
        public int IdMovie { get; set; }
        public string Title { get; set; }
        public string synopsis { get; set; }
        public string Poster { get; set; }
        public string Trailer { get; set; }
        public GenreDto Genre { get; set; }
        public List<FunctionDto> functions{get; set;}
    }
}
