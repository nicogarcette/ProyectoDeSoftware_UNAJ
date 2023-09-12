using NgCinema.Domain.Entities;

namespace NgCinema.Application.Interfaces.Querys
{
    public interface IFunctionQuery
    {
        Task<IEnumerable<Function>> GetFunctionsByDay(DateTime date);
        Task<IEnumerable<Function>> GetFunctionsByMovie(string movie);
        Task<IEnumerable<Function>> GetFunctionsByMovieDay(string movie, DateTime date);
    }
}
