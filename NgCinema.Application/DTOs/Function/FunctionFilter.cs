using System.ComponentModel.DataAnnotations;

namespace NgCinema.Application.DTOs.Function
{
    public class FunctionFilter
    {
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }
        public string? Movie { get; set; }
        public int? IdGenre { get; set; }
    }
}
