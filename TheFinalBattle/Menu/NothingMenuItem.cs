using TheFinalBattle.Actions;
using TheFinalBattle.Characters;

namespace TheFinalBattle.Menu
{
    public class NothingMenuItem : MenuItem
    {
        public override string Text => "Do Nothing";

        public NothingMenuItem(Character character): base(character) { }

        public override IAction GetAction(Battle battle)
        {
            return new NothingAction();
        }
    }
}
