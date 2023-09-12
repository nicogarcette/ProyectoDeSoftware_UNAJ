using NgCinema.Domain.Entities;

namespace NgCinema.Application.Interfaces.Querys
{
    public interface IMovieQuery
    {
        IEnumerable<Movie> GetMovies();
        bool ExistMovie(int id);
    }
}
