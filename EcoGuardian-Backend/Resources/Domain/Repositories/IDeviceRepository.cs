using System.Threading.Tasks;
using EcoGuardian_Backend.Resources.Domain.Model.Aggregates;
using EcoGuardian_Backend.Shared.Domain.Repositories;

namespace EcoGuardian_Backend.Resources.Domain.Repositories;

public interface IDeviceRepository : IBaseRepository<Device>
{
    Task<IEnumerable<Device>> GetByPlantIdAsync(int plantId);
}
