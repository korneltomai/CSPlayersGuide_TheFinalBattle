using TheFinalBattle.Actions;
using TheFinalBattle.Characters;

namespace TheFinalBattle
{
    public class Player
    {
        public PlayerType PlayerType { get; }

        public Player(PlayerType playerType) { PlayerType = playerType; }

        public Actions.Action GetAction(Character character)
        {
            Actions.Action? action = null;

            if (PlayerType == PlayerType.Computer)
                action = character.GetAttack(character.Battle.GetEnemyPartyFor(character)[0]);
            else if (PlayerType == PlayerType.Human)
            {
                Console.WriteLine($"1 - Attack");
                Console.WriteLine($"2 - Do Nothing");

                int actionIndex = GetActionInputFromPlayer("What do you want to do? ", 2);

                action = actionIndex switch
                {
                    1 => character.GetAttack(character.Battle.GetEnemyPartyFor(character)[0]),
                    2 => new NothingAction(character),
                    _ => throw new IndexOutOfRangeException()
                };
            }

            return action!;
        }

        private int GetActionInputFromPlayer(string text, int max)
        {
            int actionIndex = 0;

            bool validInput = false;
            do
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(text);
                Console.ForegroundColor = ConsoleColor.White;

                string input = Console.ReadLine() ?? "";
                validInput = Int32.TryParse(input, out actionIndex) && actionIndex <= max && actionIndex >= 1;

                if (!validInput)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That is not a valid index for an action!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            } while (!validInput);

            return actionIndex;
        }
    }

    public enum PlayerType { Computer, Human }
}
