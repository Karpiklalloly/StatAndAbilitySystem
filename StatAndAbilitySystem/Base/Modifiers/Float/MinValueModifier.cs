using StatAndAbilitySystem.Base;

namespace StatAndAbilitySystem.Modifiers;

public class MinValueModifier : FloatModifier
{
    public override int SubOrder => 100;
    private Func<IValue<float>> _min;

    public MinValueModifier(Func<IValue<float>> min) : base(1000)
    {
        _min = min;
    }
    
    public override void Modify(ref IValue<float> value)
    {
        var max = _min?.Invoke();
        if (max == null) return;
        value.BaseValue = Math.Max(value.BaseValue, max.BaseValue);
        value.ModifiedBaseValue = Math.Max(value.ModifiedBaseValue, max.ModifiedBaseValue);
        value.AdditionalValue = Math.Max(value.AdditionalValue, max.AdditionalValue);
    }
}