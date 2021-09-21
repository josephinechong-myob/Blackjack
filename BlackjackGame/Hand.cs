using System.Collections.Generic;
using System.Linq;
using Blackjack.Cards;

namespace Blackjack
{
    public class Hand 
    {
        public List<Card> Cards;

        public Hand(Card firstCard, Card secondCard)
        {
            Cards = new List<Card>{firstCard, secondCard};
        }
        
        public void AddCardToHand(Card card)
        {
           Cards.Add(card);
        }
        
        public void SortHand()
        {
            Cards = Cards.OrderByDescending(card => card.Rank).ToList();
        }
        
        public void ClearHand()
        {
            Cards.Clear();
        }
        
        public void ResetHand(Card firstCard, Card secondCard)
        {
            Cards = new List<Card>{firstCard, secondCard};
        }
    }
}