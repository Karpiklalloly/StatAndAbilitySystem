using StatAndAbilitySystem.Base;

namespace StatAndAbilitySystem.Wrapper;

public abstract class Buff
{
    public IModifier<float> Modifier { get; }
    public float StartTime { get; protected set; }
    public float Duration { get; protected set; }

    public Buff(IModifier<float> modifier)
    {
        Modifier = modifier;
    }

    public abstract void Apply(Entity entity);
    public abstract void Remove(Entity entity);
}