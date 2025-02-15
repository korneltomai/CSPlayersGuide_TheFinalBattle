﻿using System;
using TheFinalBattle.Characters;
using TheFinalBattle.Helpers;
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
                    ConsoleHelper.ColorWriteLine("The Uncoded One's forces have privailed!", ConsoleColor.Red);
                    Console.ForegroundColor = ConsoleColor.White;

                    return;
                }
                else if (waveCount < MonsterParties.Length)
                {
                    ConsoleHelper.ColorWriteLine("The next wave is approaching!", ConsoleColor.Magenta);
                    Console.WriteLine();

                    Thread.Sleep(3000);
                }

                waveCount++;
            }

            ConsoleHelper.ColorWriteLine("The Heroes have defeated the Uncoded One!", ConsoleColor.Green);
        }  
    }
}
