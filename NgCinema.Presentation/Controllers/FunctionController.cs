using Microsoft.AspNetCore.Mvc;
using NgCinema.Application.DTOs;
using NgCinema.Application.DTOs.Function;
using NgCinema.Application.DTOs.Response;
using NgCinema.Application.DTOs.Ticket;
using NgCinema.Application.Interfaces.Services;
using NgCinema.Presentation.Handlers;

namespace NgCinema.Presentation.Controllers
{
    [Route("api/v1")]
    [ApiController]
    [TypeFilter(typeof(ExceptionFilter))]
    public class FunctionController : ControllerBase
    {
        private readonly IFunctionService _functionService;
        private readonly ITicketService _ticketService;

        public FunctionController(IFunctionService functionService, ITicketService ticketService)
        {
            _functionService = functionService;
            _ticketService = ticketService;
        }

        [HttpGet]
        [Route("Funcion")]
        [ProducesResponseType(typeof(List<GetFunction>), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> FilterFunction([FromQuery] FunctionFilter filter)
        {
            var result = await _functionService.FunctionsFilter(filter);

            return Ok(result);
        }

        [HttpPost]
        [Route("Funcion")]
        [ProducesResponseType(typeof(GetFunction),StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 409)]
        public async Task<IActionResult> CreateFunction([FromBody] CreateFunction createFunction)
        {
            var value = await _functionService.CreateFunction(createFunction);

            if(value == null)
                return BadRequest(new ErrorResponse{Message = "No se ha insertado la funcion." });

            return StatusCode(StatusCodes.Status201Created, value);
        }

        [HttpGet]
        [Route("Funcion/{id}")]
        [ProducesResponseType(typeof(GetFunction), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 404)]
        public async Task<IActionResult> GetFunction(int id)
        {
            GetFunction value = await _functionService.GetFunctionById(id);

            if(value == null)
                return BadRequest(new ErrorResponse { Message = "Funcion no encontrada." });

            return Ok(value);
        }

        [HttpDelete]
        [Route("Funcion/{id}")]
        [ProducesResponseType(typeof(FunctionDto), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 404)]
        [ProducesResponseType(typeof(ErrorResponse), 409)]
        public async Task<IActionResult> DeleteFunction(int id)
        {
            var value = await _functionService.DeleteFunction(id);

            if(value == null)
                return BadRequest(new ErrorResponse { Message = "no se ha podido eliminar." });

            return Ok(value);
        }

        [HttpGet]
        [Route("Funcion/{id}/tickets")]
        [ProducesResponseType(typeof(AvailableTicket), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 404)]
        public async Task<IActionResult> ViewAvailableTickets(int id)
        {
            var result = await _functionService.GetAvailableTickets(id);

            return Ok(result);
        }


        [HttpPost]
        [Route("Funcion/{id}/tickets")]
        [ProducesResponseType(typeof(TicketDto), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 404)]
        public async Task<IActionResult> CreateTicket(int id, CreateTicket ticket)
        {
            var result = await _ticketService.CreateTicket(ticket, id);

            return Ok(result);
        }

    }
}
