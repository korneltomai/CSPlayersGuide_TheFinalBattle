using TheFinalBattle.Actions;
using TheFinalBattle.Characters;
using TheFinalBattle.Items;
using TheFinalBattle.Players;

namespace TheFinalBattle
{
    public class Party
    {
        public IPlayer Player { get; }
        public List<Character> Characters {  get; set; } = new List<Character>();
        public List<IItem> Items { get; set; } = new List<IItem>();

        public Party(IPlayer player, List<Character> characters, List<IItem> items) { 
            Player = player;
            Characters = characters;
            Items = items;
        }

        public bool TakeTurn(Battle battle)
        {
            foreach (Character character in Characters) 
            {
                battle.DisplayStatus(character);
                Console.WriteLine();
                Console.WriteLine($"It is {character.Name}'s turn...");
                IAction action = Player.GetAction(battle, character);
                action.Do(battle, character);
                Console.WriteLine();

                Thread.Sleep(1000);

                if (battle.GetEnemyPartyFor(character).Characters.Count() == 0)
                    return true;
            }
            return false;
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

        public void DisplayParty(Character currentCharacter, bool alignLeft = false)
        {
            int index = 1;
            foreach (Character c in Characters)
            {
                string characterString = $"{index}.) {c.ToString()}";

                if (c == currentCharacter)
                    Console.ForegroundColor = ConsoleColor.Yellow;

                if (alignLeft)
                {
                    Console.WriteLine(String.Format($"{{0,{Console.WindowWidth}}}", characterString));
                }
                    
                else
                    Console.WriteLine(characterString);
                Console.ForegroundColor = ConsoleColor.White;

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
