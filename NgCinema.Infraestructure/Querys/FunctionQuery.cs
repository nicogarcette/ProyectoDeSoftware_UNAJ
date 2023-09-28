using Microsoft.EntityFrameworkCore;
using NgCinema.Application.DTOs.Function;
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

        public async Task<IEnumerable<Function>> GetAllFunctionsByRoomDay(int idRoom, DateTime date)
        {
            return _context.Functions.Where(f => f.IdRoom == idRoom && f.Date == date).ToList();
        }

        public async Task<Function> GetFunctionById(int id)
        {
            return _context.Functions.Include(f => f.Movie.Genre)
                                    .Include(f => f.Room)
                                    .Include(f => f.Tickets)
                                    .FirstOrDefault(f=> f.IdFuntion == id);
        }

        public async Task<IEnumerable<Function>> GetFunctionsByDay(DateTime date)
        {
            return _context.Functions.Where(f => f.Date == date)
                                    .Include(f => f.Movie)
                                    .Include(f => f.Room)
                                    .ToList();
        }

        public async Task<IEnumerable<Function>> GetFunctionsByFilter(FunctionFilter filter)
        {
            IQueryable<Function> query = _context.Functions.Include(f => f.Movie.Genre)
                                                            .Include(f => f.Room);

            if(!string.IsNullOrEmpty(filter.Movie))
            {
                query = query.Where(f => f.Movie.Title.Contains(filter.Movie));
            }

            if(filter.Date.HasValue)
            {
                query = query.Where(f => f.Date.Date == filter.Date.Value.Date);
            }

            if(filter.IdGenre.HasValue)
            {
                query = query.Where(f => f.Movie.IdGenre == filter.IdGenre.Value);
            }

            return await query.ToListAsync();
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
