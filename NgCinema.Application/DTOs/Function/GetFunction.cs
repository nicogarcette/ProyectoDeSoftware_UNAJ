using NgCinema.Application.DTOs.Movie;

namespace NgCinema.Application.DTOs
{
    public class GetFunction
    {
        public int IdFuntion { get; set; }
        public MovieDto Movie { get; set; }
        public GetRoom Room { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
    }
}
