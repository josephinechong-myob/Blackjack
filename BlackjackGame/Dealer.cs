using System;
using System.Collections.Generic;
using System.Xml;

namespace Blackjack
{
    public class Dealer: IBlackjackParticipant
    {
        public Hand Hand;
        public Deck Deck;

        public Dealer(Card firstCard, Card secondCard, Deck deck)
        {
            Hand = new Hand(firstCard, secondCard);
            Deck = new Deck();
        }
        
        public void HitUntilTotalIsAtLeastSeventeen(Card card)
        {
            var dealersHandTotal = HandEvaluator.GetTotal(Hand);
            
            while (dealersHandTotal <= 17)
            {
                HandEvaluator.PrintHand(Hand);
                Hand.AddCardToHand(card);
            }
            /*
              playersHand.Add(deck.DrawRandomCard(deckOfCards));
            var cardLength = playersHand.Count;
            Console.WriteLine($"You draw [ {playersHand[cardLength-1]} ]");
            Console.WriteLine($"Your updated total hand is [ {SumOfCards(playersHand.ToArray())} ]");
             */

        }
        
        public void Hit(Deck deck)
        {
            //adding a card from deck to hand
        }
        
        public void Play(Deck deck)
        {
            
        }
        
        public void ResetGame(Deck deck)
        {
            
        }
        /*
     
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