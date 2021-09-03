using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Blackjack
{
    public class BlackjackGame
    {
        private List<IBlackjackParticipant> _participants;

        private IConsole _gameConsole;

        public BlackjackGame(IConsole console)
        {
            _participants = new List<IBlackjackParticipant>();
            var deck = new Deck();
            _gameConsole = console;
            var dealer = new Dealer(deck.DrawRandomCard(), deck.DrawRandomCard(), _gameConsole);
            _participants.Add(dealer);
        }
        
        //Call order (list) while IPlayer.Play should play in and record the scores
        
        //return 0 or 1 for play method (possible to make them enums)?
        
        //while HasNotFinished playing - once played evaluate score to determine winner
        
        //_participants.Where(p=>p.Play(deck)==true). ********* Game order/methods
        

        private IBlackjackParticipant FindTheWinner()
        {
            var winner = _participants[0];
            foreach (var participant in _participants)
            {
                if (participant.Score > winner.Score && participant.Score <= 21)
                {
                    winner = participant; //winner could be a list if there are more than 1 winners
                }
            }

            return winner;
        }
        
        public void Run()
        {
            var deck = new Deck();
            var firstCard = deck.DrawRandomCard();
            var secondCard = deck.DrawRandomCard();
           // var player = new Player(firstCard, secondCard, );
            
           // player.Play(deck);
        }
    }
}