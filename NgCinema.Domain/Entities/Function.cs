using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgCinema.Domain.Entities
{
    public class Function
    {
        public int IdFuntion { get; set; }
        public int IdMovie { get; set; }
        public int IdRoom { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }

        public Movie Movie { get; set; }
        public Room Room { get; set; }
        public IEnumerable<Ticket> Tickets { get; set; }
    }
}
