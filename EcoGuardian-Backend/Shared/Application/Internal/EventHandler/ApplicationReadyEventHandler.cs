using EcoGuardian_Backend.IAM.Application.Internal.Events;
using EcoGuardian_Backend.IAM.Domain.Model.Commands;
using EcoGuardian_Backend.OperationAndMonitoring.Application.Internal.Events;
using EcoGuardian_Backend.SubscriptionsAndPayment.Application.Internal.Events;
using EcoGuardian_Backend.Planning.Application.Internal.Events;
using EcoGuardian_Backend.OperationAndMonitoring.Domain.Model.Commands;
using EcoGuardian_Backend.Planning.Domain.Model.Commands;
using EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Model.Commands;
using EcoGuardian_Backend.Analytics.Application.Internal.Events;
using EcoGuardian_Backend.Analytics.Domain.Model.Commands;


namespace EcoGuardian_Backend.Shared.Application.Internal.EventHandler;

public static class ApplicationReadyEventHandler
{
    public static void OnStart(this IServiceProvider provider)
    {
        Console.WriteLine("Application Ready Event Triggered");
        var seedRolesCommand = new SeedUserRolesCommand();
        var seedWellnessCommand = new SeedWellnessStatesCommand();
        var seedSubscriptionTypesCommand = new SeedSubscriptionTypesCommand();
        var seedSubscriptionStatesCommand = new SeedSubscriptionStatesCommand();
        var seedOrderStatesCommand = new SeedOrderStatesCommand();
        var seedMetricTypesCommand = new SeedMetricTypesCommand();
        var seedAggregationLevelsCommand = new SeedAggregationLevelsCommand();
        provider.On(seedWellnessCommand);
        provider.On(seedRolesCommand);
        provider.On(seedSubscriptionStatesCommand);
        provider.On(seedSubscriptionTypesCommand);
        provider.On(seedOrderStatesCommand);
        provider.On(seedMetricTypesCommand);
        provider.On(seedAggregationLevelsCommand);
        Console.WriteLine("Application Ready Event Completed");
        
    }
}