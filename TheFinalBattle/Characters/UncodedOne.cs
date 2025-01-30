using TheFinalBattle.Attacks;
using TheFinalBattle.Gears;

namespace TheFinalBattle.Characters
{
    public class UncodedOne : Character
    {
        private readonly Random _random = new Random();
        public override string Name { get => "UNCODED ONE"; }
        public override IAttack StandardAttack { get => new Unraveling(); }
        
        public UncodedOne() : base(15) { }
        public UncodedOne(IGear gear) : base(15, gear) { }
    }
}
