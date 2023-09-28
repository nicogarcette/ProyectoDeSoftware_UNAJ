using NgCinema.Application.Interfaces.Querys;
using NgCinema.Domain.Entities;
using NgCinema.Infraestructure.Persistence;

namespace NgCinema.Infraestructure.Querys
{
    public class GenreQuery : IGenreQuery
    {
        private readonly ApplicationDbContext _context;

        public GenreQuery(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Genre> GetGenreById(int id)
        {
            return _context.Genres.FirstOrDefault(g => g.IdGenre == id);
        }
    }
}
