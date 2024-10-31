using StatAndAbilitySystem.Base;
using StatAndAbilitySystem.Modifiers;
using StatAndAbilitySystem.Wrapper;

namespace StatAndAbilitySystem;

public class Entity
{
    public Health Health { get; } = new(100);
    public MaxHealth MaxHealth { get; } = new(100);
    public Mana Mana { get; } = new(new FloatValue(100));
    public Damage Damage { get; } = new(new FloatValue(10));
    public float Time => _time;
    
    private List<Buff> _buffs = new();
    private float _time = 0;

    public Entity()
    {
        Health.ApplyModifier(new MaxValueModifier(
            () => new FloatValue(float.MaxValue, MaxHealth.CurrentValue, float.MaxValue)));
    }
    
    public List<IAbility> Abilities { get; } = new();

    public void Update()
    {
        _time++;

        foreach (var buff in _buffs.Where(x => x.StartTime + x.Duration < _time).ToArray())
        {
            RemoveBuff(buff);
        }
    }

    public void ApplyBuff(Buff buff)
    {
        _buffs.Add(buff);
        buff.Apply(this);
    }

    public void RemoveBuff(Buff buff)
    {
        _buffs.Remove(buff);
        buff.Remove(this);
    }

    public override string ToString()
    {
        return $"{Health.Value.FinalValue} / {MaxHealth.Value.FinalValue}";
    }
}