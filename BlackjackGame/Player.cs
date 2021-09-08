using System;
using System.Collections.Generic;

namespace Blackjack
{
    public class Player:IBlackjackParticipant
    {
        private readonly Hand _hand;
        private readonly IConsole _console;
        public int Score => HandEvaluator.GetTotal(_hand);
        //private readonly string _name;
        public string Name { get; }

        public Player(Card firstCard, Card secondCard, IConsole console, string name)
        {
            _hand = new Hand(firstCard, secondCard, console);
            _console = console;
            Name = name;
            //_name = "You"; //can extend to asking player for their name in console for extentsion 
        }
        
        public void Hit(IDeck deck)
        {
            var drawnCard = deck.DrawRandomCard();
            _hand.AddCardToHand(drawnCard);
            _console.WriteLine($"\nYou draw {drawnCard}");
        }

        public bool IsThereABust(int score)
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
        public bool Play(IDeck deck) //return a value 0 or 1 OR record player has finished playing (public field HasPlayed)
        {
            while (!IsThereABust(Score) && !IsThereABlackjack(Score)) //separate methods for bust or win (not a bust && not a win), optional step a method over over the top which is play has ended
            {
                HandEvaluator.PrintHand(_hand, Name);
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
            return false;
        }
        
    }
}