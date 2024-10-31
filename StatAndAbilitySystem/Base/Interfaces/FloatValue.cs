namespace StatAndAbilitySystem.Base;

public class FloatValue : IValue<float>
{
    public float FinalValue => ModifiedBaseValue + AdditionalValue;
    public float BaseValue { get; set; }
    public float ModifiedBaseValue { get; set; }
    public float AdditionalValue { get; set; }
    
    public FloatValue(float value) : this(value, value, 0)
    {
        
    }
    
    public FloatValue(float value, float additionalValue) : this(value, value, additionalValue)
    {
        
    }

    public FloatValue(float value, float modifiedValue, float additionalValue)
    {
        BaseValue = value;
        ModifiedBaseValue = modifiedValue;
        AdditionalValue = additionalValue;
    }
    
    public static FloatValue operator +(FloatValue a, FloatValue b)
    {
        return new FloatValue(a.BaseValue + b.BaseValue, a.AdditionalValue + b.AdditionalValue);
    }

    public static FloatValue operator +(FloatValue a, float b)
    {
        return new FloatValue(a.BaseValue, a.AdditionalValue + b);
    }

    public static FloatValue operator *(FloatValue a, FloatValue b)
    {
        return new FloatValue(a.BaseValue * b.BaseValue, a.AdditionalValue * b.AdditionalValue);
    }

    public static FloatValue operator *(FloatValue a, float b)
    {
        return new FloatValue(a.BaseValue, a.AdditionalValue * b);
    }

    public static FloatValue operator -(FloatValue a, FloatValue b)
    {
        return new FloatValue(a.BaseValue - b.BaseValue, a.AdditionalValue - b.AdditionalValue);
    }
    
    public static FloatValue operator -(FloatValue a, float b)
    {
        return new FloatValue(a.BaseValue, a.AdditionalValue - b);
    }

    public static FloatValue operator /(FloatValue a, FloatValue b)
    {
        return new FloatValue(a.BaseValue / b.BaseValue, a.AdditionalValue / b.AdditionalValue);
    }

    public static FloatValue operator /(FloatValue a, float b)
    {
        return new FloatValue(a.BaseValue, a.AdditionalValue / b);
    }
    
    public static explicit operator FloatValue(float value)
    {
        return new FloatValue(value);
    }
    
    public static explicit operator FloatValue(Tuple<float, float> tuple)
    {
        return new FloatValue(tuple.Item1, tuple.Item2);
    }
}