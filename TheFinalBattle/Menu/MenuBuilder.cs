using TheFinalBattle.Characters;

namespace TheFinalBattle.Menu
{
    public static class MenuBuilder
    {
        public static List<MenuItem> BuildMenu(Battle battle, Character character)
        {
            List<MenuItem> menuItems = new();

            menuItems.Add(new StandardAttackMenuItem(character));

            if (character.Gear != null) 
                menuItems.Add(new GearAttackMenuItem(character));

            if (battle.GetPartyFor(character).Inventory.Items.Count > 0) 
                menuItems.Add(new UseItemMenuItem(character));

            if (battle.GetPartyFor(character).Inventory.Gears.Count > 0) 
                menuItems.Add(new EquipGearMenuItem(character));

            if (character.Gear != null) 
                menuItems.Add(new UnequipGearMenuItem(character));

            menuItems.Add(new NothingMenuItem(character));

            return menuItems;
        }

        public static void DisplayMenu(List<MenuItem> menuItems, Character character)
        {
            int index = 1;
            foreach (MenuItem menuItem in menuItems)
            {
                Console.WriteLine($"{index}.) {menuItem.Text}");
                index++;
            }
        }
    }
}
