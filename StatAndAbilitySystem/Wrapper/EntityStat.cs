using StatAndAbilitySystem.Base;
using StatAndAbilitySystem.Modifiers;

namespace StatAndAbilitySystem.Wrapper;

public abstract class EntityStat : IEntityStat
{
    public IStat<float> MinValue { get; }
    public IStat<float> Value { get; }
    public IStat<float> MaxValue { get; }

    public virtual bool HasMinValue { get; }
    public virtual bool HasMaxValue { get; }

    public EntityStat(float value)
    {
        Value = new FloatStat(value);
    }

    public EntityStat(float value, float maxValue)
    {
        Value = new FloatStat(value);
        MaxValue = new FloatStat(maxValue);
        
        HasMaxValue = true;
        
        BindMax();
    }
    
    public EntityStat(float value, float maxValue, float minValue)
    {
        Value = new FloatStat(value);
        MaxValue = new FloatStat(maxValue);
        MinValue = new FloatStat(minValue);
        
        HasMaxValue = true;
        HasMinValue = true;
        
        BindMax();
        BindMin();
    }

    protected void BindMax()
    {
        Value.ApplyModifier(new MaxValueModifier(
            () => new FloatValue(float.MaxValue, MaxValue.CurrentValue, float.MaxValue)));
    }

    protected void BindMin()
    {
        Value.ApplyModifier(new MinValueModifier(
            () => new FloatValue(0, MinValue.CurrentValue, 0)));
    }
}