using NgCinema.Application.DTOs;
using NgCinema.Application.Exceptions;
using NgCinema.Application.Interfaces.Querys;
using NgCinema.Application.Interfaces.Services;
using NgCinema.Domain.Entities;

namespace NgCinema.Application.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieQuery _movieQuery;
        public MovieService(IMovieQuery movieQuery)
        {
            _movieQuery = movieQuery;
        }

        public List<GetMovie> GetAllMovies()
        {
            List<GetMovie> result;
            try
            {
                IEnumerable<Movie> list = _movieQuery.GetMovies();

                result = list
                        .Select(
                        m => new GetMovie()
                        {
                            IdMovie = m.IdMovie,
                            Poster = m.Poster,
                            Trailer = m.Trailer,
                            Genre = m.Genre.Name,
                            Title = m.Title,
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
