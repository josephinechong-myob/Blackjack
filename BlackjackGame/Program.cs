using System;

namespace Blackjack
{
    class Program
    {
        static void Main(string[] args)
        {
            var console = new GameConsole();
            var blackjack = new BlackjackGame(console, new Deck());
            blackjack.Run();
            //possible dependency injections?
        }
    }
}