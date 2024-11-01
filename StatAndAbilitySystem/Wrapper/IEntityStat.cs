using StatAndAbilitySystem.Base;

namespace StatAndAbilitySystem.Wrapper;

public interface IEntityStat
{
    public FloatStat MinValue { get; }
    public FloatStat Value { get; }
    public FloatStat MaxValue { get; }
    
    public bool HasMinValue { get; }
    public bool HasMaxValue { get; }
}