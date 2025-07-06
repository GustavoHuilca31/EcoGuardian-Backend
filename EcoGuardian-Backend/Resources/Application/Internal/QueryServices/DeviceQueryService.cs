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

    public async Task<int> Handle(GetPlantIdByIdQuery query)
    {
        var device = await deviceRepository.GetByIdAsync(query.Id);
        if (device == null)
        {
            throw new KeyNotFoundException($"Device with ID {query.Id} not found.");
        }
        return device.PlantId;
    }
}