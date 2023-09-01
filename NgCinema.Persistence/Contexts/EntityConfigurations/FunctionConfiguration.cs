using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NgCinema.Domain.Entities;

namespace NgCinema.Persistence.Contexts.EntityConfigurations
{
    public class FunctionConfiguration : IEntityTypeConfiguration<Function>
    {
        public void Configure(EntityTypeBuilder<Function> builder)
        {
            builder.ToTable("Funciones");

            builder.HasKey(f => f.IdFuntion);
            builder.Property(f => f.IdFuntion).ValueGeneratedOnAdd();
            builder.Property(f => f.Date).IsRequired();
            builder.Property(f => f.Time).IsRequired();

            builder.HasOne<Movie>(f => f.Movie)
            .WithMany(m => m.Functions)
            .HasForeignKey(f => f.IdMovie);

            builder.HasOne<Room>(f => f.Room)
            .WithMany(r => r.Functions)
            .HasForeignKey(f => f.IdRoom);
        }
    }
}
