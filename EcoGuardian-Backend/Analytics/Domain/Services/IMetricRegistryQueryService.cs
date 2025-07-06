using EcoGuardian_Backend.Analytics.Domain.Model.Aggregates;
using EcoGuardian_Backend.Analytics.Domain.Model.Queries;

namespace EcoGuardian_Backend.Analytics.Domain.Services;

public interface IMetricRegistryQueryService
{
    Task<IEnumerable<MetricRegistry>> Handle(GetMetricsRegistriesByDeviceIdQuery query);
    Task<MetricRegistry?> Handle(GetLatestMetricRegistryByDeviceIdQuery query);
    Task<IEnumerable<MetricRegistry>> Handle(GetMetricRegistriesByPeriodQuery query);
}
