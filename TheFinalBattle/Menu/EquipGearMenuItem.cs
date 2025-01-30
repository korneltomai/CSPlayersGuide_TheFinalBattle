using TheFinalBattle.Actions;
using TheFinalBattle.Characters;
using TheFinalBattle.Items;

namespace TheFinalBattle.Menu
{
    public class EquipGearMenuItem : MenuItem
    {
        public override string Text => "Equip Gear";

        public EquipGearMenuItem(Character character) : base(character) { }

        public override IAction GetAction(Battle battle)
        {
            var inventory = battle.GetPartyFor(_character).Inventory;
            int gearIndex = Helpers.ConsoleHelper.GetIndexInputFromPlayer("Which item do you want to use? ", inventory.Gears.Count) - 1;
            return new EquipGearAction(inventory.Gears[gearIndex]);
        }
    }
}



