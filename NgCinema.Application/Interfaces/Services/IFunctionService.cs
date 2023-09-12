using NgCinema.Application.DTOs;

namespace NgCinema.Application.Interfaces.Services
{
    public interface IFunctionService
    {
        bool CreateFunction(CreateFunction function);
        Task<List<GetFunction>> GetFunctionsByDay(int day);
        Task<List<GetFunction>> GetFunctionsByMovie(string movie);
        Task<List<GetFunction>> GetFunctionsMovieDay(string movie, int day);

    }
}
