namespace StatAndAbilitySystem.Base;

public interface IStat<T>
{
    public event Action<IStat<T>> Changed; 
    public T CurrentValue { get; }
    public IValue<T> Value { get; }
    public IReadOnlyCollection<IModifier<T>> Modifiers { get; }
    
    public void ApplyModifier(params IModifier<T>[] modifiers);
    public void RemoveModifier(IModifier<T> modifier);
    public void Recalculate();
}