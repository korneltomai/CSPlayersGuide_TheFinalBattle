using TheFinalBattle.Characters;

namespace TheFinalBattle.Actions
{
    public class NothingAction : IAction
    {
        public void Do(Battle battle, Character user) => Console.WriteLine($"{user.Name} did NOTHING.");
    }
}
