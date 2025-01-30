using TheFinalBattle.Actions;
using TheFinalBattle.Characters;

namespace TheFinalBattle.Menu
{
    public class EquipGearMenuItem : MenuItem
    {
        public override string Text => "Equip Gear";

        public EquipGearMenuItem(Character character) : base(character) { }

        public override IAction? GetAction(Battle battle)
        {
            battle.GetPartyFor(_character).Inventory.DisplayGears();
            var inventory = battle.GetPartyFor(_character).Inventory;
            int gearIndex = Helpers.ConsoleHelper.GetIndexInputFromPlayer("Which item do you want to use? ", inventory.Gears.Count + 1) - 1;

            if (gearIndex == inventory.Gears.Count)
                return null;

            return new EquipGearAction(inventory.Gears[gearIndex]);
        }
    }
}



