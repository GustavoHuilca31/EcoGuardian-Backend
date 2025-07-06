using EcoGuardian_Backend.Analytics.Domain.Model.Commands;

namespace EcoGuardian_Backend.Analytics.Domain.Services;

public interface IMetricRegistryCommandService
{
    Task Handle(CreateMetricRegistryCommand command);
}