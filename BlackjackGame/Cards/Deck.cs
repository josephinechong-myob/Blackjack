using System;
using System.Collections.Generic;

namespace Blackjack.Cards
{
    public class Deck : IDeck
    {
        public List<Card> Cards;
        public List<Card> DrawnCards;

        public Deck()
        {
            Cards = CreateInitialDeck();
            DrawnCards = new List<Card>();
        }
        
        public Card DrawRandomCard()
        {
            Random rnd = new Random();
            var cardIndex = rnd.Next(Cards.Count);
            var card = Cards[cardIndex];
            Cards.Remove(card);
            DrawnCards.Add(card);
            return card;
        }
        
        public Card AddCardToDeck()
        {
            Random rnd = new Random();
            var cardIndex = rnd.Next(Cards.Count);
            var card = Cards[cardIndex];
            Cards.Add(card);
            return card;
        }
        
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
        
        public void ResetDeck()
        {
            Cards = CreateInitialDeck();
            DrawnCards = new List<Card>();
        }
    }
}