using System;
using System.Reflection.Metadata;
using Blackjack;
using Xunit;

namespace BlackjackTest
{
    public class HandTest
    {
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
            Assert.Equal(9,result);
        }
        
        [Fact]
        public void PlayersHandWithKingTest()
        {
            //arrange
            var firstCard = new Card(Rank.Ace, Suit.Club);
            var secondCard = new Card(Rank.Eight, Suit.Diamond);
            var hand = new Hand(firstCard, secondCard);
            
            //act
            var result = hand.CalculateSumOfAllCards());
            
            //assert
            Assert.Equal(15, result);
        }
        
        [Fact]
        public void PlayersHandWithQueenTest()
        {
            //arrange
            var firstCard = new Card(Rank.Ace, Suit.Club);
            var secondCard = new Card(Rank.Eight, Suit.Diamond);
            var hand = new Hand(firstCard, secondCard);
            
            //act
            var result = hand.CalculateSumOfAllCards();
            
            //assert
            Assert.Equal(15, result);
        }
        
        [Fact]
        public void PlayersHandWithJackTest()
        {
            //arrange
            var firstCard = new Card(Rank.Ace, Suit.Club);
            var secondCard = new Card(Rank.Eight, Suit.Diamond);
            var hand = new Hand(firstCard, secondCard);
            
            //act
            var result = hand.CalculateSumOfAllCards();
            
            //assert
            Assert.Equal(15, result);
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
            Assert.Equal(16, result);
        }
        
        [Fact]
        public void PlayersHandWithAceTest2()
        {
            //arrange
            var firstCard = new Card(Rank.Ace, Suit.Club);
            var secondCard = new Card(Rank.Eight, Suit.Diamond);
            var hand = new Hand(firstCard, secondCard);
            
            //act
            var result = hand.CalculateSumOfAllCards();
            
            //assert
            Assert.Equal(16, result);
        }
        
        [Fact]
        public void PlayersHandWithAceTest3()
        {
            //arrange
            var firstCard = new Card(Rank.Ace, Suit.Club);
            var secondCard = new Card(Rank.Eight, Suit.Diamond);
            var hand = new Hand(firstCard, secondCard);
            
            //act
            var result = hand.CalculateSumOfAllCards();
            
            //assert
            Assert.Equal(16, result);
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