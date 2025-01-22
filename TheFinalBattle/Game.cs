using System;
using TheFinalBattle.Characters;
using TheFinalBattle.Items;
using TheFinalBattle.Players;

namespace TheFinalBattle
{
    public class Game
    {
        Battle Battle { get; }
        Party[] MonsterParties { get; }

        public Game(Battle battle, Party[] monsterParties) 
        {
            Battle = battle;
            MonsterParties = monsterParties;
        }

        public void Run()
        {
            int waveCount = 1;
            foreach (var wave in MonsterParties)
            {
                WinningParty winner = WinningParty.None;
                Battle.Monsters = wave;

                while (winner == WinningParty.None)
                    winner = Battle.PlayRound();
                    
                if (winner == WinningParty.Monsters)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The Uncoded One's forces have privailed!");
                    Console.ForegroundColor = ConsoleColor.White;

                    return;
                }
                else if (waveCount < MonsterParties.Length)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("The next wave is approaching!");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.White;
                }

                waveCount++;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The Heroes have defeated the Uncoded One!");
            Console.ForegroundColor = ConsoleColor.White;
        }  
    }
}
