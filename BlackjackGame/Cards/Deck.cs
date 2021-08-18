using System;
using System.Collections.Generic;

namespace Blackjack
{
    public class Deck
    {
        public List<Card> Cards;

        public Deck()
        {
            Cards = CreateInitialDeck();
        }
        
        //Drawing a random card
        public Card DrawRandomCard()
        {
            Random rnd = new Random();
            var cardIndex = rnd.Next(Cards.Count);
            var card = Cards[cardIndex];
            Cards.Remove(card);
            return card;
        }
        
        //Adding a card to the deck
        public Card AddingCardToDeck()
        {
            Random rnd = new Random();
            var cardIndex = rnd.Next(Cards.Count);
            var card = Cards[cardIndex];
            Cards.Add(card);
            return card;
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
        
        //Reset the deck
        public List<Card> ResetDeck()
        {
            Cards = CreateInitialDeck();
            return Cards;
        }
    }
}