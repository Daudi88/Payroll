using System;

namespace Payroll.Helpers
{
    class Helper
    {
        public static void ErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("[Press any key to continue]");
            Console.ReadKey();
        }

        public static void SuccessMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("[Press any key to continue]");
            Console.ReadKey();
        }

        public static string GetInput()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            var input = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            return input;

        }
    }
}
