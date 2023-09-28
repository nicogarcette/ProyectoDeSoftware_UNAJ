using NgCinema.Domain.Entities;

namespace NgCinema.Application.Interfaces.Querys
{
    public interface IMovieQuery
    {
        Task<Movie> GetMovieById(int id);
        IEnumerable<Movie> GetMovies();
        Task<bool> ExistMovie(string movie);
    }
}
