using NgCinema.Domain.Entities;

namespace NgCinema.Application.Interfaces.Commands
{
    public interface ITicketCommand
    {
        Task<int> CreateTicket(List<Ticket> tickets);
    }
}
