using StatAndAbilitySystem.Base;

namespace StatAndAbilitySystem;

public class Damage : FloatStat
{
    public Damage(float value) : base(value)
    {
    }

    public Damage(IValue<float> value) : base(value)
    {
    }
}