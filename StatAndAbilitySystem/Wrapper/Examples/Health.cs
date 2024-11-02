namespace StatAndAbilitySystem.Wrapper.Examples;

public class Health : Stat
{
    public Health(float value, float maxValue)
    {
        EntityStat = new EntityStat(value, maxValue, 0);
    }
}