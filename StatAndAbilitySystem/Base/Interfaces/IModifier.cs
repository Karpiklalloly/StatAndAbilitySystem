namespace StatAndAbilitySystem.Base;

public interface IModifier<T>
{
    public int Order { get; }
    public int SubOrder { get; }
    public void Modify(ref IValue<T> value);
}