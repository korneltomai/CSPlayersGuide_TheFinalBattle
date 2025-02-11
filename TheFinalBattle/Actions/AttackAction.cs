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

            if (_attack.AttackData.Targeting == Targeting.TeamTarget)
                Console.WriteLine($"{user.Name} used {_attack.Name}.");
            else
                Console.WriteLine($"{user.Name} used {_attack.Name} on {_targets[0].Name}.");

            foreach (Character target in _targets)
            {
                if (random.NextDouble() >= _attack.AttackData.HitChance)
                    Console.WriteLine($"{_attack.Name} missed.");
                else
                {
                    if (_attack.AttackData.TargetTeam == TargetTeam.OwnTeam)
                        Console.WriteLine($"{_attack.Name} restored {_attack.AttackData.Damage * -1} HP to {target.Name}.");
                    else
                        Console.WriteLine($"{_attack.Name} dealt {_attack.AttackData.Damage} damage to {target.Name}.");

                    target.Hit(battle, _attack.AttackData);
                }
            }
        }
    }
}
