using NgCinema.Application.DTOs;
using NgCinema.Application.DTOs.Genre;
using NgCinema.Application.DTOs.Movie;
using NgCinema.Domain.Entities;

namespace NgCinema.Application.Mapper
{
    public static class FunctionMapper
    {
        public static GetFunction Convert(this Function function)
        {
            GetFunction getFunction = new GetFunction()
            {
                IdFuntion = function.IdFuntion,
                Date = DateOnly.FromDateTime(function.Date),
                Time = TimeOnly.FromTimeSpan(function.Time),
                Movie = new MovieDto
                {
                    IdMovie = function.IdMovie,
                    Title = function.Movie?.Title,
                    Poster = function.Movie?.Poster,
                    Genre = new GenreDto
                    {
                        Id = function.Movie.IdGenre,
                        Name = function.Movie.Genre.Name
                    }
                },
                Room = new GetRoom
                {
                    IdRoom = function.IdRoom,
                    Name = function.Room.Name,
                    Capacity = function.Room.Capacity
                }
            };

            return getFunction;
        }

    }
}
