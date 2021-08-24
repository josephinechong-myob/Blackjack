using System;
using System.Collections.Generic;

namespace Blackjack
{
    public class Player:IBlackjackParticipant
    {
        //declare playershand and deck as fields of the class
        //deck should be shared player and dealer - 
       
        public Hand Hand;

        public Player(Card firstCard, Card secondCard)
        {
            Hand = new Hand(firstCard, secondCard);
        }
        //Player, Dealer and Game class
        /*
        private string HitOrStay(List<Card> playersHand, List<Card> deckOfCards)
        {
            Console.WriteLine("Hit or stay? (Hit = 1, Stay = 0)");
           
            var turn = Console.ReadLine();
            var deck = new Deck();

            if (turn == "1")
            {
                playersHand.Add(deck.DrawRandomCard(deckOfCards));
                var cardLength = playersHand.Count;
                Console.WriteLine($"You draw [ {playersHand[cardLength-1]} ]");
                Console.WriteLine($"Your updated total hand is [ {SumOfCards(playersHand.ToArray())} ]");
            }
            return turn;
        }*/
        
        /*private void Hit()
        {
            playersHand.Add(deck.DrawRandomCard(deckOfCards));
            var cardLength = playersHand.Count;
            Console.WriteLine($"You draw [ {playersHand[cardLength-1]} ]");
            Console.WriteLine($"Your updated total hand is [ {SumOfCards(playersHand.ToArray())} ]");
        }*/
        public string HitOrStay()
        {
            Console.WriteLine("Hit or stay? (Hit = 1, Stay = 0)");

            while (true)
            {
                var answer = Console.ReadLine();
                if (answer == "1") return "hit";
                if (answer == "0") return "stay";
                Console.WriteLine("Please enter a valid value");
                
                //conditions for exiting loop
                //over 21
                //if they choose to stay
            }
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
                return true;
            }
            return false;
        }
        public void Play(Deck deck)
        {
            bool PlayerHasChosenToStay = false;
            
            
            while (!PlayerHasChosenToStay)
            {
                var score = HandEvaluator.GetTotal(Hand);
                HandEvaluator.PrintHand(Hand);
                
                Console.WriteLine("Hit or stay? (Hit = 1, Stay = 0)");
                
                
                
                var answer = Console.ReadLine();
                
                if (answer == "1" && score < 21) Hit(deck);
                
                if (score == 21)
                {
                    Console.WriteLine("You have won");
                    PlayerHasChosenToStay = true;
                }

                /*if (score > 21)
                {
                    Console.WriteLine("You have gone bust");
                    PlayerHasChosenToStay = true;
                }*/
                
                else if (answer == "0" || score > 21) PlayerHasChosenToStay = true;
                
                else Console.WriteLine("Please enter a valid value");
                
                //conditon for bust over 21 and end loop
            }
        }

        public List<Card> InitalHand()
        {
            var deck = new Deck();
            var playersHand = deck.Cards;
            {
                deck.DrawRandomCard();
            }
            playersHand.Add(deck.DrawRandomCard());

            return playersHand;
        }
    }
}