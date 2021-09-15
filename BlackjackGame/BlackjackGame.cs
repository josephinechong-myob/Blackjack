using System;
using System.Collections.Generic;
using System.Linq;
using Blackjack.Cards;

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

        private List<IBlackjackParticipant> ParticipantsOrderedByScore()
        {
            var orderedParticipants = _participants.Where(m => m.Score <= 21).OrderByDescending(m=>m.Score).ToList();
            return orderedParticipants;
        }

        private void DetermineHighestScorers(List<IBlackjackParticipant> orderedParticipant, IBlackjackParticipant highestScoringPlayer)
        {
            var highestScorer = orderedParticipant.Where(m => m.Score == highestScoringPlayer.Score).ToList();
                
            if (highestScorer.Count > 1)
            {
                _gameConsole.WriteLine("\nIt's a tie!");
            }
                
            if (highestScorer.Count <= 1 && highestScoringPlayer.GetType() == typeof(Player))
            {
                _gameConsole.WriteLine("\nPlayer has beat the dealer!");
            }

            else if (highestScoringPlayer.GetType() == typeof(Dealer))
            {
                _gameConsole.WriteLine("\nDealer wins!"); 
            }
        }
        
        private void FindTheWinner()
        {
            var orderedParticipant = ParticipantsOrderedByScore();
            var highestScoringPlayer = orderedParticipant.FirstOrDefault(); 
            if (highestScoringPlayer != null)
            {
                DetermineHighestScorers(orderedParticipant, highestScoringPlayer);
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

        public void Reset()
        {
            _deck.ResetDeck();
            _gameConsole.WriteLine("Let's play again");
            foreach (var participant in _participants)
            {
                participant.Hand.ClearHand();
                participant.Hand.ResetHand(_deck.DrawRandomCard(), _deck.DrawRandomCard());
            }
        }
        
        public bool DoesUserWantToContinueGame()
        {
            _gameConsole.WriteLine("Do you want to play blackjack again? (Yes = 1, No = 0)");
            var input = _gameConsole.ReadLine();
            if (input == "1")
            {
                return true;
            }
            _gameConsole.WriteLine("Thank you and goodbye!");
            return false;
        }
    }
}