using NgCinema.Application.DTOs;
using NgCinema.Application.Exceptions;
using NgCinema.Application.Interfaces.Querys;
using NgCinema.Application.Interfaces.Services;
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
            try
            {
               IEnumerable<Room> rooms = _roomQuery.GetRooms();

                result = rooms
                        .Select(
                        r=> new GetRoom()
                        {
                            IdRoom = r.IdRoom,
                            Name = r.Name,
                            Capacity = r.Capacity
                        })
                        .ToList();
            }
            catch(Exception)
            {
                throw new BussinesException("error en la consulta.");
            }
            return result;
        }
    }
}
