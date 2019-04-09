using System;

namespace Vadavo.NEscPos.Test
{
    public static class ConsoleHelpers
    {
        public static void WriteErrorLine(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static string PromptLine(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(message + " ");
            Console.ResetColor();

            return Console.ReadLine();
        }

        public static ConsoleKeyInfo PromptKey(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(message + " ");
            Console.ResetColor();

            return Console.ReadKey();
        }
    }
}