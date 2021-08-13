using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Blackjack
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
            var testcard = new Card("2", "Diamond");
            foreach (var card in playerHand2)
            {
                if (card.Rank != "Ace")
                {
                    nonAceCardsTotal += testcard.GetValue();
                }
            }

            return nonAceCardsTotal;
        }

        public int SumOfCards(params Card[] playerHand)
        {
           // return cards.Value + cards.Value;
           var total = NonAceCards(playerHand);
            foreach (var card in playerHand)
            {
                if (card.Rank == "Ace" && total <= 10)
                {
                    total += 11;
                }
                else if (card.Rank == "Ace" && total > 10)
                {
                    total += 1;
                }
            }
            return total;
        }

        private int SumOfCards(List<Card> playerHand)
        {
           return SumOfCards(playerHand.ToArray());
           //var sum = SumOfCards(playerHand.ToArray());
          // return sum;
        }
        //method overloading^ (multiple meaning to same method name
        private void PrintPlayersHand(List<Card> playersHand)
        {
            Console.WriteLine($"You are currently at {SumOfCards(playersHand.ToArray())}");
           // playersHand.Count
                //l
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
            var deckOfCards = new List<Card>
            {
                new Card("Ace", "Spade"),
                new Card("2", "Spade"),
                new Card("3", "Spade"),
                new Card("4", "Spade"),
                new Card("5", "Spade"),
                new Card("6", "Spade"),
                new Card("7", "Spade"),
                new Card("8", "Spade"),
                new Card("9", "Spade"),
                new Card("10", "Spade"),
                new Card("Jack", "Spade"),
                new Card("Queen", "Spade"),
                new Card("King", "Spade"),
                new Card("Ace", "Diamond"),
                new Card("2", "Diamond"),
                new Card("3", "Diamond"),
                new Card("4", "Diamond"),
                new Card("5", "Diamond"),
                new Card("6", "Diamond"),
                new Card("7", "Diamond"),
                new Card("8", "Diamond"),
                new Card("9", "Diamond"),
                new Card("10", "Diamond"),
                new Card("Jack", "Diamond"),
                new Card("Queen", "Diamond"),
                new Card("King", "Diamond"),
                new Card("Ace", "Hearts"),
                new Card("2", "Hearts"),
                new Card("3", "Hearts"),
                new Card("4", "Hearts"),
                new Card("5", "Hearts"),
                new Card("6", "Hearts"),
                new Card("7", "Hearts"),
                new Card("8", "Hearts"),
                new Card("9", "Hearts"),
                new Card("10", "Hearts"),
                new Card("Jack", "Hearts"),
                new Card("Queen", "Hearts"),
                new Card("King", "Hearts"),
                new Card("Ace", "Clubs"),
                new Card("2", "Clubs"),
                new Card("3", "Clubs"),
                new Card("4", "Clubs"),
                new Card("5", "Clubs"),
                new Card("6", "Clubs"),
                new Card("7", "Clubs"),
                new Card("8", "Clubs"),
                new Card("9", "Clubs"),
                new Card("10", "Clubs"),
                new Card("Jack", "Clubs"),
                new Card("Queen", "Clubs"),
                new Card("King", "Clubs"),
            };

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
            //dealers hand
            
            //extracting the while loop from run method
            
            
            //TIPS:
            //exit with control C
            //option + enter for more options
            //command shift P (command palette) press shift twice
            
            //SMALL to do's:
            //test - DONE
            //method for test sum of cards - go through test methods (X-unit) - DONE
            //For deciding in Ace is 1 or 11 - DONE
            //show sum of cards then exit - DONE
            //gives 2 cards (object for deck of cards) - single deck remove cards - and exit - DONE
            //add a king to the deck and show the correct sum when you draw a king - DONE
            //add an ace to the the deck and show the correct sum when you draw an ace (1 or 11) - DONE
            //Ask the player if they want to hit or stay and print their option then exit - DONE
            //Storing the cards drawn from player (2 cards + 1 draw) - DONE
            //test the game as a whole might be too complex (esp if cards are drawn at random) - test for incorrect input
            //loop for player or 21?
            //Edge cases for Blackjack
            
            //Console.WriteLine(turn); 
        }
    }
/*
    public class Card
    {
        public string Rank { get; }
        //private int Value { get; }
        public string Suit { get; }

        public Card(string rank, string suit)
        {
            Rank = rank;
           // Value = value;
            Suit = suit;
        }

        public int GetValue()
        {
            //return Value;
            if (Rank != "Ace" && Rank == "Jack" || Rank != "Ace" && Rank == "Queen" || Rank != "Ace" && Rank == "King")
            {
                return 10;
            }
            else if (Rank == "Ace")
            {
                throw new InvalidOperationException("Please don't call value on Ace");
            }
            return Convert.ToInt32(Rank);
        }

        public override string ToString()
        {
            return $"'{Rank}' '{Suit}'";
        }
        
    }*/
}