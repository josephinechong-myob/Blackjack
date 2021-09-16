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
            //scoring for several games

        public BlackjackGame(IConsole console, IDeck deck)
        {
            _deck = deck; 
            _gameConsole = console;
            var player = new Player(_deck.DrawRandomCard(), _deck.DrawRandomCard(), _gameConsole, "Jo");
            var dealer = new Dealer(_deck.DrawRandomCard(), _deck.DrawRandomCard(), _gameConsole, "Dealer");
            _participants = new List<IBlackjackParticipant>() {player, dealer};
            _RecordOfWins = new List<string>();
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

        private void KeepTrackOfWins() //dictionary - write test
        {
            var winnersName = FindTheWinner();
            _RecordOfWins.Add(winnersName);
            
            var count = _RecordOfWins.Count(s => s != null && s.Equals(winnersName));
            
            var dictionary = new Dictionary<string, int>();
            dictionary.Add(winnersName, count);
            
            foreach( string name in dictionary )
            {
                Console.WriteLine("Key = {0}", name);
            }

            //(Dealer, Jo, Dealer, Dealer) - Dealer wins 3 times, Jo wins 1 time
            foreach(var winner in _RecordOfWins)
            {
                if(winner == "Dealer")
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