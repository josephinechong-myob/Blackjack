using System.Collections.Generic;
using System.Linq;

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

        public void AddCardToHand(Card card)
        {
           Cards.Add(card); 
        }
        
        //no arguments - reassign to field cards Aces coming last
        public void Sort()
        {
            Cards.OrderByDescending(card => card.Rank).ToList();
        }
    }
}