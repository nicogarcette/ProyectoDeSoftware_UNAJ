using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NgCinema.Domain.Entities;

namespace NgCinema.Persistence.Contexts.EntityConfigurations
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.ToTable("Tickets");

            builder.HasKey(t => t.IdTicket);
            builder.Property(t => t.IdTicket).ValueGeneratedOnAdd();
            builder.Property(t => t.User).HasMaxLength(50).IsRequired();

            builder.HasOne<Function>(t => t.Function)
           .WithMany(f => f.Tickets)
           .HasForeignKey(t => t.IdFunction);
        }
    }
}
