using Microsoft.AspNetCore.Mvc;
using NgCinema.Application.DTOs;
using NgCinema.Application.DTOs.Response;
using NgCinema.Application.Interfaces.Services;
using NgCinema.Presentation.Handlers;

namespace NgCinema.Presentation.Controllers
{
    [Route("api/v1")]
    [ApiController]
    [TypeFilter(typeof(ExceptionFilter))]
    public class MovieController : ControllerBase
    {

        private readonly IMovieService _movieService;
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        [Route("Peliculas")]
        [ProducesResponseType(typeof(GetMovie), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 404)]
        public async Task<IActionResult> GetMovies()
        {
            List<GetMovie> value = await _movieService.GetAllMovies();

            return Ok(value);
        }

        [HttpGet]
        [Route("Pelicula/{id}")]
        [ProducesResponseType(typeof(GetMovie), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 404)]
        public async Task<IActionResult> GetMovie(int id)
        {
            GetMovie value = await _movieService.GetMovieById(id);

            return Ok(value);
        }

        [HttpPut]
        [Route("Pelicula/{id}")]
        [ProducesResponseType(typeof(GetMovie), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 404)]
        [ProducesResponseType(typeof(ErrorResponse), 409)]
        public async Task<IActionResult> UpdateMovie(int id, [FromBody] UpdateMovie movie)
        {
            var value = await _movieService.UpdateMovie(movie,id);

            return Ok(value);
        }

    }
}
