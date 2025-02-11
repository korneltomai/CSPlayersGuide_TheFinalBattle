using TheFinalBattle.Attacks;
using TheFinalBattle.Characters;

namespace TheFinalBattle.Items
{
    public class Potion : IItem
    {
        public string Name => "POTION";
        public ItemData ItemData => new ItemData(Targeting.SingleTarget, TargetTeam.OwnTeam);
        public void Use(Battle battle, Character target)
        {
            target.Health += 5;
            Console.WriteLine($"{target.Name} healed for 5 HP.");
            Console.WriteLine($"{target.Name} is now at {target.Health}/{target.MaxHealth} HP.");
        }
    }
}

