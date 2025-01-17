using TheFinalBattle.Characters;

namespace TheFinalBattle.Actions
{
    public class AttackAction : Action
    {
        private readonly Character _target;
        private readonly int _damage;
        public AttackAction(string name, Character user, Character target, int damage) : base(name, user) 
        {
            _target = target;
            _damage = damage;
        }

        public override void Do()
        {
            _target.Hit(_damage);

            Console.WriteLine($"{_user.Name} used {_name} on {_target.Name}.");
            Console.WriteLine($"{_name} dealt {_damage} damage to {_target.Name}");

            if (_target.Health == 0)
                Console.WriteLine($"{_target.Name} has been defeated!");
            else
                Console.WriteLine($"{_target.Name} is now at {_target.Health}/{_target.MaxHealth} HP");

        }
    }
}
