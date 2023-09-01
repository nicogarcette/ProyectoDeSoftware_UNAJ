using Microsoft.EntityFrameworkCore;
using NgCinema.Domain.Entities;
using NgCinema.Domain.Enums;
using NgCinema.Persistence.Contexts.EntityConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NgCinema.Persistence.Contexts
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

            //builder.Entity<Genre>(entity =>
            //{
            //    entity.ToTable("Genres");

            //    entity.HasKey(g => g.IdGenre);
            //    entity.Property(g => g.IdGenre).ValueGeneratedNever();
            //    entity.Property(g => g.Name).HasMaxLength(50).IsRequired();

            //    entity.HasData(
            //        new Genre
            //        {
            //            IdGenre = (int)Enums.Genre.Acción,
            //            Name = "Acción"
            //        },
            //        new Genre
            //        {
            //            IdGenre = (int)Enums.Genre.Aventuras,

            //            Name = "Aventuras"
            //        },
            //        new Genre
            //        {
            //            IdGenre = (int)Enums.Genre.CienciaFicción,
            //            Name = "Ciencia Ficción"
            //        },
            //        new Genre
            //        {
            //            IdGenre = (int)Enums.Genre.Comedia,

            //            Name = "Comedia"
            //        },
            //        new Genre
            //        {
            //            IdGenre = (int)Enums.Genre.Documental,

            //            Name = "Documental"
            //        },
            //        new Genre
            //        {
            //            IdGenre = (int)Enums.Genre.Drama,

            //            Name = "Drama"
            //        },
            //        new Genre
            //        {
            //            IdGenre = (int)Enums.Genre.Fantasía,

            //            Name = "Fantasía"
            //        },                    
            //        new Genre
            //        {
            //            IdGenre = (int)Enums.Genre.Musical,
            //            Name = "Musical"
            //        },new Genre
            //        {

            //            IdGenre = (int)Enums.Genre.Suspenso,
            //            Name = "Suspenso"
            //        },new Genre
            //        {

            //            IdGenre = (int)Enums.Genre.Terror,

            //            Name = "Terror"
            //        });
            //});

            //builder.Entity<Movie>(entity =>
            //{
            //    entity.ToTable("Movies");

            //    entity.HasKey(m => m.IdMovie);
            //    entity.Property(m => m.IdMovie).ValueGeneratedOnAdd();

            //    entity.Property(m => m.Title).HasMaxLength(50).IsRequired();
            //    entity.Property(m => m.Trailer).HasMaxLength(100).IsRequired();
            //    entity.Property(m => m.Poster).HasMaxLength(100).IsRequired();
            //    entity.Property(m => m.synopsis).HasMaxLength(255).IsRequired();

            //    entity.HasOne<Genre>(m => m.Genre)
            //    .WithMany(g => g.Movies)
            //    .HasForeignKey(m => m.IdGenre);

            //    entity.HasData(
            //        new Movie
            //        {
            //            IdMovie = 1,
            //            Title = "Piratas del Caribe 3",
            //            synopsis = "bla bla bla",
            //            Poster = "PosterPiratas3.png",
            //            Trailer = "TrailerPiratas3.mp4",
            //            IdGenre = (int)Enums.Genre.Acción
            //        },
            //         new Movie
            //         {
            //             IdMovie = 2,
            //             Title = "Harry Potter: El prisionero de azkaban",
            //             synopsis = "bla bla bla",
            //             Poster = "HarryPotter.png",
            //             Trailer = "TrailerHarryPotter.mp4",
            //             IdGenre = (int)Enums.Genre.Fantasía
            //         }
            //        );
            //});


            //builder.Entity<Room>(entity =>
            //{
            //    entity.ToTable("Rooms");

            //    entity.HasKey(r => r.IdRoom);
            //    entity.Property(r => r.IdRoom).ValueGeneratedOnAdd();
            //    entity.Property(r => r.Name).HasMaxLength(50).IsRequired();
            //    entity.Property(r => r.Capacity).IsRequired();

            //    entity.HasData(
            //        new Room
            //        {
            //            IdRoom = 1,
            //            Capacity = 5,
            //            Name = "Sala 1"
            //        },
            //        new Room
            //        {
            //            IdRoom = 2,
            //            Capacity = 15,
            //            Name = "Sala 2"
            //        },
            //        new Room
            //        {
            //            IdRoom = 3,
            //            Capacity = 35,
            //            Name = "Sala 3"
            //        });

            //});

            //builder.Entity<Function>(entity =>
            //{
            //    entity.ToTable("Functions");

            //    entity.HasKey(f => f.IdFuntion);
            //    entity.Property(f => f.IdFuntion).ValueGeneratedOnAdd();
            //    entity.Property(f => f.Date).IsRequired();
            //    entity.Property(f => f.Time).IsRequired();

            //    entity.HasOne<Movie>(f => f.Movie)
            //    .WithMany(m => m.Functions)
            //    .HasForeignKey(f => f.IdMovie);

            //    entity.HasOne<Room>(f => f.Room)
            //    .WithMany(r => r.Functions)
            //    .HasForeignKey(f => f.IdRoom);
            //});


            //builder.Entity<Ticket>(entity =>
            //{
            //    entity.ToTable("Tickets");

            //    entity.HasKey(t => t.IdTicket);
            //    entity.Property(t => t.IdTicket).ValueGeneratedOnAdd();
            //    entity.Property(t => t.User).HasMaxLength(50).IsRequired();

            //     entity.HasOne<Function>(t => t.Function)
            //    .WithMany(f => f.Tickets)
            //    .HasForeignKey(t => t.IdFunction);
            //});

        }
    }
}
