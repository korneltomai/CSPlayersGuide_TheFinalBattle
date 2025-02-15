﻿using System;
using TheFinalBattle.Actions;
using TheFinalBattle.Characters;

namespace TheFinalBattle.Players
{
    public class HumanPlayer : IPlayer
    {
        public IAction GetAction(Battle battle, Character character)
        {
            var menuItems = Menu.MenuBuilder.BuildMenu(battle, character);

            IAction? action = null;
            while (action == null)
            {
                Menu.MenuBuilder.DisplayMenu(menuItems, character);
                int actionIndex = Helpers.ConsoleHelper.GetIndexInputFromPlayer("What do you want to do? ", menuItems.Count) - 1;
                action = menuItems[actionIndex].GetAction(battle);
            }

            return action;
        }
    }
}
