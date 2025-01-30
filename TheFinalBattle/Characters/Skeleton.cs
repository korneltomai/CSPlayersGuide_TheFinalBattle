using TheFinalBattle.Attacks;
using TheFinalBattle.Gears;

namespace TheFinalBattle.Characters
{
    public class Skeleton : Character
    {
        private readonly Random _random = new Random();
        public override string Name { get => "SKELETON"; }
        public override IAttack StandardAttack { get => new BoneCrunch(); }
        
        public Skeleton() : base(5) { }
        public Skeleton(IGear gear) : base(5, gear) { }
    }
}
