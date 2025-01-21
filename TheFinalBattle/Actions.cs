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
        private readonly Character _target;
        public AttackAction(IAttack attack, Character target)
        {
            _attack = attack;
            _target = target;
        }

        public void Do(Battle battle, Character user)
        {
            _target.Health -= _attack.AttackData.Damage;

            Console.WriteLine($"{user.Name} used {_attack.Name} on {_target.Name}.");
            Console.WriteLine($"{_attack.Name} dealt {_attack.AttackData.Damage} damage to {_target.Name}.");

            if (_target.Health == 0)
            {
                Console.WriteLine($"{_target.Name} has been defeated!");
                battle.GetPartyFor(_target).Characters.Remove(_target);
            }
            else
                Console.WriteLine($"{_target.Name} is now at {_target.Health}/{_target.MaxHealth} HP.");

        }
    }

    public class UseItemAction : IAction
    {
        private readonly IItem _item;

        public UseItemAction(IItem item)
        {
            _item = item;
        }

        public void Do(Battle battle, Character user)
        {
            List<Character> targets = GetItemTarget(battle, user, _item);

             foreach (Character target in targets)
            {
                if (user == target)
                    Console.WriteLine($"{user.Name} used {_item.Name} on THEMSELVES.");
                else
                    Console.WriteLine($"{user.Name} used {_item.Name} on {target.Name}.");

                _item.Use(target);
            }

            battle.GetPartyFor(user).Items.Remove(_item);
        }

        private List<Character> GetItemTarget(Battle battle, Character user, IItem item)
        {
            if (item.ItemData.Targeting == Targeting.TeamTarget && item.ItemData.TargetTeam == TargetTeam.OwnTeam)
                return battle.GetPartyFor(user).Characters;
            else if (item.ItemData.Targeting == Targeting.TeamTarget && item.ItemData.TargetTeam == TargetTeam.EnemyTeam)
                return battle.GetEnemyPartyFor(user).Characters;
            else
            {
                List<Character> target = new();

                if (item.ItemData.TargetTeam == TargetTeam.OwnTeam)
                {
                    int targetIndex = Helpers.GetIntInputFromPlayer("Select a hero: ", battle.GetPartyFor(user).Characters.Count) - 1;
                    target.Add(battle.GetPartyFor(user).Characters[targetIndex]);
                }
                else
                {
                    int targetIndex = Helpers.GetIntInputFromPlayer("Select an enemy: ", battle.GetEnemyPartyFor(user).Characters.Count);
                    target.Add(battle.GetEnemyPartyFor(user).Characters[targetIndex]);
                }

                return target;
            }
        }
    }
}
