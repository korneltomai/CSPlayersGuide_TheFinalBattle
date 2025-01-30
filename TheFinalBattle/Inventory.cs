using TheFinalBattle.Gears;
using TheFinalBattle.Items;

namespace TheFinalBattle
{
    public class Inventory
    {
        public List<IItem> Items { get; set; } = new List<IItem>();
        public List<IGear> Gears { get; set; } = new List<IGear>();

        public Inventory(List<IItem> items, List<IGear> gears)
        {
            Items = items;
            Gears = gears;
        }

        public void DisplayItems()
        {
            Console.WriteLine("The party has the current items:");

            var items = GetItemStacksFromInventory();

            int index = 1;
            foreach (var itemStack in items)
            {
                Console.WriteLine($"{index}.) {itemStack.Name}: {itemStack.Items.Count}");
                index++;
            }
        }

        public void DisplayGears()
        {
            Console.WriteLine("The party has the current gears:");

            int index = 1;
            foreach (IGear gear in Gears)
            {
                Console.WriteLine($"{index}.) {gear.Name}");
                index++;
            }
        }

        public ItemStack[] GetItemStacksFromInventory()
        {
            List<ItemStack> items = new List<ItemStack>();

            foreach (IItem item in Items)
            {
                var stack = items.FirstOrDefault(i => i.Name == item.Name);
                if (stack == null)
                    items.Add(new ItemStack(item.Name, [item]));
                else
                    stack.Items.Add(item);
            }

            return items.ToArray();
        }

        public record ItemStack(string Name, List<IItem> Items);
    }
}
