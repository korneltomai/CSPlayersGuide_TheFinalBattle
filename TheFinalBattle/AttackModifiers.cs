using TheFinalBattle.Attacks;
using static TheFinalBattle.Helpers;

namespace TheFinalBattle
{
    public interface IAttackModifier
    {
        public string Name { get; }
        public AttackData Apply(AttackData attackData);
    }

    public class StoneArmor : IAttackModifier
    {
        public string Name => "STONE ARMOR";

        public AttackData Apply(AttackData attackData)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{Name} has reduced the damage by 1 point.");
            Console.ForegroundColor = ConsoleColor.White;

            return attackData with { Damage = attackData.Damage -  1 };
        }
    }
}
