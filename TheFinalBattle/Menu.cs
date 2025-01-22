using TheFinalBattle.Characters;

namespace TheFinalBattle
{
    public static class Menu
    {
        public static List<MenuItem> BuildMenu(Character character)
        {
            List<MenuItem> menuItems = new();

            menuItems.Add(MenuItem.StandardAttack);
            // menuItems.Add(MenuItem.EquipAttack);
            menuItems.Add(MenuItem.UseItem);
            // menuItems.Add(MenuItem.EquipGear);
            // menuItems.Add(MenuItem.UnequipGear);
            menuItems.Add(MenuItem.DoNothing);

            return menuItems;
        }

        public static void DisplayMenu(List<MenuItem> menuItems, Character character)
        {
            int index = 1;
            foreach (MenuItem menuItem in menuItems)
            {
                string menuItemString = GetMenuItemString(menuItem, character);
                Console.WriteLine($"{index}.) {menuItemString}");
                index++;
            }
        }

        private static string GetMenuItemString(MenuItem menuItem, Character character) 
        {
            return menuItem switch
            {
                MenuItem.StandardAttack => character.StandardAttack.Name,
                // MenuItem.EquipAttack => character.EquipAttack.Name,
                MenuItem.UseItem => "Use Item",
                MenuItem.EquipGear => "Equip Gear",
                MenuItem.UnequipGear => "Unequip Gear",
                MenuItem.DoNothing => "Do Nothing",
                _ => throw new ArgumentException()
            };
        }
            

        public enum MenuItem { StandardAttack = 1, EquipAttack, UseItem, EquipGear, UnequipGear, DoNothing }
    }
}
