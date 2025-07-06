using EcoGuardian_Backend.Analytics.Domain.Model.Commands;

namespace EcoGuardian_Backend.Analytics.Domain.Services;

public interface IAggregationLevelCommandService
{
    Task Handle(SeedAggregationLevelsCommand command);
}

