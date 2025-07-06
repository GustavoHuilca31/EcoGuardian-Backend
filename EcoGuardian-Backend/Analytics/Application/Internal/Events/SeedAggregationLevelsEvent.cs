using EcoGuardian_Backend.Analytics.Domain.Model.Commands;
using EcoGuardian_Backend.Analytics.Domain.Services;

namespace EcoGuardian_Backend.Analytics.Application.Internal.Events;

public static class SeedAggregationLevelsEvent
{
    public static void On(this IServiceProvider provider, SeedAggregationLevelsCommand command)
    {
        Console.WriteLine("Seeding Aggregation Levels...");
        using var scope = provider.CreateScope();
        var aggregationLevelCommandService = scope.ServiceProvider.GetRequiredService<IAggregationLevelCommandService>();
        aggregationLevelCommandService.Handle(command).GetAwaiter().GetResult();
        Console.WriteLine("Aggregation Levels Seeded Successfully");
    }
}

