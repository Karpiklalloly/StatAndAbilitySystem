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
        entity.MaxHealth.ApplyModifier(Modifier);
        entity.Health.Recalculate();
    }

    public override void Remove(Entity entity)
    {
        entity.MaxHealth.RemoveModifier(Modifier);
        entity.Health.Recalculate();
    }
}