using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlackjackGame
{
    public class Blackjack
    {
        public void Run()
        {
            var player = new Player();
            var dealer = new Dealer();
            var hand = new Hand();
            var playersHand = player.InitalHand();
            var turn = "1";
            var sum = hand.SumOfCards(playersHand);
            
            while (sum < 21 && turn == "1")
            {
                player.PrintPlayersHand(playersHand);
                turn = player.HitOrStay(score);
                sum = hand.SumOfCards(playersHand);
                
                var handEvaluator = new HandEvaluator();
                Console.WriteLine(handEvaluator.WinCondition1(sum));
            }
            
            dealer.DealersTurn();
        }
    }
}