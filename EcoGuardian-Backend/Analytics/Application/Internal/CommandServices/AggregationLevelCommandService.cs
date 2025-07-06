using EcoGuardian_Backend.Analytics.Domain.Model.Entities;
using EcoGuardian_Backend.Analytics.Domain.Model.Commands;
using EcoGuardian_Backend.Analytics.Domain.Repositories;
using EcoGuardian_Backend.Analytics.Domain.Services;
using EcoGuardian_Backend.Shared.Domain.Repositories;
using EcoGuardian_Backend.Analytics.Domain.Model.ValueObjects;

namespace EcoGuardian_Backend.Analytics.Application.Internal.CommandServices;

public class AggregationLevelCommandService : IAggregationLevelCommandService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAggregationLevelRepository _aggregationLevelRepository;

    public AggregationLevelCommandService(IUnitOfWork unitOfWork, IAggregationLevelRepository aggregationLevelRepository)
    {
        _unitOfWork = unitOfWork;
        _aggregationLevelRepository = aggregationLevelRepository;
    }

    public async Task Handle(SeedAggregationLevelsCommand command)
    {
        var levels = Enum.GetValues(typeof(AggregationLevels)).Cast<AggregationLevels>();
        foreach (var level in levels)
        {
            var value = level.ToString().ToLower();
            var exists = await _aggregationLevelRepository.IsAggregationLevelExistsAsync(value);
            if (exists) continue;
            var newLevel = new AggregationLevel(level);
            await _aggregationLevelRepository.AddAsync(newLevel);
            await _unitOfWork.CompleteAsync();
        }
    }
}
