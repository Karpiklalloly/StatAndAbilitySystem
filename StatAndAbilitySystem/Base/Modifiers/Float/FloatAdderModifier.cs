using StatAndAbilitySystem.Base;

namespace StatAndAbilitySystem.Modifiers;

public class FloatAdderModifier : FloatModifier
{
    public override int SubOrder => 5;
    
    private readonly float _changeBase;
    private readonly float _changeAdditional;

    public FloatAdderModifier(float changeBase, float changeAdditional, int priority = 0) : base(priority)
    {
        _changeBase = changeBase;
        _changeAdditional = changeAdditional;
    }

    public override void Modify(ref IValue<float> value)
    {
        value.ModifiedBaseValue += _changeBase;
        value.AdditionalValue += _changeAdditional;
    }
}