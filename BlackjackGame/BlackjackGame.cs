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
            var player = new Player(_deck.DrawRandomCard(), _deck.DrawRandomCard(), _gameConsole, "Jo");
            var dealer = new Dealer(_deck.DrawRandomCard(), _deck.DrawRandomCard(), _gameConsole);
            _participants = new List<IBlackjackParticipant>() {player, dealer};
        }
        
        //Call order (list) while IPlayer.Play should play in and record the scores
        //while HasNotFinished playing - once played evaluate score to determine winner
        //_participants.Where(p=>p.Play(deck)==true). ********* Game order/methods
        private void FindTheWinner()
        {
            //following not a list - if the get type is dealer or player they win if they are on the top of the list
            //include the bust 
            var orderedScored = _participants.Where(m => m.Score < 21).OrderByDescending(m=>m.Score);
            var highestScoringPlayer = orderedScored.FirstOrDefault(); //first or firstOrDefault(better - wont' crash with empty list) methods look up
            
            //only state 
            //first or default ********
            
            //how to determine - first two ordered scores - have to be equal in score 
//get the score and order by desecnding
        }

        /*
        {
            var winner = _participants[0];
            var winners = new List<IBlackjackParticipant>();
            var participantsWhoAreNotBust = _participants.Where(m => m.Score <= 21);
            //if both dealer and player are score 20 or equal - write a test for this
            
            foreach (var participant in participantsWhoAreNotBust)
            {
                if (participant.Score > winner.Score || participant.Score == 21) //only for one dealer and one player 
                {
                    winners.Add(participant);
                }
            }
            return winners;
        }
        */
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
            
/*
            public byte sum(byte a, byte b)
            {
                byte c = (byte)(a + b); //coverting or casting - > bytes were automatically converted to int and issue was returning byte not int as C
                return c;
            }
            */
            
            var winners = FindTheWinner();
            //when the dealer wins 
            //when both players wins
            //code duplication 

            if (winners.Count == 1)
            {
               // var participant = winners[0];
                //((Player)participant).
                var winner = winners[0].GetType();
                if (winner == typeof(Player))
                {
                    _gameConsole.WriteLine("\nPlayer has beat the dealer!"); 
                }
                _gameConsole.WriteLine("\nDealer wins!");
            }
            else if (winners.Count > 1) //only for one dealer and one player 
            {
                _gameConsole.WriteLine("\nIt's a tie!"); 
            }
        }
    }
}