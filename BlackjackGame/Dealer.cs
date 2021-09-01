using System;
using System.Collections.Generic;
using System.Xml;

namespace Blackjack
{
    public class Dealer: IBlackjackParticipant
    {
        public Hand Hand;
        public int Score => HandEvaluator.GetTotal(Hand);

        public Dealer(Card firstCard, Card secondCard)
        {
            Hand = new Hand(firstCard, secondCard);
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
        
        public void Hit(IDeck deck)
        {
            //adding a card from deck to hand
        }
        
        public bool Play(IDeck deck)
        {/*
            bool DealerHasChosenToStay = false;
            
            while (!PlayerHasChosenToStay)
            {
                var score = HandEvaluator.GetTotal(Hand);
                HandEvaluator.PrintHand(Hand);
                if (score > 21)
                {
                    Console.WriteLine("\nYou have bust!");  
                    break;
                }
                Console.WriteLine("Hit or stay? (Hit = 1, Stay = 0)");  
                
                var answer = Console.ReadLine();
                
                if (answer == "0") PlayerHasChosenToStay = true;

                else if (score == 21)
                {
                    Console.WriteLine("You have won");
                    PlayerHasChosenToStay = true;
                }
                
                else if (answer == "1") Hit(deck);
                
                else Console.WriteLine("Please enter a valid value");
                
            }
            */
            return false;
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