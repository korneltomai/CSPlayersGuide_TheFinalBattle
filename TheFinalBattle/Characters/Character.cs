using TheFinalBattle.Actions;

namespace TheFinalBattle.Characters
{
    public abstract class Character
    {
        public Battle Battle { get; }
        public string Name { get; }
        public int MaxHealth { get; }
        public int Health { get; set; }

        public Character(Battle battle, string name, int health)
        {
            Battle = battle;
            Name = name;
            MaxHealth = health;
            Health = health;
        }

        public abstract AttackAction GetAttack(Character target);

        public void Hit(int damage)
        {
            Health = Math.Clamp(Health - damage, 0, MaxHealth);
            if (Health == 0)
                Battle.GetPartyFor(this).Remove(this);
        }
    }
}
