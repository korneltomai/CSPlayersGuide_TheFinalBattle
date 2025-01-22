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
            Random random = new Random();

            foreach (Character target in _targets)
            {
                Console.WriteLine($"{user.Name} used {_attack.Name} on {target.Name}.");

                if (random.NextDouble() >= _attack.AttackData.hitChance)
                    Console.WriteLine($"{_attack.Name} missed.");
                else
                {
                    AttackData attackData = _attack.AttackData;
                    foreach (var modifier in target.DefensiveModifiers)
                        attackData = modifier.Apply(attackData);
                    target.Health -= attackData.Damage;
                    Console.WriteLine($"{_attack.Name} dealt {attackData.Damage} damage to {target.Name}.");

                    if (target.Health == 0)
                    {
                        Helpers.ColorWriteLine($"{target.Name} has been defeated!", ConsoleColor.Green);
                        battle.GetPartyFor(target).Characters.Remove(target);

                        if (target.Gear != null)
                        {
                            battle.GetEnemyPartyFor(target).Inventory.Gears.Add(target.Gear);
                            Helpers.ColorWriteLine($"You have looted {target.Gear.Name} from {target.Name}.", ConsoleColor.DarkGreen);
                            target.Gear = null;
                        }
                    }
                    else
                        Console.WriteLine($"{target.Name} is now at {target.Health}/{target.MaxHealth} HP.");
                }
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

                battle.GetPartyFor(user).Inventory.Items.Remove(_item);
            }
        }
    }

    public class EquipGearAction : IAction
    {
        private readonly IGear _gear;

        public EquipGearAction(IGear gear)
        {
            _gear = gear;
        }

        public void Do(Battle battle, Character user)
        {
            if (user.Gear != null)
            {
                battle.GetPartyFor(user).Inventory.Gears.Add(user.Gear);
                Console.WriteLine($"{user.Name} has swapped his {user.Gear.Name} to {_gear.Name}.");
            }
            else
                Console.WriteLine($"{user.Name} has equipped {_gear.Name}.");

            user.Gear = _gear;
            battle.GetPartyFor(user).Inventory.Gears.Remove(_gear);
        }
    }

    public class UnEquipGearAction : IAction
    {
        private readonly IGear _gear;

        public UnEquipGearAction(IGear gear)
        {
            _gear = gear;
        }

        public void Do(Battle battle, Character user)
        {
            battle.GetPartyFor(user).Inventory.Gears.Add(user.Gear!);
            user.Gear = null;

            Console.WriteLine($"{user.Name} has unequipped his {_gear.Name}.");
        }
    }

    public enum Targeting { SingleTarget, TeamTarget }
    public enum TargetTeam { OwnTeam, EnemyTeam }
}
