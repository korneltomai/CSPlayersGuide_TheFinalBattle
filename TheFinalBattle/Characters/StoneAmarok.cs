using TheFinalBattle.AttackModifiers;
using TheFinalBattle.Attacks;
using TheFinalBattle.Gears;

namespace TheFinalBattle.Characters
{
    public class StoneAmarok : Character
    {
        public override string Name { get => "STONE AMAROK"; }
        public override IAttack StandardAttack { get => new Bite(); }

        public StoneAmarok() : base(5) { DefensiveModifiers.Add(new StoneArmor()); }
        public StoneAmarok(IGear gear) : base(5, gear) { DefensiveModifiers.Add(new StoneArmor()); }
    }
}
