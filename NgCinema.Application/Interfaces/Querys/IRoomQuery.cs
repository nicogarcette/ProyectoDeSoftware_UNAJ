using NgCinema.Domain.Entities;

namespace NgCinema.Application.Interfaces.Querys
{
    public interface IRoomQuery
    {
        IEnumerable<Room> GetRooms();
        bool ExistRoom(int id);

    }
}
