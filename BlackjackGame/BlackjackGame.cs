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
            var dealer = new Dealer(_deck.DrawRandomCard(), _deck.DrawRandomCard(), _gameConsole, "Dealer");
            _participants = new List<IBlackjackParticipant>() {player, dealer};
        }
        
        private void FindTheWinner() 
        {
            var orderedScored = _participants.Where(m => m.Score <= 21).OrderByDescending(m=>m.Score).ToList();
            var highestScoringPlayer = orderedScored.FirstOrDefault(); 
            if (highestScoringPlayer != null)
            {
                var tie = orderedScored.Where(m => m.Score == highestScoringPlayer.Score).ToList();
                
                if (tie.Count > 1)
                {
                    _gameConsole.WriteLine("\nIt's a tie!");
                }
                
                if (highestScoringPlayer.GetType() == typeof(Player))
                {
                    _gameConsole.WriteLine("\nPlayer has beat the dealer!");
                }

                _gameConsole.WriteLine("\nDealer wins!");
                
            }
        }

        public void Run()
        {
            foreach (var participant in _participants)
            {
                participant.Play(_deck);
            }
            FindTheWinner();
        }
    }
}