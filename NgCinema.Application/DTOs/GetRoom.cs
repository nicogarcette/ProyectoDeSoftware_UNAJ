using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgCinema.Application.DTOs
{
    public class GetRoom
    {
        public int IdRoom { get; set; }
        public int Capacity { get; set; }
        public string Name { get; set; }
    }
}
