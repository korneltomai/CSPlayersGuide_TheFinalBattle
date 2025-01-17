using TheFinalBattle.Actions;

namespace TheFinalBattle.Characters
{
    public class TrueProgrammer : Character
    {
        public TrueProgrammer(Battle battle, string name) : base(battle, name, 25) { }

        public override AttackAction GetAttack(Character target) => new AttackAction("PUNCH", this, target, 1);
    }
}
