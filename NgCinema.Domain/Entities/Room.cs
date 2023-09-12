namespace NgCinema.Domain.Entities
{
    public class Room
    {
        public int IdRoom { get; set; }
        public int Capacity { get; set; }
        public  string Name { get; set; }

        public IEnumerable<Function> Functions { get; set; }
    }
}
