using StatAndAbilitySystem.Base;

namespace StatAndAbilitySystem.Modifiers;

public class MaxValueModifier : FloatModifier
{
    public override int SubOrder => 100;
    
    private Func<IValue<float>> _max;

    public MaxValueModifier(Func<IValue<float>> max) : base(1000)
    {
        _max = max;
    }
    
    public override void Modify(ref IValue<float> value)
    {
        var max = _max?.Invoke();
        if (max == null) return;
        value.BaseValue = Math.Min(value.BaseValue, max.BaseValue);
        value.ModifiedBaseValue = Math.Min(value.ModifiedBaseValue, max.ModifiedBaseValue);
        value.AdditionalValue = Math.Min(value.AdditionalValue, max.AdditionalValue);
    }
}