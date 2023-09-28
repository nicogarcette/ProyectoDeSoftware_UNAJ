using NgCinema.Application.DTOs;
using NgCinema.Domain.Entities;

namespace NgCinema.Application.Interfaces.Commands
{
    public interface IMovieCommand
    {
        Task<int> UpdateMovie(Movie movie, UpdateMovie updateMovie);
    }
}
