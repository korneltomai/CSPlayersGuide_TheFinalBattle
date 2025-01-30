using TheFinalBattle.AttackModifiers;
using TheFinalBattle.Attacks;
using TheFinalBattle.Gears;

namespace TheFinalBattle.Characters
{
    public abstract class Character
    {
        public abstract string Name { get; }
        public int MaxHealth { get; }

        private int _health;
        public int Health { get => _health; set => _health = Math.Clamp(value, 0, MaxHealth); }
        public abstract IAttack StandardAttack { get; }
        public IAttack? GearAttack => Gear?.Attack;
        public IGear? Gear { get; set; }
        public List<IAttackModifier> DefensiveModifiers { get; set; } = [];

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
}
