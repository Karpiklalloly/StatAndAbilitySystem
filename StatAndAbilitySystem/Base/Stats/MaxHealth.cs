using StatAndAbilitySystem.Base;

namespace StatAndAbilitySystem;

public class MaxHealth : FloatStat
{
    public MaxHealth(float value) : base(value)
    {
    }

    public MaxHealth(IValue<float> value) : base(value)
    {
    }
}