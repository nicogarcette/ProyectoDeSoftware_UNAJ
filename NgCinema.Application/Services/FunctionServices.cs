using NgCinema.Application.DTOs;
using NgCinema.Application.Exceptions;
using NgCinema.Application.Interfaces.Command;
using NgCinema.Application.Interfaces.Querys;
using NgCinema.Application.Interfaces.Services;
using NgCinema.Domain.Entities;

namespace NgCinema.Application.Services
{
    public class FunctionServices : IFunctionService
    {
        private readonly IFunctionCommand _functionCommand;
        private readonly IFunctionQuery _functionQuery;
        private readonly IMovieQuery _movieQuery;
        private readonly IRoomQuery _roomQuery;

        public FunctionServices(IFunctionCommand functionCommand, IFunctionQuery functionQuery, IMovieQuery movieQuery,IRoomQuery roomQuery)
        {
            _functionCommand = functionCommand;
            _functionQuery = functionQuery;
            _movieQuery = movieQuery;
            _roomQuery = roomQuery;
        }

        public bool CreateFunction(CreateFunction createFunction)
        {
            if(!_movieQuery.ExistMovie(createFunction.IdMovie))
                throw new BussinesException("La pelicula no existe.");

            if(!_roomQuery.ExistRoom(createFunction.IdRoom))
                throw new BussinesException("La sala no existe.");

            bool insert;
            try
            {
                Function function = new Function()
                {
                    IdMovie = createFunction.IdMovie,
                    IdRoom = createFunction.IdRoom,
                    Date = createFunction.Date,
                    Time = createFunction.Time,
                };

                insert = _functionCommand.InsertFunction(function) > 0;
            }
            catch(Exception)
            {
                throw new BussinesException("no se ha podia insertar la funcion.");
            }

            return insert;
        }

        public async Task<List<GetFunction>> GetFunctionsByDay(int day)
        {
            List<GetFunction> result;

            try
            {
                DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, day);
                IEnumerable<Function> functions = await _functionQuery.GetFunctionsByDay(date);

                result = functions
                        .Select(
                        f => new GetFunction
                        {
                            IdFuntion = f.IdFuntion,
                            Date = DateOnly.FromDateTime(f.Date),
                            Time = TimeOnly.FromTimeSpan(f.Time),
                            Movie = f.Movie?.Title,
                            Room = f.Room?.Name
                        })
                        .ToList();
            }
            catch(Exception)
            {
                throw new BussinesException("error en la consulta.");
            }

            return result;
        }

        public async Task<List<GetFunction>> GetFunctionsByMovie(string movie)
        {
            List<GetFunction> result;
            try
            {
                IEnumerable<Function> functions = await _functionQuery.GetFunctionsByMovie(movie);

                result = functions
                        .Select(
                        f => new GetFunction
                        {
                            IdFuntion = f.IdFuntion,
                            Date = DateOnly.FromDateTime(f.Date),
                            Time = TimeOnly.FromTimeSpan(f.Time),
                            Movie = f.Movie?.Title,
                            Room = f.Room?.Name
                        })
                        .ToList();
            }
            catch(Exception)
            {
                throw new BussinesException("error en la consulta.");
            }


            return result;
        }

        public async Task<List<GetFunction>> GetFunctionsMovieDay(string movie, int day)
        {
            List<GetFunction> result;

            try
            {
                DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, day);
                IEnumerable<Function> functions = await _functionQuery.GetFunctionsByMovieDay(movie,date);

                result = functions
                        .Select(
                        f => new GetFunction
                        {
                            IdFuntion = f.IdFuntion,
                            Date = DateOnly.FromDateTime(f.Date),
                            Time = TimeOnly.FromTimeSpan(f.Time),
                            Movie = f.Movie?.Title,
                            Room = f.Room?.Name
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
