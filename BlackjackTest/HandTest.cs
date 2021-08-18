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
            //Arrange
            var expectedCountOfHandCards = 2;
            var hand = new Hand();
            
            //Act
            var actualCountOfHandCards = hand.Cards.Count;
            
            //Assert
            Assert.Equal(expectedCountOfHandCards, actualCountOfHandCards);
        }
        
        [Fact]
        public void PlayersHandTest()
        {
            //arrange
            var hand = new Hand();
            
            //act
            var result = hand.SumOfCards(
                new Card(Rank.Four, Suit.Spade), 
                new Card(Rank.Five, Suit.Spade)
                );
            
            //assert
            Assert.Equal(9,result);
        }
        
        [Fact]
        public void PlayersHandWithKingTest()
        {
            //arrange
            var hand = new Hand();
            
            //act
            var result = hand.SumOfCards(
                new Card(Rank.King, Suit.Spade), 
                new Card(Rank.Five, Suit.Club)
                );
            
            //assert
            Assert.Equal(15, result);
        }
        
        [Fact]
        public void PlayersHandWithQueenTest()
        {
            //arrange
            var hand = new Hand();
            
            //act
            var result = hand.SumOfCards(
                new Card(Rank.Queen, Suit.Spade), 
                new Card(Rank.Five, Suit.Club)
            );
            
            //assert
            Assert.Equal(15, result);
        }
        
        [Fact]
        public void PlayersHandWithJackTest()
        {
            //arrange
            var hand = new Hand();
            
            //act
            var result = hand.SumOfCards(
                new Card(Rank.Jack, Suit.Spade), 
                new Card(Rank.Five, Suit.Club)
            );
            
            //assert
            Assert.Equal(15, result);
        }
        
        [Fact]
        public void PlayersHandWithAceTest()
        {
            //arrange
            var hand = new Hand();
            
            //act
            var result = hand.SumOfCards(
                new Blackjack.Card(Rank.Ace, Suit.Spade), 
                new Blackjack.Card(Rank.Five, Suit.Club)
            );
            
            //assert
            Assert.Equal(16, result);
        }
        
        [Fact]
        public void PlayersHandWithAceTest2()
        {
            //arrange
            var hand = new Hand();
            
            //act
            var result = hand.SumOfCards(
                new Card(Rank.Five, Suit.Spade),
                new Card(Rank.King, Suit.Diamond),
                new Card(Rank.Ace, Suit.Heart)
            );
            
            //assert
            Assert.Equal(16, result);
        }
        
        [Fact]
        public void PlayersHandWithAceTest3()
        {
            //arrange
            var hand = new Hand();
            
            //act
            var result = hand.SumOfCards(
                new Card(Rank.Ace, Suit.Club), 
                new Card(Rank.Five, Suit.Spade),
                new Card(Rank.King, Suit.Heart)
            );
            
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