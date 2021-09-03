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
        private readonly string _name;

        public Dealer(Card firstCard, Card secondCard, IConsole console)
        {
            _hand = new Hand(firstCard, secondCard, console);
            _console = console;
            _name = "Dealer";
        }
        
        public void Hit(IDeck deck)
        {
            var drawnCard = deck.DrawRandomCard();
            _hand.AddCardToHand(drawnCard);
        }

        private bool DealerHasBust()
        {
            var isBust = Score > 21;

            return isBust;
        }
        
        public bool Play(IDeck deck)
        {
            while (Score < 17 && !DealerHasBust())
            {
                HandEvaluator.PrintHand(_hand, _name); //Refactor for participant reference
                Hit(deck);
            }
            if (DealerHasBust())
            {
                _console.WriteLine("Dealer has bust!");
            }
            return false;
        }
    }
}