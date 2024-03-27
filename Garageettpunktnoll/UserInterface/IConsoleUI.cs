
namespace Garageettpunktnoll
{
    internal interface IConsoleUI
    {
        void Clear();
        ConsoleKey GetKey();
        string ReadAnything(string label);
        int ReadInt(string label);
        ConsoleKey ReadKey(string label, Func<ConsoleKey, bool> checkAllowed);
        string ReadString(string label);
        string ReadString(string label, Func<ConsoleKey, bool> checkAllowed);
        bool ReadYesNo(string label);
        void WriteLine(string String);
        void WriteLineGray(string String);
    }
}