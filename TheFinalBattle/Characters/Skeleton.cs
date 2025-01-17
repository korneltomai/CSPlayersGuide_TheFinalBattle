using System.Reflection.Metadata.Ecma335;
using TheFinalBattle.Actions;

namespace TheFinalBattle.Characters
{
    public class Skeleton : Character
    {
        private readonly Random _random = new Random();
        public Skeleton(Battle battle): base(battle, "SKELETON", 5) { }
        public override AttackAction GetAttack(Character target) => new AttackAction("BONE CRUNCH", this, target, _random.Next(2));
    }
}
