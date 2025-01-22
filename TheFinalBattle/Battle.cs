using TheFinalBattle.Characters;
using TheFinalBattle.Items;

namespace TheFinalBattle
{
    public class Battle
    {
        public Party Heroes { get; }
        public Party? Monsters { get; set; }

        public Battle(Party heroes) 
        {
            Heroes = heroes;
        }

        public WinningParty PlayRound()
        {
            if (Heroes.TakeTurn(this))
            {
                LootMonsters();
                return WinningParty.Heroes;
            }
                
            if (Monsters!.TakeTurn(this))
                return WinningParty.Monsters;
            return WinningParty.None;
        }        

        public Party GetPartyFor(Character character)
        {
            foreach (Character c in Heroes.Characters)
                if (c == character)
                    return Heroes;
            return Monsters!;
        }

        public Party GetEnemyPartyFor(Character character)
        {
            foreach (Character c in Heroes.Characters)
                if (c == character)
                    return Monsters!;
            return Heroes;
        }

        public void DisplayStatus(Character currentCharacter)
        {
            Helpers.PrintLineWithTextInMiddle('=', "BATTLE");
            Heroes.DisplayParty(currentCharacter);
            Helpers.PrintLineWithTextInMiddle('-', "VS");
            Monsters!.DisplayParty(currentCharacter, true);
            Helpers.PrintLine('=');
        }

        private void LootMonsters() 
        {
            if (Monsters!.Inventory.Items.Count > 0)
            {
                Heroes.Inventory.Items.AddRange(Monsters!.Inventory.Items);

                string itemLootString = "You have looted the following items from the monsters: ";
                foreach (IItem item in Monsters!.Inventory.Items)
                {
                    itemLootString += $"{item.Name}, ";
                }

                Monsters!.Inventory.Items.Clear();

                Console.WriteLine(itemLootString[..^2]);
            }

            if (Monsters!.Inventory.Gears.Count > 0)
            {
                Heroes.Inventory.Gears.AddRange(Monsters!.Inventory.Gears);

                string gearLootString = "You have looted the following gears from the monsters: ";
                foreach (IGear gear in Monsters!.Inventory.Gears)
                {
                    gearLootString += $"{gear.Name}, ";
                }

                Monsters!.Inventory.Gears.Clear();

                Console.WriteLine(gearLootString[..^2]);
            }     
        }
    }

    public enum WinningParty { Heroes, Monsters, None }
}
