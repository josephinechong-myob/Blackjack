using System.Collections.Generic;
using Blackjack.Cards;

namespace Blackjack
{
    public static class HandEvaluator
    {
        public static int GetTotal(Hand hand)
        {
            hand.SortHand();
            var cards = hand.Cards;
            return SumOfHand(cards);
        }
        
        public static void PrintHand(Hand hand, string participantName, IConsole console)
        {
            var diction = (participantName == "Dealer") ? "is" : "is currently";
            var output = ($"{participantName} {diction} at {PrintTotal(hand)}\n"); 
            
            output += ($"with the hand");
            
            foreach (var card in hand.Cards)
            {
                output += ($"[{card}]");
            }
            console.WriteLine(output);
        }
        
        private static int CalculateValueOfAce(int total)
        {
            total = (total <= 10) ? 11 : 1;
            return total;
        }

        private static int SumOfHand(List<Card> cardForSorting)
        {
            var total = 0;
            
            foreach (var card in cardForSorting)
            { 
                if 
                    (card.Rank != Rank.Ace)
                {
                    total += card.GetRankValue();
                }
                else if (card.Rank == Rank.Ace)
                {
                    total += CalculateValueOfAce(total);
                }
            }
            return total;
        }
        
        private static string PrintTotal(Hand hand)
        {
            var total = GetTotal(hand);
            if (total > 21)
            {
                return "bust";
            }
            return total.ToString();
        }
    }
}