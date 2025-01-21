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
            int enemyPartySize = battle.GetEnemyPartyFor(character).Characters.Count();
            Character randomTarget = battle.GetEnemyPartyFor(character).Characters[_random.Next(enemyPartySize)];
            return new AttackAction(character.Attack, randomTarget);
        }
    }

    public class HumanPlayer : IPlayer
    {
        public IAction GetAction(Battle battle, Character character)
        {
            Console.WriteLine($"1 - Attack");
            Console.WriteLine($"2 - Use Item");
            Console.WriteLine($"3 - Do Nothing");

            while (true)
            {
                int actionIndex = Helpers.GetIntInputFromPlayer("What do you want to do? ", 3);

                switch (actionIndex)
                {
                    case 1:
                        int attackIndex = Helpers.GetIntInputFromPlayer("Who do you want to attack? ", battle.GetEnemyPartyFor(character).Characters.Count) - 1;
                        return new AttackAction(character.Attack, battle.GetEnemyPartyFor(character).Characters[attackIndex]);
                    case 2:
                        bool partyHasItems = battle.GetPartyFor(character).DisplayItems();
                        if (partyHasItems)
                        {
                            var itemStacks = battle.GetPartyFor(character).GetItemStacksFromInventory();
                            int itemIndex = Helpers.GetIntInputFromPlayer("Which item do you want to use? ", itemStacks.Length) - 1;
                            return new UseItemAction(itemStacks[itemIndex].Items[0]);
                        }
                        continue;
                    case 3:
                        return new NothingAction();
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
        }

    }
}
