using StatAndAbilitySystem.Base;

namespace StatAndAbilitySystem;

public class Health : FloatStat
{
    public Health(float value) : base(value)
    {
    }

    public Health(IValue<float> value) : base(value)
    {
    }
}