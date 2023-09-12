using Microsoft.EntityFrameworkCore;
using NgCinema.Application.Interfaces.Querys;
using NgCinema.Domain.Entities;
using NgCinema.Infraestructure.Persistence;

namespace NgCinema.Infraestructure.Querys
{
    public class MovieQuery : IMovieQuery
    {
        private readonly ApplicationDbContext _context;

        public MovieQuery(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public bool ExistMovie(int id)
        {
            return _context.Movies.Any(m => m.IdMovie == id);
        }

        public IEnumerable<Movie> GetMovies()
        {
            return _context.Movies.Include(m => m.Genre).ToList();
        }
    }
}
