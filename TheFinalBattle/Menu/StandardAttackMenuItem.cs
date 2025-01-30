using TheFinalBattle.Actions;
using TheFinalBattle.Attacks;
using TheFinalBattle.Characters;

namespace TheFinalBattle.Menu
{
    public class StandardAttackMenuItem : MenuItem
    {
        public override string Text => $"{_character.StandardAttack.Name}";
        public StandardAttackMenuItem(Character character) : base(character) { }
        public override IAction? GetAction(Battle battle)
        {
            AttackData attackData = _character.StandardAttack.AttackData;
            var targets = GetActionTargets(battle, _character, attackData.Targeting, attackData.TargetTeam);
            return new AttackAction(_character.StandardAttack, targets);
        }
    }
}