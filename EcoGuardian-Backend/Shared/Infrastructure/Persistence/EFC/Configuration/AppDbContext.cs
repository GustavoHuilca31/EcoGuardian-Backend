using EcoGuardian_Backend.Shared.Infrastructure.Persistence.EFC.Configuration.Builders;
using EcoGuardian_Backend.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using Microsoft.EntityFrameworkCore;

namespace EcoGuardian_Backend.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new WellnessStateConfigurationBuilder());
        modelBuilder.ApplyConfiguration(new SubscriptionStateConfigurationBuilder());
        modelBuilder.ApplyConfiguration(new SubscriptionTypeConfigurationBuilder());
        modelBuilder.ApplyConfiguration(new PlantConfigurationBuilder());
        modelBuilder.ApplyConfiguration(new QuestionConfigurationBuilder());
        modelBuilder.ApplyConfiguration(new AnswerConfigurationBuilder());
        modelBuilder.ApplyConfiguration(new QuestionImageConfigurationBuilder());
        modelBuilder.ApplyConfiguration(new SubscriptionConfigurationBuilder());
        modelBuilder.ApplyConfiguration(new PaymentConfigurationBuilder());
        modelBuilder.ApplyConfiguration(new UserConfigurationBuilder());
        modelBuilder.ApplyConfiguration(new UserRoleConfigurationBuilder());
        modelBuilder.ApplyConfiguration(new OrderConfigurationBuilder());
        modelBuilder.ApplyConfiguration(new OrderStateConfigurationBuilder());
        modelBuilder.ApplyConfiguration(new MetricConfigurationBuilder());
        modelBuilder.ApplyConfiguration(new MetricTypeConfigurationBuilder());
        modelBuilder.ApplyConfiguration(new ProfileConfigurationBuilder());
        modelBuilder.ApplyConfiguration(new DeviceConfigurationBuilder());
        modelBuilder.ApplyConfiguration(new NotificationConfigurationBuilder());
        modelBuilder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.AddInterceptors();
    }
}