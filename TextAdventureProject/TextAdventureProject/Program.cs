using System;

namespace TextAdventureProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }


        public static void WriteColored(string text, ConsoleColor textColor)
        {
            ConsoleColor c = Console.ForegroundColor;
            Console.ForegroundColor = textColor;

            Console.Write(text);

            Console.ForegroundColor = c;
        }

        public static void WriteLineColored(string text, ConsoleColor textColor)
        {
            ConsoleColor c = Console.ForegroundColor;
            Console.ForegroundColor = textColor;

            Console.WriteLine(text);

            Console.ForegroundColor = c;
        }

        public static int ReadNumericInput(int maxNumber, int minNumber = 1)
        {
            throw new NotImplementedException();
        }
    }
}
