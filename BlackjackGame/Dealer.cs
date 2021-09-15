using System;
using System.Collections.Generic;
using System.Xml;
using Blackjack.Cards;

namespace Blackjack
{
    public class Dealer: IBlackjackParticipant
    {
        public Hand Hand { get; }
        public int Score => HandEvaluator.GetTotal(Hand);
        private readonly IConsole _console;
        public string Name { get; }

        public Dealer(Card firstCard, Card secondCard, IConsole console, string name)
        {
            Hand = new Hand(firstCard, secondCard, console);
            _console = console;
            Name = name;
        }
        
        public void Hit(IDeck deck)
        {
            var drawnCard = deck.DrawRandomCard();
            Hand.AddCardToHand(drawnCard);
            _console.WriteLine($"\nDealer has drawn {drawnCard}");
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
                HandEvaluator.PrintHand(Hand, Name, _console);
                Hit(deck);
            }
            HandEvaluator.PrintHand(Hand, Name, _console);
            
            return false;
        }
    }
}