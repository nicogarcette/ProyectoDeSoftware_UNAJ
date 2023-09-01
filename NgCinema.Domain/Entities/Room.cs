using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
