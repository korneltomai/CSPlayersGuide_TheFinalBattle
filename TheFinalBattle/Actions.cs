﻿using TheFinalBattle.Attacks;
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
        private readonly Character _target;

        public UseItemAction(IItem item, Character target)
        {
            _item = item;
            _target = target;
        }

        public void Do(Battle battle, Character user)
        {
            if (user == _target)
                Console.WriteLine($"{user.Name} used {_item.Name} on THEMSELVES.");
            else
                Console.WriteLine($"{user.Name} used {_item.Name} on {_target.Name}.");

            _item.Use(_target);
            battle.GetPartyFor(user).Items.Remove(_item);
        }
    }
}
