using StatAndAbilitySystem.Base;
using StatAndAbilitySystem.Modifiers;

namespace StatAndAbilitySystem.Wrapper;

public struct EntityStat : IEntityStat
{
    public FloatStat MinValue { get; }
    public FloatStat Value { get; }
    public FloatStat MaxValue { get; }

    public bool HasMinValue { get; }
    public bool HasMaxValue { get; }

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

    public override string ToString()
    {
        return $"{MinValue.Value.ModifiedBaseValue} + {MinValue.Value.AdditionalValue} / " +
               $"{Value.Value.ModifiedBaseValue} + {Value.Value.AdditionalValue} / " +
               $"{MaxValue.Value.ModifiedBaseValue} + {MaxValue.Value.AdditionalValue}";
    }

    private void BindMax()
    {
        Value.ApplyModifier(new MaxValueModifier(Max));
    }

    private void BindMin()
    {
        Value.ApplyModifier(new MinValueModifier(Min));
    }

    private FloatValue Max() => new(float.MaxValue, MaxValue.CurrentValue, float.MaxValue);

    private FloatValue Min() => new(0, MinValue.CurrentValue, float.MinValue);
}