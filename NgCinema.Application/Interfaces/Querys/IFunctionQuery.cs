using NgCinema.Application.DTOs.Function;
using NgCinema.Domain.Entities;

namespace NgCinema.Application.Interfaces.Querys
{
    public interface IFunctionQuery
    {
        Task<Function> GetFunctionById(int id);
        Task<IEnumerable<Function>> GetAllFunctionsByRoomDay(int idRoom, DateTime date);
        Task<IEnumerable<Function>> GetFunctionsByFilter(FunctionFilter filter);
        Task<IEnumerable<Function>> GetFunctionsByDay(DateTime date);
        Task<IEnumerable<Function>> GetFunctionsByMovie(string movie);
        Task<IEnumerable<Function>> GetFunctionsByMovieDay(string movie, DateTime date);

    }
}
