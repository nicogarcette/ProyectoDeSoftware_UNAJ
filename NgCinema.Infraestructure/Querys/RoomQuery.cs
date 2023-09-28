using NgCinema.Application.Interfaces.Querys;
using NgCinema.Domain.Entities;
using NgCinema.Infraestructure.Persistence;

namespace NgCinema.Infraestructure.Querys
{
    public class RoomQuery : IRoomQuery
    {
        private readonly ApplicationDbContext _context;

        public RoomQuery(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Room> GetRoomById(int id)
        {
            return  _context.Rooms.FirstOrDefault(r => r.IdRoom == id);
        }

        public IEnumerable<Room> GetRooms()
        {
            return _context.Rooms.ToList();
        }
    }
}
