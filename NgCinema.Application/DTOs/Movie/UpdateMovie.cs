using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgCinema.Application.DTOs
{
    public class UpdateMovie
    {
        public string Title { get; set; }
        public string synopsis { get; set; }
        public string Poster { get; set; }
        public string Trailer { get; set; }
        public int IdGenre { get; set; }
    }
}
