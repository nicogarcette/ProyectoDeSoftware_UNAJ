using NgCinema.Application.DTOs;
using NgCinema.Application.Interfaces.Commands;
using NgCinema.Domain.Entities;
using NgCinema.Infraestructure.Persistence;

namespace NgCinema.Infraestructure.Commands
{
    public class MovieCommand : IMovieCommand
    {
        private readonly ApplicationDbContext _context;

        public MovieCommand(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> UpdateMovie(Movie movie, UpdateMovie updateMovie)
        {
            movie.Title = updateMovie.Title;
            movie.Poster = updateMovie.Poster;
            movie.synopsis = updateMovie.synopsis;
            movie.Trailer = updateMovie.Trailer;

            return await _context.SaveChangesAsync();
        }
    }
}
