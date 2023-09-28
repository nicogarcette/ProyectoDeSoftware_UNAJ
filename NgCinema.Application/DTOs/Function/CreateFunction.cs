using System.ComponentModel.DataAnnotations;

namespace NgCinema.Application.DTOs.Function
{
    public class CreateFunction
    {
        public int IdMovie { get; set; }
        public int IdRoom { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public string Time { get; set; }
    }
}
