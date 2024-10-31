using StatAndAbilitySystem.Base;

namespace StatAndAbilitySystem.Modifiers;

public class FloatMultiplierModifier : FloatModifier
{
    public override int SubOrder => 0;
    
    private readonly float _changeBase;
    private readonly float _changeAdditional;

    public FloatMultiplierModifier(float changeBase, float changeAdditional, int priority = 0) : base(priority)
    {
        _changeBase = changeBase;
        _changeAdditional = changeAdditional;
    }
    
    public override void Modify(ref IValue<float> value)
    {
        value.ModifiedBaseValue += value.BaseValue * _changeBase;
        value.AdditionalValue = value.BaseValue * _changeAdditional;
    }
}