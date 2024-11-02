namespace StatAndAbilitySystem.Wrapper.Examples;

public class Damage : Stat
{
    public Damage(float value)
    {
        EntityStat = new EntityStat(value);
    }
}