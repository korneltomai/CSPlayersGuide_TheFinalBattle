using TheFinalBattle.Attacks;
using TheFinalBattle.Characters;
using TheFinalBattle.Helpers;

namespace TheFinalBattle.Actions
{
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
                        ConsoleHelper.ColorWriteLine($"{target.Name} has been defeated!", ConsoleColor.Green);
                        battle.GetPartyFor(target).Characters.Remove(target);

                        if (target.Gear != null)
                        {
                            battle.GetEnemyPartyFor(target).Inventory.Gears.Add(target.Gear);
                            ConsoleHelper.ColorWriteLine($"You have looted {target.Gear.Name} from {target.Name}.", ConsoleColor.DarkGreen);
                            target.Gear = null;
                        }
                    }
                    else
                        Console.WriteLine($"{target.Name} is now at {target.Health}/{target.MaxHealth} HP.");
                }
            }
        }
    }
}
