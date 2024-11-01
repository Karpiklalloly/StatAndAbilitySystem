using StatAndAbilitySystem.Base;
using StatAndAbilitySystem.Modifiers;
using StatAndAbilitySystem.Wrapper;

namespace StatAndAbilitySystem;

public class Entity
{
    public EntityStat Health { get; } = new(100, 100, 0);
    public EntityStat Mana { get; } = new(100, 100, 0);
    public EntityStat Damage { get; } = new(10);
    public float Time => _time;
    
    private List<Buff> _buffs = new();
    private float _time = 0;
    
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
        return $"{Health.Value.Value.FinalValue} / {Health.MaxValue.Value.FinalValue}";
    }
}