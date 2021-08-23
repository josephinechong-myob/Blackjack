using System;
using System.Collections.Generic;

namespace Blackjack
{
    public class Player:IBlackjackParticipant
    {
        //declare playershand and deck as fields of the class
        //deck should be shared player and dealer - 
        public Player(Deck deck)
        {
            //hand should be created here it should be passed two cards
        }
        
        
        /*
        public void PrintPlayersHand(List<Card> playersHand)
        {
            var hand = new Hand();
            Console.WriteLine($"You are currently at {hand.SumOfCards(playersHand.ToArray())}");
            Console.Write($"with the hand ");
            foreach (var card in playersHand)
            {
                Console.Write($"[{card}]");
            }
        }
        */
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
        public string HitOrStay(int score)
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

        public void Hit()
        {
            Console.WriteLine("Hit or stay? (Hit = 1, Stay = 0)");

            while (true)
            {
                var answer = Console.ReadLine();
                if (answer == "1") Console.WriteLine("hit");
                if (answer == "0") Console.WriteLine("stay");
                Console.WriteLine("Please enter a valid value");
            } 
        }

        public void Evaluate()
        {
            //what is total? 
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