using EcoGuardian_Backend.OperationAndMonitoring.Domain.Model.Aggregates;
using EcoGuardian_Backend.OperationAndMonitoring.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcoGuardian_Backend.Shared.Infrastructure.Persistence.EFC.Configuration.Builders;

public class PlantConfigurationBuilder : IEntityTypeConfiguration<Plant>
{
    public void Configure(EntityTypeBuilder<Plant> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();
        builder.Property(x => x.AreaCoverage)
            .IsRequired();
        builder.Property(x => x.LightThreshold)
            .IsRequired();
        builder.Property(x => x.WaterThreshold)
            .IsRequired();
        builder.Property(x => x.TemperatureThreshold)
            .IsRequired();
        builder.Property(x => x.IsPlantation)
            .IsRequired();
        builder.Property(x => x.Type)
            .IsRequired();
        builder.Property( x=> x.Name)
            .IsRequired();
        builder.Property(x => x.UserId)
            .IsRequired();
        builder.Property(x => x.Image)
            .IsRequired();
        builder.Property(x => x.CreatedAt);
        builder.Property(x => x.UpdatedAt);
        builder.HasOne<WellnessState>().WithMany().HasForeignKey(x => x.WellnessStateId);
        


    }
}