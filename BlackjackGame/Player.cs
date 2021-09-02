using System;
using System.Collections.Generic;

namespace Blackjack
{
    public class Player:IBlackjackParticipant
    {
        private Hand Hand;
        private readonly IConsole Console;
        public int Score => HandEvaluator.GetTotal(Hand);

        public Player(Card firstCard, Card secondCard, IConsole console )
        {
            Hand = new Hand(firstCard, secondCard);
            Console = console;
        }
        
        public void Hit(IDeck deck)
        {
            var drawnCard = deck.DrawRandomCard();
            Hand.AddCardToHand(drawnCard);
        }

        private bool IsThereABustOrWin(int score)
        {
            if (score >= 21)
            {
                Console.WriteLine("\nThere is a bust!");
                return true;
            }
            return false;
        }
       
        private string HitOrStay()
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
        public bool Play(IDeck deck) //return a value 0 or 1 OR record player has finished playing (public field HasPlayed)
        {
            while (!IsThereABustOrWin(Score)) //separte methods for bust or win (not a bust && not a win), optional step a method over over the top which is play has ended
            {
                HandEvaluator.PrintHand(Hand, "You are at currently");
                var choice = HitOrStay();
                if (choice == "hit")
                {
                    Hit(deck);
                }
                else if (choice == "stay") //return 1
                {
                    return false;
                }
            }
//this following part should be in Game
            if (Score == 21) //return 1
            {
                Console.WriteLine("\nYou have won!");
                return false;
            }
            
            return false;
        }
        
    }
}