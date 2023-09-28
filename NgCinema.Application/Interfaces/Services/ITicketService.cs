using NgCinema.Application.DTOs;
using NgCinema.Application.DTOs.Ticket;

namespace NgCinema.Application.Interfaces.Services
{
    public interface ITicketService 
    {
        Task<TicketDto> CreateTicket(CreateTicket createTicket, int idFunction);
    }
}
