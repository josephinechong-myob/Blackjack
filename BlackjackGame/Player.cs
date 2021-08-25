using System;
using System.Collections.Generic;

namespace Blackjack
{
    public class Player:IBlackjackParticipant
    {
        public Hand Hand;

        public Player(Card firstCard, Card secondCard)
        {
            Hand = new Hand(firstCard, secondCard);
        }
        
        public void Hit(Deck deck)
        {
            var drawnCard = deck.DrawRandomCard();
            Hand.AddCardToHand(drawnCard);
        }
/*//Not used:
        private bool IsThereABust()
        {
            var score = HandEvaluator.GetTotal(Hand);
            if (score > 21)
            {
                return true;
            }
            return false;
        }
        */
        public void Play(Deck deck)
        {
            bool PlayerHasChosenToStay = false;
            
            while (!PlayerHasChosenToStay)
            {
                var score = HandEvaluator.GetTotal(Hand);
                HandEvaluator.PrintHand(Hand);
                if (score > 21)
                {
                    Console.WriteLine("\nYou have bust!");  
                    break;
                }
                Console.WriteLine("Hit or stay? (Hit = 1, Stay = 0)");  
                
                var answer = Console.ReadLine();
                
                if (answer == "0") PlayerHasChosenToStay = true;

                else if (score == 21)
                {
                    Console.WriteLine("You have won");
                    PlayerHasChosenToStay = true;
                }
                
                else if (answer == "1") Hit(deck);
                
                else Console.WriteLine("Please enter a valid value");
            }
        }
        public void ResetGame(Deck deck)
        {
            
        }
    }
}