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
        private readonly Dictionary<string, int> _participantsWinningStatistics;

        public BlackjackGame(IConsole console, IDeck deck)
        {
            _deck = deck; 
            _gameConsole = console;
            var player = new Player(_deck.DrawRandomCard(), _deck.DrawRandomCard(), _gameConsole, "Jo");
            var dealer = new Dealer(_deck.DrawRandomCard(), _deck.DrawRandomCard(), _gameConsole, "Dealer");
            _participants = new List<IBlackjackParticipant>() {player, dealer};
            _participantsWinningStatistics = new Dictionary<string, int>()
            {
                {player.Name, 0},
                {dealer.Name, 0},
                {"Tie", 0}
            };
        }

        private List<IBlackjackParticipant> ParticipantsOrderedByScore()
        {
            var orderedParticipants = _participants.Where(m => m.Score <= 21).OrderByDescending(m=>m.Score).ToList();
            return orderedParticipants;
        }

        private string DetermineHighestScorers(List<IBlackjackParticipant> orderedParticipant, IBlackjackParticipant highestScoringPlayer)
        {
            var highestScorer = orderedParticipant.Where(m => m.Score == highestScoringPlayer.Score).ToList();
            var outcome = "";  
            
            if (highestScorer.Count > 1)
            {
                _gameConsole.WriteLine("\nIt's a tie!");
                outcome = "Tie";
            }
                
            if (highestScorer.Count <= 1 && highestScoringPlayer.GetType() == typeof(Player))
            {
                _gameConsole.WriteLine("\nPlayer has beat the dealer!");
                outcome = highestScoringPlayer.Name;
            }

            else if (highestScoringPlayer.GetType() == typeof(Dealer))
            {
                _gameConsole.WriteLine("\nDealer wins!");
                outcome = highestScoringPlayer.Name;
            }
            return outcome;
        }
        
        private string FindTheWinner()
        {
            var orderedParticipant = ParticipantsOrderedByScore();
            var highestScoringPlayer = orderedParticipant.FirstOrDefault();
            var winner = "";
            if (highestScoringPlayer != null)
            {
                winner = DetermineHighestScorers(orderedParticipant, highestScoringPlayer);
            }
            return winner;
        }

        private void KeepTrackOfWins(string winnersName)
        {
            _participantsWinningStatistics[winnersName] += 1;
        }

        public void SummaryOfStatistics()
        {
            foreach (var participant in _participantsWinningStatistics)
            {
                if (participant.Key == "Tie")
                {
                    _gameConsole.WriteLine($"{participant.Key} has occured {participant.Value} time"+(participant.Value > 1 ? "s": "")); 
                }
                else if (participant.Key != "Tie")
                {
                    _gameConsole.WriteLine($"{participant.Key} has a win count of {participant.Value}");
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
            var outcome = FindTheWinner();
            KeepTrackOfWins(outcome);
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
            SummaryOfStatistics();
            _gameConsole.WriteLine("Thank you for playing\nGoodbye!");
            return false;
        }
    }
}