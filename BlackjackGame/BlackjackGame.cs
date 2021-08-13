using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlackjackGame
{
    public class Blackjack
    {
        private Card DrawRandomCard(List<Card> deckOfCards)
        {
            Random rnd = new Random();
            var cardInterval = rnd.Next(deckOfCards.Count);
            return deckOfCards[cardInterval];
        }
        
        private int NonAceCards(params Card[] playerHand2)
        {
            var nonAceCardsTotal = 0;
            foreach (var card in playerHand2)
            {
                if (card.Rank != Rank.Ace)
                {
                    nonAceCardsTotal += card.GetValue();
                }
            }

            return nonAceCardsTotal;
        }

        public int SumOfCards(params Card[] playerHand)
        {
            var total = NonAceCards(playerHand);
            foreach (var card in playerHand)
            {
                if (card.Rank == Rank.Ace && total <= 10)
                {
                    total += 11;
                }
                else if (card.Rank == Rank.Ace && total > 10)
                {
                    total += 1;
                }
            }
            return total;
        }
        private int SumOfCards(List<Card> playerHand)
        {
           return SumOfCards(playerHand.ToArray());
        }
        
        private void PrintPlayersHand(List<Card> playersHand)
        {
            Console.WriteLine($"You are currently at {SumOfCards(playersHand.ToArray())}");
            Console.Write($"with the hand ");
            foreach (var card in playersHand)
            {
                Console.Write($"[{card}]");
            }
            Console.WriteLine();
        }

        private string HitOrStay(List<Card> playersHand, List<Card> deckOfCards)
        {
            Console.WriteLine("Hit or stay? (Hit = 1, Stay = 0)");
           
            var turn = Console.ReadLine();

            if (turn == "1")
            {
                playersHand.Add(DrawRandomCard(deckOfCards));
                var cardLength = playersHand.Count;
                Console.WriteLine($"You draw [ {playersHand[cardLength-1]} ]");
                Console.WriteLine($"Your updated total hand is [ {SumOfCards(playersHand.ToArray())} ]");
            }
            return turn;
        }
        
        public void Run()
        {
            var suitCount = 4;
            var deckOfCards = new List<Card>{};

            for (int i = 0; i < suitCount; i += 1)
            {
                deckOfCards.Add(new Card(Rank.Ace,(Suit)i));
                deckOfCards.Add(new Card(Rank.Two, (Suit)i));
                deckOfCards.Add(new Card(Rank.Three,(Suit)i));
                deckOfCards.Add(new Card(Rank.Four, (Suit)i));
                deckOfCards.Add(new Card(Rank.Five,(Suit)i));
                deckOfCards.Add(new Card(Rank.Six, (Suit)i));
                deckOfCards.Add(new Card(Rank.Seven,(Suit)i));
                deckOfCards.Add(new Card(Rank.Eight, (Suit)i));
                deckOfCards.Add(new Card(Rank.Nine,(Suit)i));
                deckOfCards.Add(new Card(Rank.Ten, (Suit)i));
                deckOfCards.Add(new Card(Rank.Jack,(Suit)i));
                deckOfCards.Add(new Card(Rank.Queen, (Suit)i));
                deckOfCards.Add(new Card(Rank.King, (Suit)i));
            }
            
            var playersHand = new List<Card>()
            {
                DrawRandomCard(deckOfCards)
            };
            playersHand.Add(DrawRandomCard(deckOfCards));
            
            var turn = "1";
            var sum = SumOfCards(playersHand);
            
            while (sum < 21 && turn == "1")
            {
                PrintPlayersHand(playersHand);
                turn = HitOrStay(playersHand, deckOfCards);
                sum = SumOfCards(playersHand);
            }
        }
    }
}