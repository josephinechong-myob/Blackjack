using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Blackjack
{
    public class HandEvaluator
    {
        //Make a function to evaluate the value of an Ace card based on the information collected to evaluate the Ace
        private static int CalculateValueOfAce(int total)
        {
            if (total <= 10)
            {
                total = 11;
            }
            else
            {
                total = 1;
            }

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
    }
}