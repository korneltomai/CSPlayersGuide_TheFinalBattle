using TheFinalBattle.Actions;
using TheFinalBattle.Attacks;

namespace TheFinalBattle.Characters
{
    public abstract class Character
    {
        public abstract string Name { get; }
        public abstract IAttack Attack { get; }
        public int MaxHealth { get; }

        private int _health;
        public int Health { get => _health; set => _health = Math.Clamp(value, 0, MaxHealth); }

        public Character(int health)
        {
            MaxHealth = health;
            Health = health;
        }
    }

    public class TrueProgrammer : Character
    {
        public override string Name { get; }
        public override IAttack Attack { get => new Punch(); }

        public TrueProgrammer(string name) : base(25) { Name = name; }
    }

    public class Skeleton : Character
    {
        private readonly Random _random = new Random();
        public override string Name { get => "SKELETON"; }
        public override IAttack Attack { get => new BoneCrunch(); }
        
        public Skeleton() : base(5) { }
    }

    public class UncodedOne : Character
    {
        private readonly Random _random = new Random();
        public override string Name { get => "UNCODED ONE"; }
        public override IAttack Attack { get => new Unraveling(); }
        
        public UncodedOne() : base(15) { }
    }
}
