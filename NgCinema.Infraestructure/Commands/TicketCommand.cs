using NgCinema.Application.Interfaces.Commands;
using NgCinema.Domain.Entities;
using NgCinema.Infraestructure.Persistence;
using System.Net.Sockets;

namespace NgCinema.Infraestructure.Commands
{
    public class TicketCommand : ITicketCommand
    {
        private readonly ApplicationDbContext _context;
        public TicketCommand(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateTicket(List<Ticket> tickets)
        {
            _context.Tickets.AddRange(tickets);
            return await _context.SaveChangesAsync();
        }
    }
}
