using System;
using TheFinalBattle.Attacks;
using TheFinalBattle.Characters;

namespace TheFinalBattle.Items
{
    public class FireBomb : IItem
    {
        public string Name => "FIRE BOMB";
        public ItemData ItemData => new ItemData(Targeting.SingleTarget, TargetTeam.EnemyTeam);
        public void Use(Battle battle, Character target)
        {
            Random random = new Random();
            AttackData attackData = new AttackData(Damage:5, HitChance:90);

            if (random.NextDouble() >= attackData.HitChance)
                Console.WriteLine($"{Name} missed.");
            else
            {
                Console.WriteLine($"{Name} dealt {attackData.Damage} damage to {target.Name}.");
                target.Hit(battle, attackData);
            }
        }
    }
}