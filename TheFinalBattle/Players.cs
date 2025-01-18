using System;
using TheFinalBattle.Actions;
using TheFinalBattle.Characters;

namespace TheFinalBattle.Players
{
    public interface IPlayer
    {
        public IAction GetAction(Battle battle, Character character);
    }

    public class ComputerPlayer : IPlayer
    {
        private readonly Random _random = new Random();

        public IAction GetAction(Battle battle, Character character)
        {
            int enemyPartySize = battle.GetEnemyPartyFor(character).Count();
            Character randomTarget = battle.GetEnemyPartyFor(character)[_random.Next(enemyPartySize)];
            return new AttackAction(character.Attack, randomTarget);
        }
    }

    public class HumanPlayer : IPlayer
    {
        public IAction GetAction(Battle battle, Character character)
        {
            Console.WriteLine($"1 - Attack");
            Console.WriteLine($"2 - Do Nothing");

            int actionIndex = Helpers.GetIntInputFromPlayer("What do you want to do? ", 2);

            return actionIndex switch
            {
                1 => new AttackAction(character.Attack, battle.GetEnemyPartyFor(character)[0]),
                2 => new NothingAction(),
                _ => throw new IndexOutOfRangeException()
            };
        }

    }
}
