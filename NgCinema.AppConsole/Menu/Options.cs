using Microsoft.IdentityModel.Tokens;
using NgCinema.Application.DTOs;
using NgCinema.Application.DTOs.Function;
using NgCinema.Application.Exceptions;
using NgCinema.Application.Interfaces.Services;
using NgCinema.ConsoleApp.Utilities;

namespace NgCinema.ConsoleApp.Menu
{
    public class Options
    {
        private readonly IFunctionService _functionService;
        private readonly IMovieService _MovieService;
        private readonly IRoomService _RoomService;

        public Options(IFunctionService functionService, IMovieService movieService, IRoomService roomService)
        {
            _functionService = functionService;
            _MovieService = movieService;
            _RoomService = roomService;
        }
        public async void GetFunctionByDay()
        {
            List<GetFunction> result;

            int maxDay = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            Console.WriteLine("Seleccione dia de funcion:");
            int day = ValidData.AskForNumber("Dia", maxDay);

            try
            {
                result = await _functionService.GetFunctionsByDay(day);

                if(result.IsNullOrEmpty())
                    Console.WriteLine("Sin resultados!");
                else
                {
                    result.ForEach(f =>
                    {
                        Console.WriteLine($"-- {f.Movie} {f.Room} {f.Date} {f.Time}");
                    });
                }
            }
            catch(BussinesException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public async void GetFunctionByMovie()
        {
            List<GetFunction> result;

            Console.WriteLine("Ingrese el titulo de la Pelicula:");
            string movie = ValidData.AskForString("Pelicula");

            try
            {
                result = await _functionService.GetFunctionsByMovie(movie);

                if(result.IsNullOrEmpty())
                    Console.WriteLine("Sin resultados!");
                else
                {
                    result.ForEach(f =>
                    {
                        Console.WriteLine($"-- {f.Movie} {f.Room} {f.Date} {f.Time}");
                    });
                }
            }
            catch(BussinesException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public async void GetFunctionMovieDay()
        {
            List<GetFunction> result;

            Console.WriteLine("Busqueda por titulo de pelicula:");
            string movie = ValidData.AskForString("Pelicula");

            Console.WriteLine("Busqueda por dia:");
            int day = ValidData.AskForNumber("Dia");

            try
            {
                result = await _functionService.GetFunctionsMovieDay(movie,day);

                if(result.IsNullOrEmpty())
                    Console.WriteLine("Sin resultados!");
                else
                {
                    result.ForEach(f =>
                    {
                        Console.WriteLine($"-- {f.Movie} {f.Room} {f.Date} {f.Time}");
                    });
                }
            }
            catch(BussinesException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Create()
        {
            ShowAllMovies();
            Console.WriteLine("\nSeleccione el numero de la pelicula :");
            int idMovie = ValidData.AskForNumber("Pelicula");

            ShowAllRooms();
            Console.WriteLine("Seleccione numero de sala :");
            int idRoom = ValidData.AskForNumber("Sala");

            int maxDay = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            int minDay = DateTime.Now.Day;
            Console.WriteLine("Solo se podran crear funciones desde el dia de hoy hasta el ultimo dia del mes.");
            int day = ValidData.AskForNumber("Dia", maxDay, minDay);
            Console.WriteLine("El rango horario debe ser entre 12hs a 23hs.");
            int hour = ValidData.AskForNumber("Hora",23,12);

            CreateFunction function = new CreateFunction()
            {
                IdMovie = idMovie,
                IdRoom = idRoom,
                Date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, day),
                //Time = new TimeSpan(hour, 0, 0),
            };

            bool result = false;
            string value = string.Empty;
            try
            {
                //result = _functionService.CreateFunction(function);
                value = result ? "\nFuncion registrada correctamente\n" : "\nFuncion no registrada\n";
            }
            catch(BussinesException e)
            {
                value = e.Message;
            }

            Console.WriteLine(value);
            Continue();
        }

        public void ShowAllMovies() {

            Console.WriteLine("Listado de peliculas:\n");   
            List<GetMovie> result = _MovieService.GetAllMovies();

            if(result.IsNullOrEmpty())
                Console.WriteLine("Sin resultados!");
            else
            {
                result.ForEach(m =>
                {
                    Console.WriteLine($"{m.IdMovie} - {m.Title} - {m.Genre}");
                });
            }
        }

        public void ShowAllRooms()
        {
            List<GetRoom> result = _RoomService.GetAllRooms();

            if(result.IsNullOrEmpty())
                Console.WriteLine("Sin resultados!");
            else
            {
                Console.WriteLine("Listado de salas:\n");
                result.ForEach(r =>
                {
                    Console.WriteLine($"{r.IdRoom} - {r.Name} - {r.Capacity}");
                });
            }
        }

        public static void Continue()
        {
            Console.WriteLine("\nPresiona para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
