using StatAndAbilitySystem.Base;
using StatAndAbilitySystem.Modifiers;

namespace StatAndAbilitySystem;

public class FloatStat : IStat<float>
{
    public event Action<IStat<float>> Changed; 
    public float CurrentValue => Value.FinalValue;

    public IValue<float> Value
    {
        get
        {
            if (!_needsUpdate) return _value;
            
            
            _needsUpdate = false;
            return _value;
        }
    }
    
    public IReadOnlyCollection<IModifier<float>> Modifiers => _modifiers;
    
    private IValue<float> _value;
    
    private List<IModifier<float>> _modifiers = new();
    private bool _needsUpdate = true;

    public FloatStat(float value) : this(new FloatValue(value))
    {
        
    }
    
    public FloatStat(IValue<float> value)
    {
        _value = value;
        _modifiers.Add(new NullModifier());
    }

    public void ApplyModifier(params IModifier<float>[] modifiers)
    {
        foreach (var modifier in modifiers)
        {
            _modifiers.Add(modifier);
        }
        Recalculate();
        _needsUpdate = true;
    }

    public void RemoveModifier(IModifier<float> modifier)
    {
        _modifiers.Remove(modifier);
        Recalculate();
        _needsUpdate = true;
    }

    public override string ToString()
    {
        return $"BaseValue: {Value.BaseValue}\n" + 
               $"ModifiedBaseValue: {Value.ModifiedBaseValue}\n" +
               $"AdditionalValue: {Value.AdditionalValue}\n" +
               $"CurrentValue: {CurrentValue}\n";
    }

    public void Recalculate()
    {
        _modifiers.Sort(Sort);
        for (int i = 0; i < _modifiers.Count; i++)
        {
            _modifiers[i].Modify(ref _value);
        }

        _needsUpdate = false;
        Changed?.Invoke(this);
    }
    
    private static int Sort(IModifier<float> a, IModifier<float> b)
    {
        if (a.Order > b.Order) return 1;
        if (a.Order < b.Order) return -1;
        if (a.SubOrder > b.SubOrder) return 1;
        if (a.SubOrder < b.SubOrder) return -1;
        return 0;
    }
}