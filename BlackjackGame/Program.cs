using System;

namespace Blackjack
{
    class Program
    {
        static void Main(string[] args)
        {
            var console = new GameConsole();
            var blackjack = new BlackjackGame(console);
            blackjack.Run();
            
            //possible dependency injections?
        }
    }
}