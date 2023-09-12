namespace NgCinema.Application.DTOs
{
    public class CreateFunction
    {
        public int IdMovie { get; set; }
        public int IdRoom { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
    }
}
