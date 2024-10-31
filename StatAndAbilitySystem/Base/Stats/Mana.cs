using StatAndAbilitySystem.Base;

namespace StatAndAbilitySystem;

public class Mana : FloatStat
{
    public Mana(float value) : base(value)
    {
    }

    public Mana(IValue<float> value) : base(value)
    {
    }
}