using System.Collections.Generic;
using System.Linq;

namespace Blackjack
{
    public class BlackjackGame
    {
        private readonly List<IBlackjackParticipant> _participants;
        private readonly IConsole _gameConsole;
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

                else if (highestScoringPlayer.GetType() == typeof(Dealer))
                {
                    _gameConsole.WriteLine("\nDealer wins!"); 
                }
            }
        }

        public void Run()
        {
            var aParticipantHasBust = false;

            for (int i = 0; i < _participants.Count && !aParticipantHasBust; i++)
            {
                _participants[i].Play(_deck);
                if (_participants[i].Score > 21)
                {
                    aParticipantHasBust = true;
                }
            }
            FindTheWinner();
        }
    }
}