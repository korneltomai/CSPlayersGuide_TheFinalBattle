using System;
using TheFinalBattle.Characters;

namespace TheFinalBattle
{
    public class Game
    {
        Battle Battle { get; }

        public Game(Battle battle) 
        {
            Battle = battle;
        }

        public void Run()
        {
            
            List<Character>[] waves = GetWaves();

            int waveCount = 0;
            foreach (var wave in waves)
            {
                WinningParty winner = WinningParty.None;
                Battle.Monsters.Characters = wave;
                waveCount++;
                
                while (winner == WinningParty.None)
                    winner = Battle.PlayRound();
                    
                if (winner == WinningParty.Monsters)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The Uncoded One's forces have privailed!");
                    Console.ForegroundColor = ConsoleColor.White;

                    return;
                }
                else if (waveCount < waves.Length)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("The next wave is approaching!");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The Heroes have defeated the Uncoded One!");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private List<Character>[] GetWaves()
        {
            return [
                    [new Skeleton()],
                    [new Skeleton(), new Skeleton()],
                    [new UncodedOne()],
                ];
        }
    }
}
