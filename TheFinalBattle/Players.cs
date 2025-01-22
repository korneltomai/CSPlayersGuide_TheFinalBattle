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

            IItem? potion = battle.GetPartyFor(character).Inventory.Items.FirstOrDefault(i => i.Name == "POTION");
            if (potion != null && 
                character.Health <= (character.MaxHealth / 4) &&
                _random.Next(100) < 25)
                    return new UseItemAction(potion, [character]);
                

            int enemyPartySize = battle.GetEnemyPartyFor(character).Characters.Count();
            var attackTargets = GetActionTargets(battle, character, character.Attack.AttackData.Targeting, character.Attack.AttackData.TargetTeam);
            return new AttackAction(character.Attack, attackTargets);
        }

        private List<Character> GetActionTargets(Battle battle, Character user, Targeting targeting, TargetTeam targetTeam)
        {
            return (targeting, targetTeam) switch
            {
                (Targeting.SingleTarget, TargetTeam.OwnTeam) => [battle.GetPartyFor(user).Characters[_random.Next(battle.GetPartyFor(user).Characters.Count)]],
                (Targeting.TeamTarget, TargetTeam.OwnTeam) => battle.GetPartyFor(user).Characters,
                (Targeting.SingleTarget, TargetTeam.EnemyTeam) => [battle.GetEnemyPartyFor(user).Characters[_random.Next(battle.GetEnemyPartyFor(user).Characters.Count)]],
                (Targeting.TeamTarget, TargetTeam.EnemyTeam) => battle.GetEnemyPartyFor(user).Characters,
                _ => throw new ArgumentException()
            };
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
                        var attackTargets = GetActionTargets(battle, character, character.Attack.AttackData.Targeting, character.Attack.AttackData.TargetTeam);
                        return new AttackAction(character.Attack, attackTargets);
                    case 2:
                        bool partyHasItems = battle.GetPartyFor(character).Inventory.DisplayItems();
                        if (partyHasItems)
                        {
                            var itemStacks = battle.GetPartyFor(character).Inventory.GetItemStacksFromInventory();
                            int itemIndex = Helpers.GetIntInputFromPlayer("Which item do you want to use? ", itemStacks.Length) - 1;
                            IItem item = itemStacks[itemIndex].Items[0];
                            var itemTargets = GetActionTargets(battle, character, item.ItemData.Targeting, item.ItemData.TargetTeam);
                            return new UseItemAction(itemStacks[itemIndex].Items[0], itemTargets);
                        }
                        continue;
                    case 3:
                        return new NothingAction();
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
        }

        private List<Character> GetActionTargets(Battle battle, Character user, Targeting targeting, TargetTeam targetTeam)
        {
            if (targeting == Targeting.TeamTarget && targetTeam == TargetTeam.OwnTeam)
                return battle.GetPartyFor(user).Characters;
            else if (targeting == Targeting.TeamTarget && targetTeam == TargetTeam.EnemyTeam)
                return battle.GetEnemyPartyFor(user).Characters;
            else
            {
                List<Character> target = new();

                if (targetTeam == TargetTeam.OwnTeam)
                {
                    int targetIndex = Helpers.GetIntInputFromPlayer("Select a hero: ", battle.GetPartyFor(user).Characters.Count) - 1;
                    target.Add(battle.GetPartyFor(user).Characters[targetIndex]);
                }
                else
                {
                    int targetIndex = Helpers.GetIntInputFromPlayer("Select an enemy: ", battle.GetEnemyPartyFor(user).Characters.Count) - 1;
                    target.Add(battle.GetEnemyPartyFor(user).Characters[targetIndex]);
                }

                return target;
            }
        }

    }
}
