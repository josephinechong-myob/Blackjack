using System;
using System.Collections.Generic;

namespace Blackjack
{
    public class Player:IBlackjackParticipant
    {
        private readonly Hand _hand;
        private readonly IConsole _console;
        public int Score => HandEvaluator.GetTotal(_hand);
        public string Name { get; }

        public Player(Card firstCard, Card secondCard, IConsole console, string name)
        {
            _hand = new Hand(firstCard, secondCard, console);
            _console = console;
            Name = name;
        }
        
        public void Hit(IDeck deck)
        {
            var drawnCard = deck.DrawRandomCard();
            _hand.AddCardToHand(drawnCard);
            _console.WriteLine($"\nYou draw {drawnCard}");
        }

        private bool IsThereABust(int score)
        {
            if (score > 21)
            {
                _console.WriteLine("\nYou are currently at bust!");
                return true;
            }
            return false;
        }

        private bool IsThereABlackjack(int score)
        {
            if (score == 21)
            {
                HandEvaluator.PrintHand(_hand, Name, _console);
                return true;
            }
            return false;
        }
       
        private string HitOrStay()
        {
            _console.WriteLine("Hit or stay? (Hit = 1, Stay = 0)");
            while (true)
            {
                var answer = _console.ReadLine();
                if (answer == "1") return "hit";
                if (answer == "0") return "stay";
                _console.WriteLine("Please enter a valid value");
            }
        }
        
        //never use a break, continue and skip statement ever - to exit the loop "break" - rather use boolean conditions for a loop to run
        public bool Play(IDeck deck) 
        {
            while (!IsThereABust(Score) && !IsThereABlackjack(Score))
            {
                HandEvaluator.PrintHand(_hand, Name, _console);
                var choice = HitOrStay();
                if (choice == "hit")
                {
                    Hit(deck);
                }
                else if (choice == "stay")
                {
                    return false;
                }
            }
            return false;
        }
    }
}