using StatAndAbilitySystem.Modifiers;

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
        entity.Health.MaxValue.ApplyModifier(Modifier);
        entity.Health.Value.Recalculate();
    }

    public override void Remove(Entity entity)
    {
        entity.Health.MaxValue.RemoveModifier(Modifier);
        entity.Health.Value.Recalculate();
    }
}