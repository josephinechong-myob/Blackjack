using System;

namespace Blackjack
{
    public class GameConsole : IConsole
    {
        public void WriteLine(string writeLine)
        {
            Console.WriteLine(writeLine);
        }
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}