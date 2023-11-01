using NgCinema.Application.DTOs;

namespace NgCinema.Application.Interfaces.Services
{
    public interface IMovieService
    {
        Task<List<GetMovie>> GetAllMovies();
        Task<GetMovie> UpdateMovie(UpdateMovie movie, int id);
        Task<GetMovie> GetMovieById(int id);
    }
}
