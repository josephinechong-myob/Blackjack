using Blackjack.Cards;

namespace Blackjack
{
    internal static class Program
    {
        static void Main()
        {
            var console = new GameConsole();
            var blackjack = new BlackjackGame(console, new Deck());
            blackjack.Run();
            
            while (blackjack.DoesUserWantToContinueGame())
            {
                blackjack.Reset();
                blackjack.Run();
            }
        }
    }
}