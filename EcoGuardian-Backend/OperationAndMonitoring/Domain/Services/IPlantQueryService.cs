using EcoGuardian_Backend.OperationAndMonitoring.Domain.Model.Aggregates;
using EcoGuardian_Backend.OperationAndMonitoring.Domain.Model.Queries;

namespace EcoGuardian_Backend.OperationAndMonitoring.Domain.Services;

public interface IPlantQueryService
{
    Task<IEnumerable<Plant>> Handle(GetPlantsByUserIdQuery query);
    Task<Plant> Handle(GetPlantByIdQuery query);
}