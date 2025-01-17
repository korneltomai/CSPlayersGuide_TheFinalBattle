using TheFinalBattle.Characters;

namespace TheFinalBattle
{
    public class Party
    {
        public Player Player { get; }
        public List<Character> Characters {  get; set; } = new List<Character>();

        public Party(Player player) { Player = player; }

        public bool TakeTurn()
        {
            foreach (Character character in Characters) 
            { 
                Console.WriteLine($"It is {character.Name}'s turn...");
                Actions.Action action = Player.GetAction(character);
                action.Do();
                Console.WriteLine();

                Thread.Sleep(1000);

                if (character.Battle.GetEnemyPartyFor(character).Count() == 0)
                    return true;
            }
            return false;
        }
    } 
}
