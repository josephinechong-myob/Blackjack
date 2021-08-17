using System;
using System.Collections.Generic;

namespace BlackjackGame
{
    public class Dealer
    {
        public void PrintDealersHand(List<Card> dealersHand)
        {
            var hand = new Hand();
            Console.WriteLine($"Dealer is at {hand.SumOfCards(dealersHand.ToArray())}");
            Console.Write($"with the hand ");
            foreach (var card in dealersHand)
            {
                Console.Write(($"[{card}]"));
            }
        }

        public List<Card> DealersTurn()
        {
            var deck = new Deck();
            var hand = new Hand();
            var deckOfCards = deck.RecordOfCards();
            var dealer = new Dealer();
            var dealershand = new List<Card>()
            {
                deck.DrawRandomCard(deckOfCards)
            };
            dealershand.Add(deck.DrawRandomCard(deckOfCards));
            var sumOfDealersHand = hand.SumOfCards(dealershand);

            while (sumOfDealersHand < 21)
            {
                dealer.PrintDealersHand(dealershand);
                dealershand.Add(deck.DrawRandomCard(deckOfCards));
                sumOfDealersHand = hand.SumOfCards(dealershand);
            }

            return dealershand;
        }
    }
}