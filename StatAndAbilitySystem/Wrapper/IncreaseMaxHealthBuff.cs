using StatAndAbilitySystem.Modifiers;
using StatAndAbilitySystem.Wrapper.Examples;

namespace StatAndAbilitySystem.Wrapper;

public class IncreaseMaxHealthBuff : Buff
{
    public IncreaseMaxHealthBuff(float value, float startTime, float duration)
        : base(new FloatAdderModifier(value, 0))
    {
        StartTime = startTime;
        Duration = duration;
    }

    public override void Apply(Entity entity)
    {
        if (!entity.TryGetStat(out Health health)) return;
        
        health.EntityStat.MaxValue.ApplyModifier(Modifier);
        health.EntityStat.Value.Recalculate();

    }

    public override void Remove(Entity entity)
    {
        if (!entity.TryGetStat(out Health health)) return;
        
        health.EntityStat.MaxValue.RemoveModifier(Modifier);
        health.EntityStat.Value.Recalculate();
    }
}