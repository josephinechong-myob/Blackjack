using System;
using System.Collections.Generic;

namespace Blackjack
{
    public class Player:IBlackjackParticipant
    {
        public Hand Hand;
        private readonly IConsole Console;

        public Player(Card firstCard, Card secondCard, IConsole console )
        {
            Hand = new Hand(firstCard, secondCard);
            Console = console;
        }
        
        public void Hit(Deck deck)
        {
            var drawnCard = deck.DrawRandomCard();
            Hand.AddCardToHand(drawnCard);
        }

        private bool IsThereABust()
        {
            var score = HandEvaluator.GetTotal(Hand);
            if (score > 21)
            {
                Console.WriteLine("\nThere is a bust!");
                return true;
            }
            return false;
        }
       
        public string HitOrStay()
        {
            Console.WriteLine("Hit or stay? (Hit = 1, Stay = 0)");
            while (true)
            {
                var answer = Console.ReadLine();
                if (answer == "1") return "hit";
                if (answer == "0") return "stay";
                Console.WriteLine("Please enter a valid value");
            }
        }
        
        //never use a break, continue and skip statement ever - to exit the loop "break" - rather use boolean conditions for a loop to run
        public void Play(Deck deck)
        {
            var score = 0;
            bool playerWantsToStay = false;

            while (!IsThereABust() && !playerWantsToStay)
            {
                HandEvaluator.PrintHand(Hand);
                var choice = HitOrStay();
                if (choice == "hit")
                {
                    Hit(deck);
                    score = HandEvaluator.GetTotal(Hand);
                    HandEvaluator.PrintHand(Hand);
                }
                else if (choice == "stay")
                {
                    playerWantsToStay = true;
                }
            }

            if (score == 21)
            {
                Console.WriteLine("\nYou have won!");
            }
        }
        public void ResetGame(Deck deck)
        {
            
        }
    }
}