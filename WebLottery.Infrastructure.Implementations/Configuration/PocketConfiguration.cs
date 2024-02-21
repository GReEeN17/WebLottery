using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebLottery.Infrastructure.Entities.Pocket;
using WebLottery.Infrastructure.Entities.PocketTicket;
using WebLottery.Infrastructure.Entities.User;

namespace WebLottery.Infrastructure.Implementations.Configuration;

public class PocketConfiguration : IEntityTypeConfiguration<PocketEntity>
{
    public void Configure(EntityTypeBuilder<PocketEntity> builder)
    {
        builder
            .ToTable("pocket")
            .HasKey(pocket => pocket.Id);

        builder
            .Property(pocket => pocket.UserId)
            .IsRequired()
            .HasColumnName("user_id");

        builder
            .HasOne<UserEntity>(pocket => pocket.User)
            .WithOne(user => user.Pocket);

        builder
            .HasMany<PocketTicketEntity>(pocket => pocket.PocketTickets)
            .WithOne(pocketTicket => pocketTicket.Pocket)
            .HasForeignKey(pocketTicket => pocketTicket.PocketId);

        builder.Ignore(pocket => pocket.User);
    }
}