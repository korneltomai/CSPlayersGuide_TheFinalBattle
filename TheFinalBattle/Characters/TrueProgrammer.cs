using TheFinalBattle.AttackModifiers;
using TheFinalBattle.Attacks;
using TheFinalBattle.Gears;

namespace TheFinalBattle.Characters
{
    public class TrueProgrammer : Character
    {
        public override string Name { get; }
        public override IAttack StandardAttack { get => new Punch(); }

        public TrueProgrammer(string name) : base(25) { Name = name; DefensiveModifiers.Add(new ObjectSight()); }
        public TrueProgrammer(string name, IGear gear) : base(25, gear) { Name = name; DefensiveModifiers.Add(new ObjectSight()); }
    }
}
