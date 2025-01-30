using TheFinalBattle.Attacks;
using TheFinalBattle.Gears;

namespace TheFinalBattle.Characters
{
    public class VinFletcher : Character
    {
        public override string Name => "VIN FLETCHER";
        public override IAttack StandardAttack { get => new Punch(); }

        public VinFletcher() : base(15) { }
        public VinFletcher(IGear gear) : base(15, gear) { }
    }
}
