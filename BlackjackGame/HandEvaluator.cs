using System;
using System.Collections.Generic;
using System.Data;

namespace Blackjack
{
    public static class HandEvaluator
    {
        private static int NonAceCards(List<Card> cards)
        {
            var nonAceCardsTotal = 0;
            foreach (var card in cards)
            {
                if (card.Rank != Rank.Ace)
                {
                    nonAceCardsTotal += card.GetValue();
                }
            }
            return nonAceCardsTotal;
        }
        public static int SumOfHand(Hand hand)
        {
            var total = NonAceCards(hand.Cards);
            foreach (var card in hand.Cards)
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