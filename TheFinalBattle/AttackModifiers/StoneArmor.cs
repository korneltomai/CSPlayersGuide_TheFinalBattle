using TheFinalBattle.Attacks;
using TheFinalBattle.Helpers;

namespace TheFinalBattle.AttackModifiers
{
    public class StoneArmor : IAttackModifier
    {
        public string Name => "STONE ARMOR";

        public AttackData Apply(AttackData attackData)
        {
            ConsoleHelper.ColorWriteLine($"{Name} has reduced the damage by 1 point.", ConsoleColor.Yellow);
            return attackData with { Damage = attackData.Damage - 1 };
        }
    }
}
