using TheFinalBattle.Characters;

namespace TheFinalBattle.Actions
{
    public interface IAction
    {
        void Do(Battle battle, Character user);
    }
}
