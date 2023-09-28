using NgCinema.Application.DTOs;
using NgCinema.Application.DTOs.Function;
using NgCinema.Application.DTOs.Genre;
using NgCinema.Application.DTOs.Movie;
using NgCinema.Application.DTOs.Ticket;
using NgCinema.Application.Exceptions;
using NgCinema.Application.Interfaces.Command;
using NgCinema.Application.Interfaces.Querys;
using NgCinema.Application.Interfaces.Services;
using NgCinema.Application.Validators;
using NgCinema.Domain.Entities;


namespace NgCinema.Application.Services
{
    public class MovieServices : IFunctionService
    {
        private readonly IFunctionCommand _functionCommand;
        private readonly IFunctionQuery _functionQuery;
        private readonly IMovieQuery _movieQuery;
        private readonly IRoomQuery _roomQuery;

        public MovieServices(IFunctionCommand functionCommand, IFunctionQuery functionQuery, IMovieQuery movieQuery,IRoomQuery roomQuery)
        {
            _functionCommand = functionCommand;
            _functionQuery = functionQuery;
            _movieQuery = movieQuery;
            _roomQuery = roomQuery;
        }

        public async  Task<GetFunction> CreateFunction(CreateFunction createFunction)
        {
            Movie movie = await _movieQuery.GetMovieById(createFunction.IdMovie);
            if(movie == null)
                throw new NotFoundException("La pelicula no existe.");

            Room room = await _roomQuery.GetRoomById(createFunction.IdRoom);
            if(room == null)
                throw new NotFoundException("La sala no existe.");

            bool valid = await ValidateDateTime(createFunction);

            if(!valid)
                throw new ConflictException("El horario se solapa con otra funcion.");


            Function function = new Function()
            {
                IdMovie = createFunction.IdMovie,
                IdRoom = createFunction.IdRoom,
                Date = createFunction.Date,
                Time = TimeSpan.Parse(createFunction.Time)
            };

            bool insert = await _functionCommand.InsertFunction(function) > 0;

            if(!insert)
                return null;


            GetFunction getFunction = new GetFunction()
            {
                IdFuntion = function.IdFuntion,
                Date = DateOnly.FromDateTime(function.Date),
                Time = TimeOnly.FromTimeSpan(function.Time),
                Movie = new MovieDto
                {
                    IdMovie = function.IdMovie,
                    Title = movie.Title,
                    Poster = movie.Poster,
                    Genre = new GenreDto
                    {
                        Id = movie.IdGenre,
                        Name = movie.Genre.Name
                    }
                },
                Room = new GetRoom
                {
                    IdRoom = function.IdRoom,
                    Name = room.Name,
                    Capacity = room.Capacity
                }
            };

            return getFunction;
        }

        public async Task<bool> ValidateDateTime(CreateFunction createfunction) 
        {
            TimeSpan timeToInsert = ValidData.ValidTime(createfunction.Time);

            IEnumerable<Function> functionList = await _functionQuery.GetAllFunctionsByRoomDay(createfunction.IdRoom, createfunction.Date);
            
            if(!functionList.Any())
                return true;

            foreach (var function in functionList)
            {
                if(function.Time == timeToInsert)
                    return false;
                
                TimeSpan FunctionTimeDuration;
                
                if(timeToInsert > function.Time)
                {
                    FunctionTimeDuration = function.Time.Add(new TimeSpan(2, 30, 0));

                    if(!(timeToInsert >= FunctionTimeDuration))
                        return false;
                }
                else
                {
                    FunctionTimeDuration = function.Time.Subtract(new TimeSpan(2, 30, 0));

                    if(!(timeToInsert <= FunctionTimeDuration))
                        return false;
                }
            }

            return true;
        }

        public async Task<FunctionDto> DeleteFunction(int id)
        {
            Function function = await _functionQuery.GetFunctionById(id);

            if(function == null)
                throw new NotFoundException("el id ingresado no corresponde a una funcion.");

            if(function.Tickets.Any())
                throw new ConflictException("La funcion ha vendido tickets. No se puede eliminar.");

            bool delete = await _functionCommand.DeleteFunction(function) > 0;

            if(!delete)
                return null;

            FunctionDto functionDelete = new FunctionDto
            {
                IdFuntion = function.IdFuntion,
                Date = DateOnly.FromDateTime(function.Date),
                Time = TimeOnly.FromTimeSpan(function.Time)
            };

            return functionDelete;
        }

        public async Task<AvailableTicket> GetAvailableTickets(int id)
        {
            Function function = await _functionQuery.GetFunctionById(id);

            if(function == null)
                throw new NotFoundException("el id ingresado no corresponde a una funcion.");

            int totalTickets = function.Room.Capacity;
            int ticketSold = function.Tickets.Count();

            int quantityAvailable = totalTickets - ticketSold;

            return new AvailableTicket { Quantity = quantityAvailable };
        }

