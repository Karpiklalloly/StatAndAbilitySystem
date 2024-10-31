namespace StatAndAbilitySystem.Base;

public interface IValue<T>
{
    public T BaseValue { get; set; }
    public T ModifiedBaseValue { get; set; }
    public T AdditionalValue { get; set; }
    public T FinalValue { get; }
}