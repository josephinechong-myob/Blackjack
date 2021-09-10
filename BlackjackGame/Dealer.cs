using System;
using System.Collections.Generic;
using System.Xml;

namespace Blackjack
{
    public class Dealer: IBlackjackParticipant
    {
        private readonly Hand _hand;
        public int Score => HandEvaluator.GetTotal(_hand);
        private readonly IConsole _console;
        public string Name { get; }

        public Dealer(Card firstCard, Card secondCard, IConsole console, string name)
        {
            _hand = new Hand(firstCard, secondCard, console);
            _console = console;
            Name = name;
        }
        
        public void Hit(IDeck deck)
        {
            var drawnCard = deck.DrawRandomCard();
            _hand.AddCardToHand(drawnCard);
            _console.WriteLine($"\nDealer has drawn {drawnCard}");
        }

        private bool DealerHasBust()
        {
            var isBust = Score > 21;

            return isBust;
        }
        //Neeed to write tests for printing to console if dealer is 17 or greater
        
        public bool Play(IDeck deck)
        {
            while (Score < 17 && !DealerHasBust())
            {
                HandEvaluator.PrintHand(_hand, Name, _console); //Refactor for participant reference
                Hit(deck);
            }
            HandEvaluator.PrintHand(_hand, Name, _console);
            /*if (DealerHasBust())
            {
                _console.WriteLine("Dealer has bust!");
            }*/
            return false;
        }
    }
}