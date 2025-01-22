using TheFinalBattle.Attacks;
using TheFinalBattle.Characters;
using TheFinalBattle.Items;

namespace TheFinalBattle.Actions
{
    public interface IAction
    {
        void Do(Battle battle, Character user);
    }

    public class NothingAction : IAction
    {
        public void Do(Battle battle, Character user) => Console.WriteLine($"{user.Name} did NOTHING.");
    }

    public class AttackAction : IAction
    {
        private readonly IAttack _attack;
        private readonly List<Character> _targets;
        public AttackAction(IAttack attack, List<Character> targets)
        {
            _attack = attack;
            _targets = targets;
        }

        public void Do(Battle battle, Character user)
        {
            foreach (Character target in _targets)
            {
                target.Health -= _attack.AttackData.Damage;

                Console.WriteLine($"{user.Name} used {_attack.Name} on {target.Name}.");
                Console.WriteLine($"{_attack.Name} dealt {_attack.AttackData.Damage} damage to {target.Name}.");

                if (target.Health == 0)
                {
                    Console.WriteLine($"{target.Name} has been defeated!");
                    battle.GetPartyFor(target).Characters.Remove(target);
                }
                else
                    Console.WriteLine($"{target.Name} is now at {target.Health}/{target.MaxHealth} HP.");
            }
        }
    }

    public class UseItemAction : IAction
    {
        private readonly IItem _item;
        private readonly List<Character> _targets;

        public UseItemAction(IItem item, List<Character> targets)
        {
            _item = item;
            _targets = targets;
        }

        public void Do(Battle battle, Character user)
        {
            foreach (Character target in _targets)
            {
                if (user == target)
                    Console.WriteLine($"{user.Name} used {_item.Name} on THEMSELVES.");
                else
                    Console.WriteLine($"{user.Name} used {_item.Name} on {target.Name}.");

                _item.Use(target);

                battle.GetPartyFor(user).Items.Remove(_item);
            }
        } 
    }

    public enum Targeting { SingleTarget, TeamTarget }
    public enum TargetTeam { OwnTeam, EnemyTeam }
}
