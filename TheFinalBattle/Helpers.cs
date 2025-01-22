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
                    ColorWriteLine("That is not a valid index!", ConsoleColor.Red);
            } while (!validInput);

            return actionIndex;
        }

        public static void PrintLineWithTextInMiddle(char lineChar, string text)
        {
            StringBuilder textToPrint = new StringBuilder();

            int lineCharNumberPerSide = (Console.WindowWidth - (text.Length + 2)) / 2;

            for (int i = 0; i < lineCharNumberPerSide; i++)
                textToPrint.Append(lineChar);

            textToPrint.Append($" {text} ");

            for (int i = 0; i < lineCharNumberPerSide; i++)
                textToPrint.Append(lineChar);

            Console.WriteLine(textToPrint.ToString());
        }

        public static void PrintLine(char lineChar)
        {
            StringBuilder textToPrint = new StringBuilder();

            for (int i = 0; i < Console.WindowWidth; i++)
                textToPrint.Append(lineChar);

            Console.WriteLine(textToPrint.ToString());
        }

        public static void ColorWriteLine(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
