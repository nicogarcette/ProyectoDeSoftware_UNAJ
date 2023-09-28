using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgCinema.Application.DTOs.Ticket
{
    public class TicketDto
    {
        public List<GetTicket> Tickets { get; set; }

        public GetFunction Function { get; set; }
        public string User { get; set; }
    }
}
