using EcoGuardian_Backend.Analytics.Domain.Model.Aggregates;
using EcoGuardian_Backend.Analytics.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcoGuardian_Backend.Shared.Infrastructure.Persistence.EFC.Configuration.Builders;

public class MetricConfigurationBuilder : IEntityTypeConfiguration<Metric>
{
    public void Configure(EntityTypeBuilder<Metric> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.MetricValue).IsRequired();
        builder.HasOne<MetricType>()
            .WithMany()
            .HasForeignKey(x => x.MetricTypesId);
        builder.Property(x => x.DeviceId).IsRequired();
        builder.Property(x => x.CreatedAt).IsRequired();
    }
}
