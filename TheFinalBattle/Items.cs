using TheFinalBattle.Actions;
using TheFinalBattle.Characters;

namespace TheFinalBattle.Items
{
    public interface IItem
    {
        public string Name { get; }
        public ItemData ItemData { get; }
        public void Use(Character target);
    }

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

    public record ItemData(Targeting Targeting, TargetTeam TargetTeam);
}

