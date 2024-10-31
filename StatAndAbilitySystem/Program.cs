using StatAndAbilitySystem.Modifiers;
using StatAndAbilitySystem.Wrapper;

namespace StatAndAbilitySystem;

class Program
{
    static void Main(string[] args)
    {
        Entity entity = new();
        Console.WriteLine(entity);
        
        entity.Health.ApplyModifier(new FloatMultiplierModifier(3, 1, 0));
        
        Console.WriteLine(entity.Time);
        Console.WriteLine($"Health: {entity.Health.Value.ModifiedBaseValue} + {entity.Health.Value.AdditionalValue} / {entity.MaxHealth.Value.ModifiedBaseValue} + {entity.MaxHealth.Value.AdditionalValue}");
        Console.WriteLine();

        entity.ApplyBuff(new IncreaseMaxHealthBuff(100, entity.Time, 5));
        
        while (true)
        {
            entity.Update();
            Console.WriteLine(entity.Time);
            Console.WriteLine($"Health: {entity.Health.Value.ModifiedBaseValue} + {entity.Health.Value.AdditionalValue} / {entity.MaxHealth.Value.ModifiedBaseValue} + {entity.MaxHealth.Value.AdditionalValue}");
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