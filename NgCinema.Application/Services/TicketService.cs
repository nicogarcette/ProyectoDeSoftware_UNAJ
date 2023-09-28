using NgCinema.Application.DTOs;
using NgCinema.Application.DTOs.Genre;
using NgCinema.Application.DTOs.Movie;
using NgCinema.Application.DTOs.Ticket;
using NgCinema.Application.Exceptions;
using NgCinema.Application.Interfaces.Commands;
using NgCinema.Application.Interfaces.Querys;
using NgCinema.Application.Interfaces.Services;
using NgCinema.Domain.Entities;

namespace NgCinema.Application.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketCommand _ticketCommand; 
        private readonly IFunctionQuery _functionQuery; 

        public TicketService(ITicketCommand ticketCommand, IFunctionQuery functionQuery)
        {
            _ticketCommand = ticketCommand;
            _functionQuery = functionQuery;
        }

        public async Task<TicketDto> CreateTicket(CreateTicket createTicket, int idFunction)
        {
            Function function = await _functionQuery.GetFunctionById(idFunction);

            if(function == null)
                throw new NotFoundException("La funcion no existe.");

            if(function.Tickets.Count() >= function.Room.Capacity)
                throw new BussinesException("Sala sin cupo de ticket.");

            int ticketAvaileble = function.Room.Capacity - function.Tickets.Count();

            if(createTicket.Quantity > ticketAvaileble)
                throw new BussinesException($"La cantidad de tickets solicitados supera el cupo de sala. Ticket disponibles:{ticketAvaileble}");


            List<Ticket> tickets = new List<Ticket>();

            for(int i = 0; i < createTicket.Quantity; i++)
            {

                Ticket ticket = new Ticket()
                {
                    IdFunction = idFunction,
                    User = createTicket.User,
                };
                tickets.Add(ticket);
            }

            bool insert = await _ticketCommand.CreateTicket(tickets) > 0;

            if(!insert)
                return null;

           

            TicketDto ticketsList = new TicketDto()
            {
                Tickets =  tickets.Select(t => new GetTicket()
                {
                    IdTicket = t.IdTicket
                }).ToList(),
                Function = new GetFunction
                {
                    IdFuntion = function.IdFuntion,
                    Movie = new MovieDto {
                        IdMovie = function.IdMovie,
                        Title = function.Movie.Title,
                        Poster = function.Movie.Poster,
                        Genre = new GenreDto {
                            Id = function.Movie.Genre.IdGenre,
                            Name = function.Movie.Genre.Name,
                        }
                    },
                    Room = new GetRoom {
                        IdRoom = function.IdRoom,
                        Capacity = function.Room.Capacity,
                        Name = function.Room.Name
                    },
                    Date = DateOnly.FromDateTime(function.Date),
                    Time = TimeOnly.FromTimeSpan(function.Time)
                },
                User = createTicket.User
            };

            return ticketsList;
        }
    }
}
