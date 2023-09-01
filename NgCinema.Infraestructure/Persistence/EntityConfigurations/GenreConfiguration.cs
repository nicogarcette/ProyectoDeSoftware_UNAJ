using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NgCinema.Domain.Entities;
using NgCinema.Domain.Enums;

namespace NgCinema.Infraestructure.Persistence.EntityConfigurations
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("Generos");

            builder.HasKey(g => g.IdGenre);
            builder.Property(g => g.IdGenre).ValueGeneratedNever();
            builder.Property(g => g.Name).HasMaxLength(50).IsRequired();

            builder.HasData(
                new Genre
                {
                    IdGenre = (int)Enums.Genre.Accion,
                    Name = "Acción"
                },
                new Genre
                {
                    IdGenre = (int)Enums.Genre.Aventuras,
                    Name = "Aventuras"
                },
                new Genre
                {
                    IdGenre = (int)Enums.Genre.CienciaFiccion,
                    Name = "Ciencia Ficción"
                },
                new Genre
                {
                    IdGenre = (int)Enums.Genre.Comedia,
                    Name = "Comedia"
                },
                new Genre
                {
                    IdGenre = (int)Enums.Genre.Documental,
                    Name = "Documental"
                },
                new Genre
                {
                    IdGenre = (int)Enums.Genre.Drama,
                    Name = "Drama"
                },
                new Genre
                {
                    IdGenre = (int)Enums.Genre.Fantasia,
                    Name = "Fantasía"
                },
                new Genre
                {
                    IdGenre = (int)Enums.Genre.Musical,
                    Name = "Musical"
                }, new Genre
                {
                    IdGenre = (int)Enums.Genre.Suspenso,
                    Name = "Suspenso"
                }, 
                new Genre
                {
                    IdGenre = (int)Enums.Genre.Terror,
                    Name = "Terror"
                });
        }
    }
}
