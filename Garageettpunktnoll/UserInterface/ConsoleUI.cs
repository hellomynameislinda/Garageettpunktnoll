using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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

        private string ReadLine()
        {
            string output;
            bool clearChecks = false;
            do
            {
                output = Console.ReadLine()!;
                if (String.IsNullOrEmpty(output))
                {
                    clearChecks = false;
                    Console.WriteLine("Fältet kan inte lämnas tomt. Försök igen:");
                }
                else
                {
                    clearChecks = true;
                }
            } while (!clearChecks);
            return output;
        }

        public string ReadString(string label)
        {
            Console.WriteLine(label);
            return ReadLine();
        }

        internal int ReadInt(string label)
        {
            // TODO: Maybe redo function to recieve a delegate function that checks
            string output;
            int intOutput;
            bool clearChecks = false;
            do
            {
                Console.WriteLine(label);
                output = ReadLine();

                if (int.TryParse(output, out intOutput))
                {
                    clearChecks = true;
                }
                else
                {
                    clearChecks = false;
                    label += "\nDu kan bara ange siffror, försök igen:";
                }
            } while (!clearChecks);
            return intOutput;
        }

        public ConsoleKey GetKey() => Console.ReadKey(intercept: true).Key;


    }
}
