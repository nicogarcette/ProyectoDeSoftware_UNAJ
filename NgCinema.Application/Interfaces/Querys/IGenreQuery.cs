using NgCinema.Domain.Entities;

namespace NgCinema.Application.Interfaces.Querys
{
    public interface IGenreQuery
    {
        Task<Genre> GetGenreById(int id);
    }
}
