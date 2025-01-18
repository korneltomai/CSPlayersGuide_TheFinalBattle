using TheFinalBattle.Actions;
using TheFinalBattle.Characters;
using TheFinalBattle.Players;

namespace TheFinalBattle
{
    public class Party
    {
        public IPlayer Player { get; }
        public List<Character> Characters {  get; set; } = new List<Character>();

        public Party(IPlayer player, List<Character> characters) { 
            Player = player;
            Characters = characters;
        }

        public bool TakeTurn(Battle battle)
        {
            foreach (Character character in Characters) 
            { 
                Console.WriteLine($"It is {character.Name}'s turn...");
                IAction action = Player.GetAction(battle, character);
                action.Do(battle, character);
                Console.WriteLine();

                Thread.Sleep(1000);

                if (battle.GetEnemyPartyFor(character).Count() == 0)
                    return true;
            }
            return false;
        }
    } 
}
