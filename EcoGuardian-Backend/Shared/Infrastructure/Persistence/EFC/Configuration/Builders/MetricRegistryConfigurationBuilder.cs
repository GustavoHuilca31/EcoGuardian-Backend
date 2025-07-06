using EcoGuardian_Backend.Analytics.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcoGuardian_Backend.Shared.Infrastructure.Persistence.EFC.Configuration.Builders;

public class MetricRegistryConfigurationBuilder : IEntityTypeConfiguration<MetricRegistry>
{
    public void Configure(EntityTypeBuilder<MetricRegistry> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.DeviceId).IsRequired();
        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.AggregationLevelId).IsRequired();
        
        builder.HasMany(x => x.Metrics)
            .WithOne(m => m.MetricRegistry)
            .HasForeignKey(m => m.MetricRegistryId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.AggregationLevel)
            .WithMany()
            .HasForeignKey(x => x.AggregationLevelId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
