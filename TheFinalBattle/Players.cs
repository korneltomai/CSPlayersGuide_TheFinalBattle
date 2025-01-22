using TheFinalBattle.Actions;
using TheFinalBattle.Attacks;
using TheFinalBattle.Characters;
using TheFinalBattle.Items;
using static TheFinalBattle.Menu;
using static TheFinalBattle.Helpers;

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
            AttackData attackData = character.StandardAttack.AttackData;

            var attackTargets = GetActionTargets(battle, character, attackData.Targeting, attackData.TargetTeam);
            return new AttackAction(character.StandardAttack, attackTargets);
        }

        private List<Character> GetActionTargets(Battle battle, Character user, Targeting targeting, TargetTeam targetTeam)
        {
            var ownTeam = battle.GetPartyFor(user).Characters;
            var enemyTeam = battle.GetEnemyPartyFor(user).Characters;

            return (targeting, targetTeam) switch
            {
                (Targeting.SingleTarget, TargetTeam.OwnTeam) => [ownTeam[_random.Next(ownTeam.Count)]],
                (Targeting.TeamTarget, TargetTeam.OwnTeam) => ownTeam,
                (Targeting.SingleTarget, TargetTeam.EnemyTeam) => [enemyTeam[_random.Next(enemyTeam.Count)]],
                (Targeting.TeamTarget, TargetTeam.EnemyTeam) => enemyTeam,
                _ => throw new ArgumentException()
            };
        }
    }

    public class HumanPlayer : IPlayer
    {
        public IAction GetAction(Battle battle, Character character)
        {
            var menuItems = BuildMenu(character);
            DisplayMenu(menuItems, character);

            while (true)
            {
                int actionIndex = GetIntInputFromPlayer("What do you want to do? ", menuItems.Count) - 1;

                switch (menuItems[actionIndex])
                {
                    case MenuItem.StandardAttack:
                        AttackData attackData = character.StandardAttack.AttackData;
                        var attackTargets = GetActionTargets(battle, character, attackData.Targeting, attackData.TargetTeam);
                        return new AttackAction(character.StandardAttack, attackTargets);
                    case MenuItem.EquipAttack:
                        break;
                    case MenuItem.UseItem:
                        bool partyHasItems = battle.GetPartyFor(character).Inventory.DisplayItems();
                        if (partyHasItems)
                        {
                            var itemStacks = battle.GetPartyFor(character).Inventory.GetItemStacksFromInventory();
                            int itemIndex = GetIntInputFromPlayer("Which item do you want to use? ", itemStacks.Length) - 1;
                            IItem item = itemStacks[itemIndex].Items[0];
                            var itemTargets = GetActionTargets(battle, character, item.ItemData.Targeting, item.ItemData.TargetTeam);
                            return new UseItemAction(itemStacks[itemIndex].Items[0], itemTargets);
                        }
                        continue;
                    case MenuItem.EquipGear:
                        break;
                    case MenuItem.UnequipGear:
                        break;
                    case MenuItem.DoNothing:
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
                    int targetIndex = GetIntInputFromPlayer("Select a hero: ", battle.GetPartyFor(user).Characters.Count) - 1;
                    target.Add(battle.GetPartyFor(user).Characters[targetIndex]);
                }
                else
                {
                    int targetIndex = GetIntInputFromPlayer("Select an enemy: ", battle.GetEnemyPartyFor(user).Characters.Count) - 1;
                    target.Add(battle.GetEnemyPartyFor(user).Characters[targetIndex]);
                }

                return target;
            }
        }

        
    }
}
