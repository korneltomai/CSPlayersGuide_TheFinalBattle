using System;
using TheFinalBattle.AttackModifiers;
using TheFinalBattle.Attacks;
using TheFinalBattle.Gears;
using TheFinalBattle.Helpers;

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

        public void Hit(Battle battle, AttackData attackData)
        {
            foreach (var modifier in DefensiveModifiers)
                attackData = modifier.Apply(attackData);
            Health -= attackData.Damage;
            

            if (Health == 0)
            {
                ConsoleHelper.ColorWriteLine($"{Name} has been defeated!", ConsoleColor.Green);
                battle.GetPartyFor(this).Characters.Remove(this);

                if (Gear != null)
                {
                    battle.GetEnemyPartyFor(this).Inventory.Gears.Add(Gear);
                    ConsoleHelper.ColorWriteLine($"You have looted {Gear.Name} from {Name}.", ConsoleColor.DarkGreen);
                    Gear = null;
                }
            }
            else
                Console.WriteLine($"{Name} is now at {Health}/{MaxHealth} HP.");
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
