using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Blackjack
{
    public class BlackjackGame
    {
        public void Run()
        {
            var deck = new Deck();
            var player = new Player(deck);
            var dealer = new Dealer();
            var hand = new Hand(deck);
            var playersHand = player.InitalHand();
            var turn = "1";
            var sum = hand.SumOfCards(playersHand);
            
            while (sum < 21 && turn == "1")
            {
                player.PrintPlayersHand(playersHand);
                turn = player.HitOrStay(sum);
                sum = hand.SumOfCards(playersHand);
                
                var handEvaluator = new HandEvaluator();
                Console.WriteLine(handEvaluator.WinCondition1(sum));
            }
            
            dealer.DealersTurn();
        }
    }
}