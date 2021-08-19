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

        public int CalculateSumOfAllCards()
        {
            var sumOfAllCards = HandEvaluator.SumOfHand(this);
            return sumOfAllCards;
        }
    }
}