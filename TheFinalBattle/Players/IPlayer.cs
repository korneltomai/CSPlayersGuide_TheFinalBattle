using TheFinalBattle.Actions;
using TheFinalBattle.Characters;

namespace TheFinalBattle.Players
{
    public interface IPlayer
    {
        public IAction GetAction(Battle battle, Character character);
    }
}
