using NgCinema.Application.DTOs;
using NgCinema.Application.DTOs.Function;
using NgCinema.Application.DTOs.Genre;
using NgCinema.Application.Exceptions;
using NgCinema.Application.Interfaces.Commands;
using NgCinema.Application.Interfaces.Querys;
using NgCinema.Application.Interfaces.Services;
using NgCinema.Domain.Entities;

namespace NgCinema.Application.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieQuery _movieQuery;
        private readonly IMovieCommand _movieCommand;
        private readonly IGenreQuery _genreQuery;
        public MovieService(IMovieQuery movieQuery,IMovieCommand movieCommand, IGenreQuery genreQuery)
        {
            _movieQuery = movieQuery;
            _movieCommand = movieCommand;
            _genreQuery = genreQuery;
        }

        public async Task<List<GetMovie>> GetAllMovies()
        {
            List<GetMovie> result;
           
            IEnumerable<Movie> list = await _movieQuery.GetMovies();

            result = list
                    .Select(
                    m => new GetMovie()
                    {
                        IdMovie = m.IdMovie,
                        Poster = m.Poster,
                        Trailer = m.Trailer,
                        synopsis = m.synopsis,
                        Title = m.Title,
                        Genre = new GenreDto
                        {
                            Id = m.IdGenre,
                            Name = m.Genre.Name,
                        }
                    })
                    .ToList();

            return result;
        }

        public async Task<GetMovie> GetMovieById(int id)
        {
            Movie movie = await _movieQuery.GetMovieById(id);

            if(movie == null)
                throw new NotFoundException("La pelicula no existe.");

            GetMovie getMovie = new GetMovie()
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

            bool update = await _movieCommand.UpdateMovie(movie,updateMovie) > 0;

            if(!update)
                return null;

            GetMovie movieDto = new GetMovie()
            {
                IdMovie = id,
                Poster = updateMovie.Poster,
                Trailer = updateMovie.Trailer,
                Title = updateMovie.Title,
                synopsis = updateMovie.synopsis,
                Genre = new GenreDto
                {
                    Id = genre.IdGenre,
                    Name = genre.Name,
                },
                functions = movie.Functions.Select(f => new FunctionDto
                {
                    IdFuntion = f.IdFuntion,
                    Date = DateOnly.FromDateTime(f.Date),
                    Time = TimeOnly.FromTimeSpan(f.Time)
                }).ToList()
            };

            return movieDto;
        }
    }
}
