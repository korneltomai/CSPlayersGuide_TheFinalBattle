using TheFinalBattle.Actions;
using TheFinalBattle.Characters;
using TheFinalBattle.Items;

namespace TheFinalBattle.Menu
{
    public class UseItemMenuItem : MenuItem
    {
        public override string Text => "Use Item";

        public UseItemMenuItem(Character character) : base(character) { }

        public override IAction? GetAction(Battle battle)
        {
            battle.GetPartyFor(_character).Inventory.DisplayItems();
            var itemStacks = battle.GetPartyFor(_character).Inventory.GetItemStacksFromInventory();
            int itemIndex = Helpers.ConsoleHelper.GetIndexInputFromPlayer("Which item do you want to use? ", itemStacks.Length + 1) - 1;

            if (itemIndex == itemStacks.Length)
                return null;

            IItem item = itemStacks[itemIndex].Items[0];
            var targets = GetActionTargets(battle, _character, item.ItemData.Targeting, item.ItemData.TargetTeam);
            return new UseItemAction(itemStacks[itemIndex].Items[0], targets);
        }
    }
}
