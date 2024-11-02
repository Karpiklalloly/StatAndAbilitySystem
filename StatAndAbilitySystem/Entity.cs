using StatAndAbilitySystem.Base;
using StatAndAbilitySystem.Wrapper;
using StatAndAbilitySystem.Wrapper.Examples;

namespace StatAndAbilitySystem;

public class Entity
{
    private List<Stat> _stats = new();
    
    public float Time => _time;
    
    private List<Buff> _buffs = new();
    private float _time = 0;
    
    public List<IAbility> Abilities { get; } = new();

    public void Update()
    {
        _time++;

        var buffs = _buffs.Where(x => x.StartTime + x.Duration < _time).ToArray();
        foreach (var buff in buffs)
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

    public void AddStat<T>(T stat) where T : Stat
    {
        _stats.Add(stat);
    }
    
    public T GetStat<T>() where T : Stat
    {
        return (T)_stats.Find(x => x.GetType() == typeof(T));
    }

    public bool TryGetStat<T>(out T stat) where T : Stat
    {
        var index = _stats.FindIndex(x => x.GetType() == typeof(T));
        if (index == -1)
        {
            stat = null;
            return false;
        }
        stat = (T)_stats[index];
        return true;
    }
}