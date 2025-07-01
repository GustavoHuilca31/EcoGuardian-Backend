using EcoGuardian_Backend.Resources.Domain.Model.Aggregates;
using EcoGuardian_Backend.Resources.Domain.Model.Queries;
using EcoGuardian_Backend.Resources.Domain.Repositories;
using EcoGuardian_Backend.Resources.Domain.Services;

namespace EcoGuardian_Backend.Resources.Application.Internal.QueryServices;

public class DeviceQueryService(IDeviceRepository deviceRepository, IHttpContextAccessor currentSession) : IDeviceQueryService
{
    public async Task<IEnumerable<Device>> Handle(GetDevicesByPlantIdQuery query)
    {
        return await deviceRepository.GetByPlantIdAsync(query.PlantId);
    }
}