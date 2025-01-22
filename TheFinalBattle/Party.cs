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
        public Inventory Inventory { get; set; }

        public Party(IPlayer player, List<Character> characters, Inventory inventory) { 
            Player = player;
            Characters = characters;
            Inventory = inventory;
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
    } 
}
