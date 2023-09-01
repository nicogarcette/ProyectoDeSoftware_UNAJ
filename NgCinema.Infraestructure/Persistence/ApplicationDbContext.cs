using Microsoft.EntityFrameworkCore;
using NgCinema.Domain.Entities;
using NgCinema.Infraestructure.Persistence.EntityConfigurations;

namespace NgCinema.Infraestructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=NGPC-22\SQLEXPRESS;Database=DbNgCinema;Trusted_Connection=true;Encrypt=False;TrustServerCertificate=False");
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Function> Functions { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new GenreConfiguration());
            builder.ApplyConfiguration(new RoomConfiguration());
            builder.ApplyConfiguration(new MovieConfiguration());
            builder.ApplyConfiguration(new FunctionConfiguration());
            builder.ApplyConfiguration(new TicketConfiguration());
        }
    }
}
