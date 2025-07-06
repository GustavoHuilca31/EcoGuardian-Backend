using EcoGuardian_Backend.Analytics.Domain.Model.ValueObjects;

namespace EcoGuardian_Backend.Analytics.Domain.Model.Entities;

public class AggregationLevel
{
    public int Id { get; private set; }
    public string Value { get; private set; }

    public AggregationLevel(string value)
    {
        Value = value;
    }
    
    public AggregationLevel(int id, string value)
    {
        Id = id;
        Value = value;
    }
    public AggregationLevel(AggregationLevels level)
    {
        Id = (int)level;
        Value = level.ToString().ToLower();
    }

    private AggregationLevel() { }
}
