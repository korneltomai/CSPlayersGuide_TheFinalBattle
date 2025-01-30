using TheFinalBattle.Actions;
using TheFinalBattle.Characters;
using TheFinalBattle.Items;

namespace TheFinalBattle.Menu
{
    public class UnequipGearMenuItem : MenuItem
    {
        public override string Text => "Unequip Gear";

        public UnequipGearMenuItem(Character character) : base(character) { }

        public override IAction GetAction(Battle battle)
        {
            return new UnEquipGearAction(_character.Gear!);
        }
    }
}