using System;
using System.Collections.Generic;

namespace BlackjackGame
{
    public class Deck
    {
        public List<Card> Cards;

        public Deck()
        {
            Cards = CreateInitialDeck();
        }
        //Provide random card
        public Card DrawRandomCard(List<Card> deckOfCards)
        {
            Random rnd = new Random();
            var cardInterval = rnd.Next(deckOfCards.Count);
            return deckOfCards[cardInterval];
        }
        
        //Record of cards
        private List<Card> CreateInitialDeck()
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

            return deckOfCards;
        }
        
        //Reset the deck with new game
    }
}