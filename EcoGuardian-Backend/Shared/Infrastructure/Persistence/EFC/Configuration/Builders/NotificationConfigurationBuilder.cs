using EcoGuardian_Backend.IAM.Domain.Model.Aggregates;
using EcoGuardian_Backend.ProfilePreferences.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcoGuardian_Backend.Shared.Infrastructure.Persistence.EFC.Configuration.Builders;

public class NotificationConfigurationBuilder : IEntityTypeConfiguration<Notification>
{
    public void Configure(EntityTypeBuilder<Notification> builder)
    {

        builder.HasKey(n => n.Id);

        builder.Property(n => n.Id)
            .ValueGeneratedOnAdd();

        builder.Property(n => n.Title)
            .IsRequired();

        builder.Property(n => n.Subject)
            .IsRequired();

        builder.HasOne<Profile>().WithMany().HasForeignKey(x => x.ProfileId);
    }
}