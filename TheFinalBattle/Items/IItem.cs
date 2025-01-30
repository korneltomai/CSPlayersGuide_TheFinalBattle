using TheFinalBattle.Attacks;
using TheFinalBattle.Characters;

namespace TheFinalBattle.Items
{
    public interface IItem
    {
        public string Name { get; }
        public ItemData ItemData { get; }
        public void Use(Character target);
    }

    public record ItemData(Targeting Targeting, TargetTeam TargetTeam);
}

