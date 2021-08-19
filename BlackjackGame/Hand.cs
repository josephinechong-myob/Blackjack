using System.Collections.Generic;

namespace Blackjack
{
    public class Hand
    {
        public List<Card> Cards;
        
        //Hand should have a min of 2 cards
        public Hand(Card firstCard, Card secondCard)
        {
            Cards = new List<Card>{firstCard, secondCard};
        }
        public int NonAceCards()
        {
            var nonAceCardsTotal = 0;
            foreach (var card in Cards)
            {
                if (card.Rank != Rank.Ace)
                {
                    nonAceCardsTotal += card.GetValue();
                }
            }
            return nonAceCardsTotal;
        }
        public int SumOfCards()
        {
            var total = NonAceCards();
            foreach (var card in Cards)
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
    }
}