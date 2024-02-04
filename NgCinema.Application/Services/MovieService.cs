using NgCinema.Application.DTOs;
using NgCinema.Application.Exceptions;
using NgCinema.Application.Interfaces.Commands;
using NgCinema.Application.Interfaces.Querys;
using NgCinema.Application.Interfaces.Services;
using NgCinema.Application.Mapper;
using NgCinema.Domain.Entities;

namespace NgCinema.Application.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieQuery _movieQuery;
        private readonly IMovieCommand _movieCommand;
        private readonly IGenreQuery _genreQuery;
        public MovieService(IMovieQuery movieQuery, IMovieCommand movieCommand, IGenreQuery genreQuery)
        {
            _movieQuery = movieQuery;
            _movieCommand = movieCommand;
            _genreQuery = genreQuery;
        }

        public async Task<List<GetMovie>> GetAllMovies()
        {
            List<GetMovie> result;

            IEnumerable<Movie> list = await _movieQuery.GetMovies();

            result = list.Select(m => m.Mapper()).ToList();

            return result;
        }

        public async Task<GetMovie> GetMovieById(int id)
        {
            Movie movie = await _movieQuery.GetMovieById(id);

            if(movie == null)
                throw new NotFoundException("La pelicula no existe.");

            GetMovie getMovie = movie.Mapper();

            return getMovie;
        }

        public async Task<GetMovie> UpdateMovie(UpdateMovie updateMovie, int id)
        {
            Movie movie = await _movieQuery.GetMovieById(id);
            if(movie == null)
                throw new NotFoundException("La pelicula no existe.");

            Genre genre = await _genreQuery.GetGenreById(updateMovie.IdGenre);
            if(genre == null)
                throw new BussinesException("El genero ingresado no existe.");

            bool existMovie = await _movieQuery.ExistMovie(updateMovie.Title);
            if(existMovie)
                throw new ConflictException("Ya existe una pelicula con ese nombre.");

            bool update = await _movieCommand.UpdateMovie(movie, updateMovie) > 0;

            GetMovie? movieDto = update ? movie.Mapper() : null;

            return movieDto;
        }
    }
}
