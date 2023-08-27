using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgCinema.Domain.Entities
{
    public class function
    {
        public int IdFuntion { get; set; }
        public int IdMovie { get; set; }
        public int IdRoom { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
    }
}
