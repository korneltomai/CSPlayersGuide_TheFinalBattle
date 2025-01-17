using System.Reflection.Metadata.Ecma335;
using TheFinalBattle.Actions;

namespace TheFinalBattle.Characters
{
    public class UncodedOne : Character
    {
        private readonly Random _random = new Random();
        public UncodedOne(Battle battle) : base(battle, "UNCODED ONE", 15) { }
        public override AttackAction GetAttack(Character target) => new AttackAction("UNRAVELING", this, target, _random.Next(3));
    }
}
