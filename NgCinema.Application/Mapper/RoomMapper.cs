using NgCinema.Application.DTOs;
using NgCinema.Domain.Entities;

namespace NgCinema.Application.Mapper
{
    public static class RoomMapper
    {
        public static GetRoom Mapper(this Room room)
        {
            return new GetRoom()
            {
                IdRoom = room.IdRoom,
                Name = room.Name,
                Capacity = room.Capacity
            };
        }

    }
}
