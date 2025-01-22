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

            var gears = battle.GetPartyFor(character).Inventory.Gears;
            if (gears.Count > 0 && _random.Next(100) < 50)
                return new EquipGearAction(gears[_random.Next(gears.Count)]);

            int enemyPartySize = battle.GetEnemyPartyFor(character).Characters.Count();

            if (character.Gear != null)
            {
                AttackData attackData = character.GearAttack!.AttackData;
                var attackTargets = GetActionTargets(battle, character, attackData.Targeting, attackData.TargetTeam);
                return new AttackAction(character.GearAttack, attackTargets);
            }
            else
            {
                AttackData attackData = character.StandardAttack!.AttackData;
                var attackTargets = GetActionTargets(battle, character, attackData.Targeting, attackData.TargetTeam);
                return new AttackAction(character.StandardAttack, attackTargets);
            }
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
                        {
                            AttackData attackData = character.StandardAttack.AttackData;
                            var targets = GetActionTargets(battle, character, attackData.Targeting, attackData.TargetTeam);
                            return new AttackAction(character.StandardAttack, targets);
                        }
                    case MenuItem.GearAttack:
                        {
                            AttackData attackData = character.GearAttack!.AttackData;
                            var targets = GetActionTargets(battle, character, attackData.Targeting, attackData.TargetTeam);
                            return new AttackAction(character.GearAttack, targets);
                        }
                    case MenuItem.UseItem:
                        {
                            bool partyHasItems = battle.GetPartyFor(character).Inventory.DisplayItems();
                            if (partyHasItems)
                            {
                                var itemStacks = battle.GetPartyFor(character).Inventory.GetItemStacksFromInventory();
                                int itemIndex = GetIntInputFromPlayer("Which item do you want to use? ", itemStacks.Length) - 1;
                                IItem item = itemStacks[itemIndex].Items[0];
                                var targets = GetActionTargets(battle, character, item.ItemData.Targeting, item.ItemData.TargetTeam);
                                return new UseItemAction(itemStacks[itemIndex].Items[0], targets);
                            }
                            continue;
                        }
                    case MenuItem.EquipGear:
                        var inventory = battle.GetPartyFor(character).Inventory;
                        bool partyHasGears = inventory.DisplayGears();
                        if (partyHasGears)
                        {
                            int gearIndex = GetIntInputFromPlayer("Which item do you want to use? ", inventory.Gears.Count) - 1;
                            return new EquipGearAction(inventory.Gears[gearIndex]);
                        }
                        continue;
                    case MenuItem.UnequipGear:
                        return new UnEquipGearAction(character.Gear!);
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
