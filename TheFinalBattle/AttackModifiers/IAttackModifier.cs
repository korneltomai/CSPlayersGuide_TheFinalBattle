using TheFinalBattle.Attacks;

namespace TheFinalBattle.AttackModifiers
{
    public interface IAttackModifier
    {
        public string Name { get; }
        public AttackData Apply(AttackData attackData);
    }
}
