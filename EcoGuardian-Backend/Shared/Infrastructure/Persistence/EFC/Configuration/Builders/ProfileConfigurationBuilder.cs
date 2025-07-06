using EcoGuardian_Backend.ProfilePreferences.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcoGuardian_Backend.Shared.Infrastructure.Persistence.EFC.Configuration.Builders;

public class ProfileConfigurationBuilder : IEntityTypeConfiguration<Profile>
{
    public void Configure(EntityTypeBuilder<Profile> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id)
            .ValueGeneratedOnAdd();
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(p =>p.LastName)
            .IsRequired()
            .HasMaxLength(50);
        builder.Property(p => p.Address)
            .IsRequired()
            .HasMaxLength(200);
        builder.Property(p => p.AvatarUrl)
            .IsRequired();
        builder.Property(p => p.UserId)
            .IsRequired();
        builder.Property(p => p.SubscriptionId)
            .IsRequired();
    }
}