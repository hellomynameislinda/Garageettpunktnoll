using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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

        private string ReadLine(Func<string, bool> checkAllowed = null)
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
                    if (checkAllowed is not null)
                    {
                        if (!checkAllowed(output))
                        {
                            Console.WriteLine("Fältet uppfyller inte kraven");
                            clearChecks = false;
                        }

                        else
                        {
                            clearChecks = true;
                        }
                    }
                    else
                    {
                        clearChecks = true;
                    }
                }
            } while (!clearChecks);
            return output;
        }

        public string ReadString(string label)
        {
            Console.WriteLine(label);
            return ReadLine();
        }

        public string ReadString(string label, Func<ConsoleKey, bool> checkAllowed)
        {
            Console.WriteLine(label);
            return ReadLine();
        }

        internal int ReadInt(string label)
        {
            // IFTIME: Maybe redo function to recieve a delegate function that checks
            string output;
            int intOutput;
            bool clearChecks = false;
            Console.WriteLine(label);
            do
            {
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

        public ConsoleKey ReadKey(string label, Func<ConsoleKey, bool> checkAllowed)
        {
            Console.WriteLine(label);

            ConsoleKey output;
            bool clearChecks = false;
            do
            {
                output = GetKey()!;
                if (!checkAllowed(output))
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

    }
}
