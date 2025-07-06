using EcoGuardian_Backend.OperationAndMonitoring.Domain.Model.Aggregates;
using EcoGuardian_Backend.OperationAndMonitoring.Domain.Model.Commands;

namespace EcoGuardian_Backend.OperationAndMonitoring.Domain.Services;

public interface IPlantCommandService
{
    Task<Plant> Handle(CreatePlantCommand command);
    Task Handle(UpdatePlantCommand command);
    Task Handle(DeletePlantCommand command);
    Task Handle(UpdatePlantStateCommand command);
}