using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Blackjack
{
    public static class HandEvaluator
    {
        //Make a function to evaluate the value of an Ace card based on the information collected to evaluate the Ace
        public static void AceEvaluator(Card card, int total)
        {
            if (card.Rank == Rank.Ace && total <= 10)
            {
                total += 11;
            }
            else if (card.Rank == Rank.Ace && total > 10)
            {
                total += 1;
            }
        }

        public static int SumOfHand(Hand hand)
        {
            var cards = hand.Cards;
            var total = 0;
            
            cards.Sort();
            
            //line 16 - 29 put contents of loop into a function that will return the individual value of the card and return total
            
            foreach (var card in cards)
            {
                if (card.Rank != Rank.Ace)
                {
                    total += card.GetValue();
                }
                else if (card.Rank == Rank.Ace)
                {
                    AceEvaluator(card, total);
                }
            }
            return total;
        }
        public static string WinCondition1(int sum)
        {
            if (sum == 21) return "You have hit 21 and win the game!";
            if (sum > 21) return "You have gone bust";
            return "something";
        }
    }
}