using NgCinema.Application.DTOs;
using NgCinema.Application.Interfaces.Querys;
using NgCinema.Application.Interfaces.Services;
using NgCinema.Application.Mapper;
using NgCinema.Domain.Entities;

namespace NgCinema.Application.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomQuery _roomQuery;

        public RoomService(IRoomQuery roomQuery)
        {
            _roomQuery = roomQuery;
        }

        public List<GetRoom> GetAllRooms()
        {
            List<GetRoom> result;

            IEnumerable<Room> rooms = _roomQuery.GetRooms();

            result = rooms.Select(r => r.Mapper()).ToList();

            return result;
        }
    }
}
