using Microsoft.EntityFrameworkCore;
using NgCinema.Application.Interfaces.Querys;
using NgCinema.Domain.Entities;
using NgCinema.Infraestructure.Persistence;

namespace NgCinema.Infraestructure.Querys
{
    public class FunctionQuery : IFunctionQuery
    {
        private readonly ApplicationDbContext _context;

        public FunctionQuery(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Function>> GetFunctionsByDay(DateTime date)
        {
            return _context.Functions.Where(f => f.Date == date)
                                    .Include(f => f.Movie)
                                    .Include(f => f.Room)
                                    .ToList();
        }

        public async Task<IEnumerable<Function>> GetFunctionsByMovie(string movie)
        {
            return _context.Functions.Where(f => f.Movie.Title.Contains(movie))
                                    .Include(f => f.Movie)
                                    .Include(f => f.Room)
                                    .ToList();
        }

        public async Task<IEnumerable<Function>> GetFunctionsByMovieDay(string movie, DateTime date)
        {
            return _context.Functions.Where(f => (f.Movie.Title.Contains(movie)) && f.Date == date)
                                    .Include(f => f.Movie)
                                    .Include(f => f.Room)
                                    .ToList();
        }
    }
}
