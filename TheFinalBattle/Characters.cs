using TheFinalBattle.Attacks;

namespace TheFinalBattle.Characters
{
    public abstract class Character
    {
        public abstract string Name { get; }
        public abstract IAttack StandardAttack { get; }
        public IAttack? GearAttack => Gear?.Attack;
        public IGear? Gear { get; set; }

        public int MaxHealth { get; }

        private int _health;
        public int Health { get => _health; set => _health = Math.Clamp(value, 0, MaxHealth); }

        public Character(int health)
        {
            MaxHealth = health;
            Health = health;
        }

        public Character(int health, IGear gear)
        {
            MaxHealth = health;
            Health = health;
            Gear = gear;
        }

        public override string ToString()
        {
            string text = $"{Name} ({Health}/{MaxHealth})";
            if (Gear != null)
                text += $" [{Gear.Name}]";
            return text;
        }
    }

    public class TrueProgrammer : Character
    {
        public override string Name { get; }
        public override IAttack StandardAttack { get => new Punch(); }

        public TrueProgrammer(string name) : base(25) { Name = name; }
        public TrueProgrammer(string name, IGear gear) : base(25, gear) { Name = name; }
    }

    public class Skeleton : Character
    {
        private readonly Random _random = new Random();
        public override string Name { get => "SKELETON"; }
        public override IAttack StandardAttack { get => new BoneCrunch(); }
        
        public Skeleton() : base(5) { }
        public Skeleton(IGear gear) : base(5, gear) { }
    }

    public class UncodedOne : Character
    {
        private readonly Random _random = new Random();
        public override string Name { get => "UNCODED ONE"; }
        public override IAttack StandardAttack { get => new Unraveling(); }
        
        public UncodedOne() : base(15) { }
        public UncodedOne(IGear gear) : base(15, gear) { }
    }
}
