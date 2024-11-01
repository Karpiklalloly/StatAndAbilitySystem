using StatAndAbilitySystem.Base;

namespace StatAndAbilitySystem.Wrapper;

public interface IEntityStat
{
    public IStat<float> MinValue { get; }
    public IStat<float> Value { get; }
    public IStat<float> MaxValue { get; }
    
    public bool HasMinValue { get; }
    public bool HasMaxValue { get; }
}