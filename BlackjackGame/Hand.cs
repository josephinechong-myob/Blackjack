using System.Collections.Generic;

namespace Blackjack
{
    public class Hand
    {
        public List<Card> Cards;
        
        //Hand should have a min of 2 cards
        public Hand()
        {
            Cards = new List<Card>();
            var deck = new Deck();
            Cards.Add(deck.DrawRandomCard());
            Cards.Add(deck.DrawRandomCard());
        }
       
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