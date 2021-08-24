using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Blackjack
{
    public class BlackjackGame
    {
        public void Run()
        {
            var deck = new Deck();
            var firstCard = deck.DrawRandomCard();
            var secondCard = deck.DrawRandomCard();
            var player = new Player(firstCard, secondCard);
            
            player.Play(deck);
            
            //var dealer = new Dealer();
            /*
            var hand = new Hand(deck);
            var playersHand = player.InitalHand();
            var turn = "1";
            var sum = hand.SumOfCards(playersHand);
            
            while (sum < 21 && turn == "1")
            {
                //player.PrintPlayersHand(playersHand);
                turn = player.HitOrStay(sum);
                sum = hand.SumOfCards(playersHand);
                
                var handEvaluator = new HandEvaluator();
                Console.WriteLine(handEvaluator.WinCondition1(sum));
            }
            
            dealer.DealersTurn();
            */
            /*public static string WinCondition1(int sum)
            {
                if (sum == 21) return "You have hit 21 and win the game!";
                if (sum > 21) return "You have gone bust";
                return "something";
            }
            */
        }
    }
}