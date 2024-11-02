using StatAndAbilitySystem.Modifiers;
using StatAndAbilitySystem.Wrapper.Examples;

namespace StatAndAbilitySystem.Wrapper;

public class ChangeMax<T> : Buff where T : Stat
{
    public ChangeMax(float value, float startTime, float duration)
        : base(new FloatAdderModifier(value, 0))
    {
        StartTime = startTime;
        Duration = duration;
    }

    public override void Apply(Entity entity)
    {
        if (!entity.TryGetStat(out T stat)) return;
        
        stat.EntityStat.MaxValue.ApplyModifier(Modifier);
        stat.EntityStat.Value.Recalculate();
    }

    public override void Remove(Entity entity)
    {
        if (!entity.TryGetStat(out T stat)) return;
        
        stat.EntityStat.MaxValue.RemoveModifier(Modifier);
        stat.EntityStat.Value.Recalculate();
    }
}