using System;
using System.Collections.Generic;
using System.Xml;

namespace Blackjack
{
    public class Dealer: IBlackjackParticipant
    {
        public Hand Hand;
        public int Score => HandEvaluator.GetTotal(Hand);
        public IConsole Console;

        public Dealer(Card firstCard, Card secondCard, IConsole console)
        {
            Hand = new Hand(firstCard, secondCard);
            Console = console;
        }
        public void Hit(IDeck deck)
        {
            var drawnCard = deck.DrawRandomCard();
            Hand.AddCardToHand(drawnCard);
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
                HandEvaluator.PrintHand(Hand, "Dealer is"); //Refactor for participant reference
                Hit(deck);
            }
            if (DealerHasBust())
            {
                Console.WriteLine("Dealer has bust!");
            }
            return false;
        }
    }
}