using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Blackjack
{
    public class BlackjackGame
    {
        private List<IBlackjackParticipant> _participants;
        //have deck here? where to have deck

        public BlackjackGame()
        {
            _participants = new List<IBlackjackParticipant>();
        }
        
        //Call order (list) while IPlayer.Play should play in and record the scores
        
        //return 0 or 1 for play method (possible to make them enums)?
        
        //while HasNotFinished playing - once played evaluate score to determine winner
        
        //Methods: Find the winner(player) - private or public method 
        
        //participants - score/hand
       // foreach (var participant in _participants)
       //var deck //have access to deck or hand
        //_participants.Where(p=>p.Play(deck)==true). ********* Game order/methods
        //if play or deck is true 
        //or false the next player has to play

        private void FindTheWinner() //find the winner
        {
            
        }
        
        public void Run()
        {
            //Player - Stay (not bust)
            // foreach player in list if player.play = false, next player on list goes - loop
            //after all participants have played - score can be evaluated
            
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