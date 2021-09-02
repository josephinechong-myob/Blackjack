using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Blackjack
{
    public class BlackjackGame
    {
        private List<IBlackjackParticipant> Participants;

        public BlackjackGame()
        {
            Participants = new List<IBlackjackParticipant>();
        }
        
        //Call order (list) while IPlayer.Play should play in and record the scores
        
        //return 0 or 1 for play method (possible to make them enums)?
        
        //while HasNotFinished playing - once played evaluate score to determine winner
        
        //Methods: Find the winner(player) - private or public method 

        private void FindTheWinner()
        {
            
        }
        
        public void Run()
        {
            //Player - Stay (not bust)
            //Dealer - Result
            //Outcome - Evalute who won
            
            var deck = new Deck();
            var firstCard = deck.DrawRandomCard();
            var secondCard = deck.DrawRandomCard();
           // var player = new Player(firstCard, secondCard, );
            
           // player.Play(deck);
        }
    }
}