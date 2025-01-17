using TheFinalBattle.Characters;

namespace TheFinalBattle.Actions
{
    public class NothingAction : Action
    {
        public NothingAction(Character user) : base("NOTHING", user) { }

        public override void Do() => Console.WriteLine($"{_user.Name} did {_name}.");
    }
}
