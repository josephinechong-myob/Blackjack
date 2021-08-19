using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Blackjack
{
    public static class HandEvaluator
    {
        public static int SumOfHand(Hand hand)
        {
            var cards = hand.Cards;
            var total = 0;
            //Ace needs to be evaluated last in a list so function can work
            var orderedCards = cards.OrderBy(card => card.Rank);
            Console.WriteLine(orderedCards);
            //line 16 - 29 put contents of loop into a function that will return the individual value of the card and return total
            //Make a function to evaluate the value of an Ace card based on the information collected to evaluate the Ace
            foreach (var card in cards)
            {
                if (card.Rank != Rank.Ace)
                {
                    total += card.GetValue();
                }
                
                if (card.Rank == Rank.Ace && total <= 10)
                {
                    total += 11;
                }
                else if (card.Rank == Rank.Ace && total > 10)
                {
                    total += 1;
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