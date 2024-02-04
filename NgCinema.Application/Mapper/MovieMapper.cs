using NgCinema.Application.DTOs;
using NgCinema.Application.DTOs.Function;
using NgCinema.Application.DTOs.Genre;
using NgCinema.Domain.Entities;

namespace NgCinema.Application.Mapper
{
    public static class MovieMapper
    {
        public static GetMovie Mapper(this Movie movie)
        {
            return new GetMovie()
            {
                IdMovie = movie.IdMovie,
                Poster = movie.Poster,
                Trailer = movie.Trailer,
                Title = movie.Title,
                synopsis = movie.synopsis,
                Genre = new GenreDto
                {
                    Id = movie.IdGenre,
                    Name = movie.Genre.Name,
                },
                functions = movie.Functions.Select(f => new FunctionDto
                {
                    IdFuntion = f.IdFuntion,
                    Date = DateOnly.FromDateTime(f.Date),
                    Time = TimeOnly.FromTimeSpan(f.Time)
                }).ToList()
            };

        }

    }
}
