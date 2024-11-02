using StatAndAbilitySystem.Modifiers;
using StatAndAbilitySystem.Wrapper;
using StatAndAbilitySystem.Wrapper.Examples;

namespace StatAndAbilitySystem;

class Program
{
    static void Main(string[] args)
    {
        Entity entity = new();
        entity.AddStat(new Health(100, 100));
        entity.AddStat(new Mana(100, 100));
        entity.AddStat(new Damage(10));
        
        
        Console.WriteLine(entity);
        
        var health = entity.GetStat<Health>().EntityStat;
        health.Value.ApplyModifier(new FloatMultiplierModifier(3, 1, 0));
        
        Console.WriteLine(entity.Time);
        Console.Write("Health: ");
        Console.WriteLine(health.ToString());
        Console.WriteLine();

        entity.ApplyBuff(new IncreaseMaxHealthBuff(100, entity.Time, 5));
        
        while (true)
        {
            entity.Update();
            Console.WriteLine(entity.Time);
            Console.Write("Health: ");
            Console.WriteLine(health.ToString());
            Console.WriteLine();
            var key = Console.ReadKey();

            if (key.Key == ConsoleKey.Spacebar)
            {
                break;
            }
        }
        
        Console.WriteLine("Hello, World!");
    }
}