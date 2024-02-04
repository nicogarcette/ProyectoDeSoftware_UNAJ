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

        public Task<bool> ExistMovie(string movie)
        {
            return _context.Movies.AnyAsync(m => m.Title == movie);
        }

        public async Task<Movie> GetMovieById(int id)
        {
            return _context.Movies.Include(m => m.Genre)
                                    .Include(f => f.Functions).
                                    FirstOrDefault(m => m.IdMovie == id);
        }

        public async Task<IEnumerable<Movie>> GetMovies()
        {
            return await _context.Movies.Include(m => m.Genre).Include(f => f.Functions).ToListAsync();
        }
    }
}
