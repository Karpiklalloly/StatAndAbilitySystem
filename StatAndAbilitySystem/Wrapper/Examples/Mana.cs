namespace StatAndAbilitySystem.Wrapper.Examples;

public class Mana : Stat
{
    public Mana(float value, float maxValue)
    {
        EntityStat = new EntityStat(value, maxValue, 0);
    }
}