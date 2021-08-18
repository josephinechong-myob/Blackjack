using System.Collections.Generic;

namespace Blackjack
{
    public class Hand
    {
        public int NonAceCards(params Card[] playerHand2)
        {
            var nonAceCardsTotal = 0;
            foreach (var card in playerHand2)
            {
                if (card.Rank != Rank.Ace)
                {
                    nonAceCardsTotal += card.GetValue();
                }
            }

            return nonAceCardsTotal;
        }

        public int SumOfCards(params Card[] playerHand)
        {
        var hand = new Hand();
        var total = NonAceCards(playerHand);
            foreach (var card in playerHand)
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
        public int SumOfCards(List<Card> playerHand)
        {
            return SumOfCards(playerHand.ToArray());
        }
    }
}