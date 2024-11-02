using StatAndAbilitySystem.Modifiers;
using StatAndAbilitySystem.Wrapper.Examples;

namespace StatAndAbilitySystem.Wrapper;

public class ChangeMin<T> : Buff where T : Stat
{
    public ChangeMin(float value, float startTime, float duration)
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