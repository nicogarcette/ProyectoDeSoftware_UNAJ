using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NgCinema.Domain.Entities;

namespace NgCinema.Persistence.Contexts.EntityConfigurations
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.ToTable("Salas");

            builder.HasKey(r => r.IdRoom);
            builder.Property(r => r.IdRoom).ValueGeneratedOnAdd();
            builder.Property(r => r.Name).HasMaxLength(50).IsRequired();
            builder.Property(r => r.Capacity).IsRequired();

            builder.HasData(
                new Room
                {
                    IdRoom = 1,
                    Capacity = 5,
                    Name = "Sala 1"
                },
                new Room
                {
                    IdRoom = 2,
                    Capacity = 15,
                    Name = "Sala 2"
                },
                new Room
                {
                    IdRoom = 3,
                    Capacity = 35,
                    Name = "Sala 3"
                });
        }
    }
}
