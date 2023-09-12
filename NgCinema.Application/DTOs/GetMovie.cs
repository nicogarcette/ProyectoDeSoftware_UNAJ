namespace NgCinema.Application.DTOs
{
    public class GetMovie
    {
        public int IdMovie { get; set; }
        public string Title { get; set; }
        public string synopsis { get; set; }
        public string Poster { get; set; }
        public string Trailer { get; set; }
        public string Genre { get; set; }
    }
}
