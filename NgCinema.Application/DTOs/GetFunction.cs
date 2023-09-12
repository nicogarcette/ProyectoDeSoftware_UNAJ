namespace NgCinema.Application.DTOs
{
    public class GetFunction
    {
        public int IdFuntion { get; set; }
        public string Movie { get; set; }
        public string Room { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
    }
}
