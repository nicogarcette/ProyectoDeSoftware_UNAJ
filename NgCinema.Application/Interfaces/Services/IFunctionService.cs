using NgCinema.Application.DTOs;
using NgCinema.Application.DTOs.Function;
using NgCinema.Application.DTOs.Ticket;

namespace NgCinema.Application.Interfaces.Services
{
    public interface IFunctionService
    {
        Task<GetFunction> CreateFunction(CreateFunction function);
        Task<FunctionDto> DeleteFunction(int id);

        Task<AvailableTicket> GetAvailableTickets(int id);
        Task<List<GetFunction>> FunctionsFilter(FunctionFilter functionFilter);

        Task<GetFunction> GetFunctionById(int id);
        Task<List<GetFunction>> GetFunctionsByDay(int day);
        Task<List<GetFunction>> GetFunctionsByMovie(string movie);
        Task<List<GetFunction>> GetFunctionsMovieDay(string movie, int day);

    }
}
