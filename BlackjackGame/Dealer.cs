using System;
using System.Collections.Generic;
using System.Xml;

namespace Blackjack
{
    public class Dealer
    {
        public Hand Hand;

        public Dealer(Card firstCard, Card secondCard)
        {
            Hand = new Hand(firstCard, secondCard);
        }
        /*
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
            var dealer = new Dealer();
            var dealershand = deck.Cards;
            {
                deck.DrawRandomCard();
            }
            dealershand.Add(deck.DrawRandomCard());
            var sumOfDealersHand = hand.SumOfCards(dealershand);

            while (sumOfDealersHand < 21)
            {
                dealer.PrintDealersHand(dealershand);
                dealershand.Add(deck.DrawRandomCard());
                sumOfDealersHand = hand.SumOfCards(dealershand);
            }

            return dealershand;
        }
        */
    }
}