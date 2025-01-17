using TheFinalBattle.Characters;

namespace TheFinalBattle.Actions
{
    public abstract class Action
    {
        protected readonly string _name;
        protected readonly Character _user;

        public Action(string name, Character user)
        {
            _name = name;
            _user = user;
        }

        public abstract void Do();
    }
}
