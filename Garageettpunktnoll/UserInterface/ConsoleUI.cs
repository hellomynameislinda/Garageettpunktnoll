using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garageettpunktnoll
{
    internal class ConsoleUI
    {
        public void Clear()
        {
            Console.Clear();
        }

        public void WriteLine(string String)
        {
            Console.WriteLine(String);
        }
        public void WriteLineGray(string String) // To use with not implemented menu items
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            WriteLine(String);
            Console.ResetColor();
        }

        public string ReadLine(string label)
        {
            string output;
            do
            {
                Console.WriteLine(label);
                output = Console.ReadLine()!;
            } while (String.IsNullOrEmpty(output));
            return output;
        }

        public ConsoleKey GetKey() => Console.ReadKey(intercept: true).Key;
    }
}
