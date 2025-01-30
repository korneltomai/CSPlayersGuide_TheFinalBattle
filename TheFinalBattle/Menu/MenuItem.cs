using TheFinalBattle.Actions;
using TheFinalBattle.Attacks;
using TheFinalBattle.Characters;

namespace TheFinalBattle.Menu
{
    public abstract class MenuItem
    {
        public abstract string Text { get; }
        protected Character _character;

        public MenuItem(Character character) 
        { 
            _character = character; 
        }

        public abstract IAction? GetAction(Battle battle);

        protected List<Character> GetActionTargets(Battle battle, Character user, Targeting targeting, TargetTeam targetTeam)
        {
            if (targeting == Targeting.TeamTarget && targetTeam == TargetTeam.OwnTeam)
                return battle.GetPartyFor(user).Characters;
            else if (targeting == Targeting.TeamTarget && targetTeam == TargetTeam.EnemyTeam)
                return battle.GetEnemyPartyFor(user).Characters;
            else
            {
                List<Character> target = new();

                if (targetTeam == TargetTeam.OwnTeam)
                {
                    int targetIndex = Helpers.ConsoleHelper.GetIndexInputFromPlayer("Select a friendly character: ", battle.GetPartyFor(user).Characters.Count) - 1;
                    return [battle.GetPartyFor(user).Characters[targetIndex]];
                }
                else
                {
                    int targetIndex = Helpers.ConsoleHelper.GetIndexInputFromPlayer("Select an enemy character: ", battle.GetEnemyPartyFor(user).Characters.Count) - 1;
                    return [battle.GetEnemyPartyFor(user).Characters[targetIndex]];
                }
            }
        }
    }
}
