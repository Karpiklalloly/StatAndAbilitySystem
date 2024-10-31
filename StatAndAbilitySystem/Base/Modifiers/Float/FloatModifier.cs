using StatAndAbilitySystem.Base;

namespace StatAndAbilitySystem.Modifiers;

public abstract class FloatModifier : IModifier<float>
{
    public int Order { get; }
    public abstract int SubOrder { get; }
    
    public FloatModifier(int priority = 0)
    {
        Order = priority;
    }
    
    public abstract void Modify(ref IValue<float> value);
}