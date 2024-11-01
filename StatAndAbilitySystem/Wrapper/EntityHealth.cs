namespace StatAndAbilitySystem.Wrapper;

public class EntityHealth : EntityStat
{
    public EntityHealth(float value, float maxValue) : base(value, maxValue, 0)
    {
    }

    public EntityHealth(float value) : base(value, value, 0)
    {
        
    }
}