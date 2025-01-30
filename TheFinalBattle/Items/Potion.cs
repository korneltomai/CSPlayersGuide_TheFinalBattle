using TheFinalBattle.Attacks;
using TheFinalBattle.Characters;

namespace TheFinalBattle.Items
{
    public class Potion : IItem
    {
        public string Name => "POTION";
        public ItemData ItemData => new ItemData(Targeting.SingleTarget, TargetTeam.OwnTeam);
        public void Use(Character target)
        {
            target.Health += 10;
            Console.WriteLine($"{target.Name} healed for 10 HP.");
            Console.WriteLine($"{target.Name} is now at {target.Health}/{target.MaxHealth} HP.");
        }
    }
}

