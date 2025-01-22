using TheFinalBattle.Items;

namespace TheFinalBattle
{
    public class Inventory
    {
        public List<IItem> Items { get; set; } = new List<IItem>();

        public Inventory(List<IItem> items)
        {
            Items = items;
        }

        public bool DisplayItems()
        {
            if (Items.Count == 0)
            {
                Console.WriteLine("You party has no items.");
                return false;
            }
            else
            {
                Console.WriteLine("The party has the current items:");

                var items = GetItemStacksFromInventory();

                int index = 1;
                foreach (var itemStack in items)
                {
                    Console.WriteLine($"{index}.) {itemStack.Name}: {itemStack.Items.Count}");
                    index++;
                }

                return true;
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
