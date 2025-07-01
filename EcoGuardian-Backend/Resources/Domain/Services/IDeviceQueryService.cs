using EcoGuardian_Backend.Resources.Domain.Model.Aggregates;
using EcoGuardian_Backend.Resources.Domain.Model.Queries;

namespace EcoGuardian_Backend.Resources.Domain.Services;

public interface IDeviceQueryService
{
    Task<IEnumerable<Device>> Handle(GetDevicesByPlantIdQuery query);
}