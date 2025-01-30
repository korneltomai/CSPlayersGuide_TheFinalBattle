using TheFinalBattle.Actions;
using TheFinalBattle.Attacks;
using TheFinalBattle.Characters;

namespace TheFinalBattle.Menu
{
    public class GearAttackMenuItem : MenuItem
    {
        public override string Text => $"{_character.GearAttack!.Name}";

        public GearAttackMenuItem(Character character) : base(character) { }

        public override IAction? GetAction(Battle battle)
        {
            AttackData attackData = _character.GearAttack!.AttackData;
            var targets = GetActionTargets(battle, _character, attackData.Targeting, attackData.TargetTeam);
            return new AttackAction(_character.GearAttack, targets);
        }
    }
}
