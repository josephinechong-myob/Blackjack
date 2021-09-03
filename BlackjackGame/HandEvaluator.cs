using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Blackjack
{
    public class HandEvaluator
    {
        //stateless is allowed to be static - static fuctions are item idempotent - stateless and can't access fields of a class
        //Make a function to evaluate the value of an Ace card based on the information collected to evaluate the Ace
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
        public static int GetTotal(Hand hand)
        {
            hand.SortHand();
            var cards = hand.Cards;
            return SumOfHand(cards);
        }

        private static string PrintTotal(Hand hand)
        {
            var total = GetTotal(hand);
            if (total > 21)
            {
                return "Bust";
            }
            return total.ToString();
        }

        public static void PrintHand(Hand hand, string participantName)
        {
            if (participantName == "Dealer")
            {
                Console.WriteLine($"{participantName} is at {PrintTotal(hand)}");
            }
            else
            {
                Console.WriteLine($"{participantName} are at currently at {PrintTotal(hand)}"); 
            }
            
            Console.Write($"with the hand");
                foreach (var card in hand.Cards)
                {
                    Console.Write($"[{card}]");
                }
        }
    }
}