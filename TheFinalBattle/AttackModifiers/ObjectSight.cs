using TheFinalBattle.Attacks;
using TheFinalBattle.Helpers;

namespace TheFinalBattle.AttackModifiers
{
    public class ObjectSight : IAttackModifier
    {
        public string Name => "OBJECT SIGHT";

        public AttackData Apply(AttackData attackData)
        {
            ConsoleHelper.ColorWriteLine($"{Name} has reduced the damage by 1 point.", ConsoleColor.Yellow);
            if (attackData.DamageType == DamageType.Decoding)
                return attackData with { Damage = attackData.Damage - 2 };
            return attackData;
        }
    }
}
