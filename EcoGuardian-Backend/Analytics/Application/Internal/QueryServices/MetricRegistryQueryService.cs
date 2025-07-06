using EcoGuardian_Backend.Analytics.Domain.Model.Aggregates;
using EcoGuardian_Backend.Analytics.Domain.Model.Entities;
using EcoGuardian_Backend.Analytics.Domain.Model.Queries;
using EcoGuardian_Backend.Analytics.Domain.Model.ValueObjects;
using EcoGuardian_Backend.Analytics.Domain.Repositories;
using EcoGuardian_Backend.Analytics.Domain.Services;

namespace EcoGuardian_Backend.Analytics.Application.Internal.QueryServices;

public class MetricRegistryQueryService(IMetricRegistryRepository metricRegistryRepository, IAggregationLevelRepository aggregationLevelRepository) : IMetricRegistryQueryService
{
    public async Task<IEnumerable<MetricRegistry>> Handle(GetMetricsRegistriesByDeviceIdQuery query)
    {
        return await metricRegistryRepository.GetMetricRegistriesByDeviceIdAsync(query.DeviceId);
    }

    public async Task<MetricRegistry?> Handle(GetLatestMetricRegistryByDeviceIdQuery query)
    {
        return await metricRegistryRepository.GetLatestMetricRegistryByDeviceIdAsync(query.DeviceId);
    }

    public async Task<IEnumerable<MetricRegistry>> Handle(GetMetricRegistriesByPeriodQuery query)
    {
        var period = query.Period.ToLower();
        var aggregationLevel = await aggregationLevelRepository.GetByValueAsync(period);
        if (aggregationLevel == null)
            return new List<MetricRegistry>();
        int aggregationLevelId = aggregationLevel.Id;

        var existingAggregated = await metricRegistryRepository.GetMetricRegistriesByDeviceIdAsync(query.DeviceId);
        var filteredAggregated = existingAggregated
            .Where(r => r.AggregationLevelId == aggregationLevelId)
            .OrderBy(r => r.CreatedAt)
            .ToList();
        if (filteredAggregated.Any())
            return filteredAggregated;
        
        var rawRegistries = existingAggregated
            .Where(r => r.AggregationLevelId == (int)AggregationLevels.None)
            .OrderBy(r => r.CreatedAt)
            .ToList();

        if (!rawRegistries.Any()) return new List<MetricRegistry>();
        var aggregatedRegistries = period switch
        {
            "hourly" => AggregateHourly(rawRegistries, query.DeviceId, aggregationLevelId),
            "daily" => AggregateDaily(rawRegistries, query.DeviceId, aggregationLevelId),
            "weekly" => AggregateWeekly(rawRegistries, query.DeviceId, aggregationLevelId),
            "monthly" => AggregateMonthly(rawRegistries, query.DeviceId, aggregationLevelId),
            "yearly" => AggregateYearly(rawRegistries, query.DeviceId, aggregationLevelId), // Monthly is used for yearly as well
            _ => new List<MetricRegistry>()
        };

        foreach (var agg in aggregatedRegistries)
            await metricRegistryRepository.AddAsync(agg);
        return aggregatedRegistries.OrderBy(r => r.CreatedAt);
    }

    
    private List<MetricRegistry> AggregateHourly(List<MetricRegistry> registries, int deviceId, int aggregationLevelId)
    {
        var grouped = registries.GroupBy(r => new
        {
            Year = r.CreatedAt.Year,
            Month = r.CreatedAt.Month,
            Day = r.CreatedAt.Day,
            Hour = r.CreatedAt.Hour
        });

        var result = new List<MetricRegistry>();
        foreach (var group in grouped)
        {
            var avgMetrics = group.SelectMany(r => r.Metrics)
                .GroupBy(m => m.MetricTypesId)
                .Select(g => new Metric(
                    Math.Round(g.Average(m => m.MetricValue), 2),
                    g.Key,
                    0
                )).ToList();

            var timestamp = new DateTime(group.Key.Year, group.Key.Month, group.Key.Day, group.Key.Hour, 0, 0);
            var registry = new MetricRegistry(deviceId, timestamp, avgMetrics, aggregationLevelId);
            result.Add(registry);
        }

        return result;
    }
    
    private List<MetricRegistry> AggregateDaily(List<MetricRegistry> registries, int deviceId, int aggregationLevelId)
    {
        var grouped = registries.GroupBy(r => r.CreatedAt.Date);

        var result = new List<MetricRegistry>();
        foreach (var group in grouped)
        {
            var avgMetrics = group.SelectMany(r => r.Metrics)
                .GroupBy(m => m.MetricTypesId)
                .Select(g => new Metric(
                    Math.Round(g.Average(m => m.MetricValue), 2),
                    g.Key,
                    0
                )).ToList();

            var registry = new MetricRegistry(deviceId, group.Key, avgMetrics, aggregationLevelId);
            result.Add(registry);
        }

        return result;
    }
    
    private List<MetricRegistry> AggregateWeekly(List<MetricRegistry> registries, int deviceId, int aggregationLevelId)
    {
        var grouped = registries.GroupBy(r =>
        {
            var startOfWeek = r.CreatedAt.Date.AddDays(-(int)r.CreatedAt.DayOfWeek);
            return startOfWeek;
        });

        var result = new List<MetricRegistry>();
        foreach (var group in grouped)
        {
            var avgMetrics = group.SelectMany(r => r.Metrics)
                .GroupBy(m => m.MetricTypesId)
                .Select(g => new Metric(
                    Math.Round(g.Average(m => m.MetricValue), 2),
                    g.Key,
                    0
                )).ToList();

            var registry = new MetricRegistry(deviceId, group.Key, avgMetrics, aggregationLevelId);
            result.Add(registry);
        }

        return result;
    }
    
    private List<MetricRegistry> AggregateMonthly(List<MetricRegistry> registries, int deviceId, int aggregationLevelId)
    {
        var grouped = registries.GroupBy(r => new { r.CreatedAt.Year, r.CreatedAt.Month });

        var result = new List<MetricRegistry>();
        foreach (var group in grouped)
        {
            var avgMetrics = group.SelectMany(r => r.Metrics)
                .GroupBy(m => m.MetricTypesId)
                .Select(g => new Metric(
                    Math.Round(g.Average(m => m.MetricValue), 2),
                    g.Key,
                    0
                )).ToList();

            var firstDayOfMonth = new DateTime(group.Key.Year, group.Key.Month, 1);
            var registry = new MetricRegistry(deviceId, firstDayOfMonth, avgMetrics, aggregationLevelId);
            result.Add(registry);
        }

        return result;
    }
    
    private List<MetricRegistry> AggregateYearly(List<MetricRegistry> registries, int
    deviceId, int aggregationLevelId)
        {
            var grouped = registries.GroupBy(r => r.CreatedAt.Year);
    
            var result = new List<MetricRegistry>();
            foreach (var group in grouped)
            {
                var avgMetrics = group.SelectMany(r => r.Metrics)
                    .GroupBy(m => m.MetricTypesId)
                    .Select(g => new Metric(
                        Math.Round(g.Average(m => m.MetricValue), 2),
                        g.Key,
                        0
                    )).ToList();
    
                var firstDayOfYear = new DateTime(group.Key, 1, 1);
                var registry = new MetricRegistry(deviceId, firstDayOfYear, avgMetrics, aggregationLevelId);
                result.Add(registry);
            }
    
            return result;
        }



}
