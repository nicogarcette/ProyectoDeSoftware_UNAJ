using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NgCinema.Application.Interfaces.Command;
using NgCinema.Application.Interfaces.Commands;
using NgCinema.Application.Interfaces.Querys;
using NgCinema.Application.Interfaces.Services;
using NgCinema.Application.Services;
using NgCinema.Infraestructure.Commands;
using NgCinema.Infraestructure.Persistence;
using NgCinema.Infraestructure.Querys;

namespace NgCinema.Infraestructure
{
    public static class InjectionDependency
    {
        public static void AddInfraestructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ConnectionStringSQLServer"));
            });

            services.AddScoped<IFunctionQuery, FunctionQuery>();
            services.AddScoped<IMovieQuery, MovieQuery>();
            services.AddScoped<IRoomQuery, RoomQuery>();
            services.AddScoped<IGenreQuery, GenreQuery>();
        
            services.AddScoped<IFunctionCommand, FunctionCommand>();
            services.AddScoped<IMovieCommand, MovieCommand>();
            services.AddScoped<ITicketCommand, TicketCommand>();

            services.AddScoped<IFunctionService, MovieServices>();
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<ITicketService, TicketService>();
        }
    }
}
