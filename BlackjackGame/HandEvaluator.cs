using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Castle.Components.DictionaryAdapter;

namespace Blackjack
{
    public class HandEvaluator
    {
        private readonly IConsole _console;

        public HandEvaluator(IConsole console)
        {
            _console = console;
        }
        //stateless is allowed to be static - static functions are item idempotent - stateless and can't access fields of a class
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

        public static void PrintHand(Hand hand, string participantName, IConsole console)
        {
            var output = string.Empty;
            string diction = (participantName == "Dealer") ? "is" : "is currently";
            output = ($"{participantName} {diction} at {PrintTotal(hand)}"); 
            
            console.WriteLine(output);
            output = ($"with the hand");
            
            foreach (var card in hand.Cards)
            {
                output += ($"[{card}]");
            }
            console.WriteLine(output);
        }
    }
}