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
        builder.HasOne(x => x.MetricRegistry)
            .WithMany(r => r.Metrics)
            .HasForeignKey(x => x.MetricRegistryId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne<MetricType>()
            .WithMany()
            .HasForeignKey(x => x.MetricTypesId);
    }
}
