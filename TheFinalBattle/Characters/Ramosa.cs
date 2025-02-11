using TheFinalBattle.Attacks;
using TheFinalBattle.Gears;

namespace TheFinalBattle.Characters
{
    public class Ramosa : Character
    {
        public override string Name => "RAMOSA";
        public override IAttack StandardAttack { get => new Heal(); }

        public Ramosa() : base(10) { }
        public Ramosa(IGear gear) : base(10, gear) { }
    }
}
