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
        private readonly IDeck _deck;
        public BlackjackGame(IConsole console, IDeck deck)
        {
            _deck = deck; 
            _gameConsole = console;
            var player = new Player(_deck.DrawRandomCard(), _deck.DrawRandomCard(), _gameConsole);
            //_participants.Add(player);
            var dealer = new Dealer(_deck.DrawRandomCard(), _deck.DrawRandomCard(), _gameConsole);
            //_participants.Add(dealer);
            _participants = new List<IBlackjackParticipant>() { player, dealer };
        }
        
        //Call order (list) while IPlayer.Play should play in and record the scores
        //while HasNotFinished playing - once played evaluate score to determine winner
        //_participants.Where(p=>p.Play(deck)==true). ********* Game order/methods
        private List<IBlackjackParticipant> FindTheWinner()
        {
            var winner = _participants[0];
            var winners = new List<IBlackjackParticipant>();
            var participantsWhoAreNotBust = new List<IBlackjackParticipant>().Where(m => m.Score <= 21);
            
            foreach (var participant in participantsWhoAreNotBust)
            {
                if (participant.Score > winner.Score || participant.Score == 21)
                {
                    winners.Add(participant);
                }
            }
            return winners;
        }
        
        public void Run()
        {
            // player(s) before dealer .PLAY - sort for player index zero??
            /*
            for (int i = 0; i < _participants.Count; i++)
            {
                _participants[i].Play(_deck);
            }
            */
            
            foreach (var particiant in _participants)
            {
                particiant.Play(_deck);
            }
            
            FindTheWinner();
            Console.WriteLine("AHHHHHHHHHHHHHHHHHHHHHH"+ FindTheWinner()[0]);
        }
    }
}