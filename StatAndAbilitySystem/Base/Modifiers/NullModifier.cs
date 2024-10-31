using StatAndAbilitySystem.Base;

namespace StatAndAbilitySystem.Modifiers;

public class NullModifier : IModifier<float>, IModifier<int>
{
    public int Order => int.MinValue;
    public int SubOrder => 5;
    public void Modify(ref IValue<int> value)
    {
        value.ModifiedBaseValue = value.BaseValue;
        value.AdditionalValue = 0;
    }

    public void Modify(ref IValue<float> value)
    {
        value.ModifiedBaseValue = value.BaseValue;
        value.AdditionalValue = 0;
    }
}