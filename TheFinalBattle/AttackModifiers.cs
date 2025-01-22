using TheFinalBattle.Attacks;

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
            Helpers.ColorWriteLine($"{Name} has reduced the damage by 1 point.", ConsoleColor.Yellow);
            return attackData with { Damage = attackData.Damage -  1 };
        }
    }

    public class ObjectSight : IAttackModifier
    {
        public string Name => "OBJECT SIGHT";

        public AttackData Apply(AttackData attackData)
        {
            Helpers.ColorWriteLine($"{Name} has reduced the damage by 1 point.", ConsoleColor.Yellow);
            if (attackData.DamageType == DamageType.Decoding)
                return attackData with { Damage = attackData.Damage - 2 };
            return attackData;
        }
    }
}
