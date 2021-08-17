using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlackjackGame
{
    public class Blackjack
    {
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
        }
        */
        
        public void Run()
        {
            var deck = new Deck();
            var deckOfCards = deck.RecordOfCards();
            
            var player = new Player();
            var playersHand = player.InitalHand();

            var hand = new Hand();
            
            //Game class
            var turn = "1";
            var sum = hand.SumOfCards(playersHand);
            
            while (sum < 21 && turn == "1")
            {
                player.PrintPlayersHand(playersHand);
                turn = player.HitOrStay(playersHand, deckOfCards);
                sum = hand.SumOfCards(playersHand);
                //Hand Evaluator class
                if (sum == 21)
                {
                    Console.WriteLine("You have hit 21 and win the game!");
                }
            }
            
            var dealer = new Dealer();
            dealer.DealersTurn();
        }
    }
}