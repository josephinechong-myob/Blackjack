using System;
using System.Linq;
using System.Reflection.Metadata;
using Blackjack;
using Xunit;

namespace BlackjackTest
{
    public class HandTest
    {
        //Adding a card to the Hand
        [Fact]
        public void HandShouldIncreaseAfterAddingACard()
        {
            //arrange
            var expectedCountOfHandCards = 3;
            var expectedFirstCard = new Card(Rank.Ten, Suit.Club);
            var expectedSecondCard = new Card(Rank.Jack, Suit.Club);
            var expectedThridCard = new Card(Rank.Ace, Suit.Club);
            var hand = new Hand(expectedFirstCard, expectedSecondCard);

            //act
            hand.AddCardToHand(expectedThridCard);

            //assert
            Assert.True(hand.Cards.Contains(expectedThridCard));
            Assert.Equal(expectedCountOfHandCards, hand.Cards.Count);
        }
        
        [Fact]
        public void HandShouldSortCards()
        {
            //arrange
            var expectedFirstCard = new Card(Rank.Ten, Suit.Club);
            var expectedSecondCard = new Card(Rank.Jack, Suit.Club);
            var expectedThridCard = new Card(Rank.Ace, Suit.Club);
            var hand = new Hand(expectedFirstCard, expectedThridCard);

            //act
            hand.AddCardToHand(expectedSecondCard);
            hand.SortHand();

            //assert
            Assert.Equal(expectedThridCard, hand.Cards.Last());
        }

        [Fact]
        public void NewHandShouldHaveTwoCards()
        {
            //arrange
            var expectedCountOfHandCards = 2;
            var firstCard = new Card(Rank.Ace, Suit.Club);
            var secondCard = new Card(Rank.Eight, Suit.Diamond);
            var hand = new Hand(firstCard, secondCard);
            
            //act
            var actualCountOfHandCards = hand.Cards.Count;
            
            //assert
            Assert.Equal(expectedCountOfHandCards, actualCountOfHandCards);
        }
        
        [Fact]
        public void PlayersHandTest()
        {
            //arrange
            var firstCard = new Card(Rank.Ace, Suit.Club);
            var secondCard = new Card(Rank.Eight, Suit.Diamond);
            var hand = new Hand(firstCard, secondCard);
            
            //act
            var result = hand.CalculateSumOfAllCards();
            
            //assert
            Assert.Equal(19,result);
        }
        
        [Fact]
        public void PlayersHandWithKingTest()
        {
            //arrange
            var firstCard = new Card(Rank.King, Suit.Club);
            var secondCard = new Card(Rank.Eight, Suit.Diamond);
            var hand = new Hand(firstCard, secondCard);
            
            //act
            var result = hand.CalculateSumOfAllCards();
            
            //assert
            Assert.Equal(18, result);
        }
        
        [Fact]
        public void PlayersHandWithQueenTest()
        {
            //arrange
            var firstCard = new Card(Rank.Queen, Suit.Club);
            var secondCard = new Card(Rank.Eight, Suit.Diamond);
            var hand = new Hand(firstCard, secondCard);
            
            //act
            var result = hand.CalculateSumOfAllCards();
            
            //assert
            Assert.Equal(18, result);
        }
        
        [Fact]
        public void PlayersHandWithJackTest()
        {
            //arrange
            var firstCard = new Card(Rank.Jack, Suit.Club);
            var secondCard = new Card(Rank.Eight, Suit.Diamond);
            var hand = new Hand(firstCard, secondCard);
            
            //act
            var result = hand.CalculateSumOfAllCards();
            
            //assert
            Assert.Equal(18, result);
        }
        
        [Fact]
        public void PlayersHandWithAceTest()
        {
            //arrange
            var firstCard = new Card(Rank.Ace, Suit.Club);
            var secondCard = new Card(Rank.Eight, Suit.Diamond);
            var hand = new Hand(firstCard, secondCard);
            
            //act
            var result = hand.CalculateSumOfAllCards();
            
            //assert
            Assert.Equal(19, result);
        }
        
        [Fact]
        public void PlayersHandWithAceTest2()
        {
            //arrange
            var firstCard = new Card(Rank.Ace, Suit.Club);
            var secondCard = new Card(Rank.Ace, Suit.Diamond);
            var hand = new Hand(firstCard, secondCard);
            
            //act
            var result = hand.CalculateSumOfAllCards();
            
            //assert
            Assert.Equal(12, result);
        }
        
        [Fact]
        public void PlayersHandWithAceTest3()
        {
            //arrange
            var firstCard = new Card(Rank.Ace, Suit.Club);
            var secondCard = new Card(Rank.King, Suit.Diamond);
            var hand = new Hand(firstCard, secondCard);
            
            //act
            var result = hand.CalculateSumOfAllCards();
            
            //assert
            Assert.Equal(21, result);
        }
        
        [Fact]
        public void CardShouldPrintTwoDiamond()
        {
            //arrange
            var card = new Card(Rank.Two, Suit.Diamond);
            
            //act
            var result = card.ToString();
            var expected = "Two of Diamond";
            
            //assert
            Assert.Equal(expected, result);
        }
    }
}