        public async Task<GetFunction> GetFunctionById(int id)
        {
            Function function = await _functionQuery.GetFunctionById(id);

            if(function == null)
                throw new NotFoundException("el id ingresado no corresponde a una funcion.");
            
            GetFunction getFunction = new GetFunction() { 
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

        public async Task<List<GetFunction>> FunctionsFilter(FunctionFilter functionFilter)
        {
            IEnumerable<Function> functions = await _functionQuery.GetFunctionsByFilter(functionFilter);

            List<GetFunction> result = functions.Select(
                                       f => new GetFunction
                                       {
                                           IdFuntion = f.IdFuntion,
                                           Date = DateOnly.FromDateTime(f.Date),
                                           Time = TimeOnly.FromTimeSpan(f.Time),
                                           Movie = new MovieDto
                                           {
                                               IdMovie = f.IdMovie,
                                               Title = f.Movie?.Title,
                                               Poster = f.Movie?.Poster,
                                               Genre = new GenreDto
                                               {
                                                   Id = f.Movie.IdGenre,
                                                   Name = f.Movie.Genre.Name
                                               }
                                           },
                                           Room = new GetRoom
                                           {
                                               IdRoom = f.IdRoom,
                                               Name = f.Room.Name,
                                               Capacity = f.Room.Capacity
                                           }
                                       })
                                       .ToList();

            return result;
        }

        public async Task<List<GetFunction>> GetFunctionsByDay(int day)
        {
            List<GetFunction> result;

            DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, day);
            IEnumerable<Function> functions = await _functionQuery.GetFunctionsByDay(date);

            result = functions
                    .Select(
                    f => new GetFunction
                    {
                        IdFuntion = f.IdFuntion,
                        Date = DateOnly.FromDateTime(f.Date),
                        Time = TimeOnly.FromTimeSpan(f.Time),
                        Movie = new MovieDto
                        {
                            IdMovie = f.IdMovie,
                            Title = f.Movie?.Title,
                            Poster = f.Movie?.Poster,
                            Genre = new GenreDto
                            {
                                Id = f.Movie.IdGenre,
                                Name = f.Movie.Genre.Name
                            }
                        },
                        Room = new GetRoom
                        {
                            IdRoom = f.IdRoom,
                            Name = f.Room.Name,
                            Capacity = f.Room.Capacity
                        }
                    })
                    .ToList();
          
            return result;
        }

        public async Task<List<GetFunction>> GetFunctionsByMovie(string movie)
        {
            List<GetFunction> result;

            IEnumerable<Function> functions = await _functionQuery.GetFunctionsByMovie(movie);

            result = functions
                    .Select(
                    f => new GetFunction
                    {
                        IdFuntion = f.IdFuntion,
                        Date = DateOnly.FromDateTime(f.Date),
                        Time = TimeOnly.FromTimeSpan(f.Time),
                        Movie = new MovieDto
                        {
                            IdMovie = f.IdMovie,
                            Title = f.Movie?.Title,
                            Poster = f.Movie?.Poster,
                            Genre = new GenreDto
                            {
                                Id = f.Movie.IdGenre,
                                Name = f.Movie.Genre.Name
                            }
                        },
                        Room = new GetRoom
                        {
                            IdRoom = f.IdRoom,
                            Name = f.Room.Name,
                            Capacity = f.Room.Capacity
                        }
                    })
                    .ToList();
     
            return result;
        }

        public async Task<List<GetFunction>> GetFunctionsMovieDay(string movie, int day)
        {
            List<GetFunction> result;

            DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, day);
            IEnumerable<Function> functions = await _functionQuery.GetFunctionsByMovieDay(movie,date);

            result = functions
                    .Select(
                    f => new GetFunction
                    {
                        IdFuntion = f.IdFuntion,
                        Date = DateOnly.FromDateTime(f.Date),
                        Time = TimeOnly.FromTimeSpan(f.Time),
                        Movie = new MovieDto{
                           IdMovie = f.IdMovie,
                           Title = f.Movie?.Title,
                           Poster = f.Movie?.Poster,
                           Genre = new GenreDto
                           {
                               Id = f.Movie.IdGenre,
                               Name = f.Movie?.Genre?.Name
                           }
                        },
                        Room = new GetRoom
                        {
                            IdRoom = f.IdRoom,
                            Name = f.Room.Name,
                            Capacity = f.Room.Capacity
                        }
                    })
                    .ToList();
          
            return result;
        }
    }
}
