using System;
using TheFinalBattle.Actions;
using TheFinalBattle.Characters;
using TheFinalBattle.Items;

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
            IAction action = new NothingAction();

            IItem? potion = battle.GetPartyFor(character).Items.FirstOrDefault(i => i.Name == "Potion");
            if (potion != null && character.Health <= (character.MaxHealth / 4))
                return new UseItemAction(potion);

            int enemyPartySize = battle.GetEnemyPartyFor(character).Characters.Count();
            Character randomTarget = battle.GetEnemyPartyFor(character).Characters[_random.Next(enemyPartySize)];
            return new AttackAction(character.Attack, randomTarget);
        }
    }

    public class HumanPlayer : IPlayer
    {
        public IAction GetAction(Battle battle, Character character)
        {
            Console.WriteLine($"1 - Attack ({character.Attack.Name})");
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
                            var targets = GetItemTarget(battle, character, itemStacks[itemIndex].Items[0]);
                            return new UseItemAction(itemStacks[itemIndex].Items[0], targets);
                        }
                        continue;
                    case 3:
                        return new NothingAction();
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
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
