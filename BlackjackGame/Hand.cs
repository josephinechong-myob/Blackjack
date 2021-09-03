using System;
using System.Collections.Generic;
using System.Linq;

namespace Blackjack
{
    public class Hand //hand & hand evaluator to pass iconsole through for console.writeline
    {
        public List<Card> Cards;
        private readonly IConsole _console;
        
        //Hand should have a min of 2 cards
        public Hand(Card firstCard, Card secondCard, IConsole console)
        {
            Cards = new List<Card>{firstCard, secondCard};
            _console = console;
        }
        
        public void AddCardToHand(Card card)
        {
           Cards.Add(card);
           _console.WriteLine($"You draw {card}"); //fix up the_console
        }
        
        //Sort list to reassign the field cards for Aces coming last
        public void SortHand()
        {
            Cards = Cards.OrderByDescending(card => card.Rank).ToList();
        }
    }
}