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
        private List<string> _RecordOfWins;
        private List<int> _RecordOfTies;

        public BlackjackGame(IConsole console, IDeck deck)
        {
            _deck = deck; 
            _gameConsole = console;
            var player = new Player(_deck.DrawRandomCard(), _deck.DrawRandomCard(), _gameConsole, "Jo");
            var dealer = new Dealer(_deck.DrawRandomCard(), _deck.DrawRandomCard(), _gameConsole, "Dealer");
            _participants = new List<IBlackjackParticipant>() {player, dealer};
            _RecordOfWins = new List<string>();
            _RecordOfTies = new List<int>();
        }

        private List<IBlackjackParticipant> ParticipantsOrderedByScore()
        {
            var orderedParticipants = _participants.Where(m => m.Score <= 21).OrderByDescending(m=>m.Score).ToList();
            return orderedParticipants;
        }

        private string DetermineHighestScorers(List<IBlackjackParticipant> orderedParticipant, IBlackjackParticipant highestScoringPlayer)
        {
            var highestScorer = orderedParticipant.Where(m => m.Score == highestScoringPlayer.Score).ToList();
            var winnerName = "";  
            
            if (highestScorer.Count > 1)
            {
                _gameConsole.WriteLine("\nIt's a tie!");
                _RecordOfTies.Add(1);
                winnerName = "tie";
            }
                
            if (highestScorer.Count <= 1 && highestScoringPlayer.GetType() == typeof(Player))
            {
                _gameConsole.WriteLine("\nPlayer has beat the dealer!");
                winnerName = highestScoringPlayer.Name;
            }

            else if (highestScoringPlayer.GetType() == typeof(Dealer))
            {
                _gameConsole.WriteLine("\nDealer wins!");
                winnerName = highestScoringPlayer.Name;
            }
            return winnerName;
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
            _RecordOfWins.Add(winnersName);
            var count = _RecordOfWins.Count(s => s != null && s.Equals(winnersName));
            var participants = new Dictionary<string, int>();
            participants.Add(winnersName, count);

            if (winnersName == "tie")
            {
                var tieCount = _RecordOfTies.Count;
                _gameConsole.WriteLine($"There has been {tieCount} ties");
            }
            else if (winnersName != "tie" && _RecordOfWins.Count > 1)
            {
                var loser = _RecordOfWins.Find(s => s != null && s != winnersName);
                var loserCount = _RecordOfWins.Count(s => s != null && s != winnersName);
                if (loser != null)
                {
                    participants.Add(loser, loserCount);
                }
            }
            foreach (var participant in participants)
            {
                _gameConsole.WriteLine($"{participant.Key} has a win Count of {participant.Value}");
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
            var winner = FindTheWinner();
            KeepTrackOfWins(winner);
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
            _gameConsole.WriteLine("Thank you for playing\nGoodbye!");
            return false;
        }
    }
}