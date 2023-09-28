using Microsoft.Extensions.DependencyInjection;
using NgCinema.Application.Interfaces.Command;
using NgCinema.Application.Interfaces.Querys;
using NgCinema.Application.Interfaces.Services;
using NgCinema.Application.Services;
using NgCinema.ConsoleApp.Menu;
using NgCinema.Infraestructure.Commands;
using NgCinema.Infraestructure.Persistence;
using NgCinema.Infraestructure.Querys;

internal class Program 
{
    private static void Main(string[] args) 
    {
        #region InyectionDependecy
        var serviceProvider = new ServiceCollection()
            .AddTransient<IFunctionService, MovieServices>()
            .AddTransient<IMovieService, MovieService>()
            .AddTransient<IRoomService, RoomService>()
            .AddDbContext<ApplicationDbContext>()
            .AddScoped<IFunctionQuery,FunctionQuery>()
            .AddScoped<IFunctionCommand,FunctionCommand>()
            .AddScoped<IMovieQuery,MovieQuery>()
            .AddScoped<IRoomQuery,RoomQuery>()
            .AddScoped<Options,Options>()
            .BuildServiceProvider();
        #endregion

        Menu menu = new Menu(serviceProvider);
        menu.Start();

        Console.ReadKey();
    }
}