using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFinalBattle
{
    public static class Helpers
    {
        public static int GetIntInputFromPlayer(string text, int max)
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
                    Console.WriteLine("That is not a valid index!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            } while (!validInput);

            return actionIndex;
        }
    }
}
