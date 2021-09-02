using System;
using System.Linq;
using System.Reflection.Metadata;
using Blackjack;
using Xunit;

namespace BlackjackTest
{
    public class HandTest
    {
        //convert this test to theory**
        [Theory]
        [InlineData(Rank.Eight, Rank.Ace, Rank.Two, 21)]
        [InlineData(Rank.Ten, Rank.King, Rank.Ace, 21)]
        [InlineData(Rank.Queen, Rank.King, Rank.Five, 25)]
        [InlineData(Rank.Ace, Rank.Ace, Rank.Ace, 13)]
        [InlineData(Rank.Nine, Rank.Nine, Rank.Four, 22)]
        public void Theory_HandShouldIncreaseAfterAddingACard(Rank firstRank, Rank secondRank, Rank thirdRank, int total)
        {
            //Arrange
            var firstCard = new Card(firstRank, Suit.Club);
            var secondCard = new Card(secondRank, Suit.Diamond);
            var thirdCard = new Card(thirdRank, Suit.Club);
            var hand = new Hand(firstCard, secondCard);
            var expectedCountOfHandCards = 3;
            
            //Act
            hand.AddCardToHand(thirdCard);
            hand.SortHand();
            var actualTotal = HandEvaluator.GetTotal(hand);

            //Assert
            Assert.Equal(total, actualTotal);
            Assert.True(hand.Cards.Contains(thirdCard));
            Assert.Equal(expectedCountOfHandCards, hand.Cards.Count);
        }
        
        [Theory]
        [InlineData(Rank.Eight, Rank.Ace, Rank.Two)]
        [InlineData(Rank.Ten, Rank.Ace, Rank.King)]
        [InlineData(Rank.Queen, Rank.Five, Rank.King)]
        [InlineData(Rank.Ace, Rank.Ace, Rank.King)]
        [InlineData(Rank.Nine, Rank.Four, Rank.Nine)]
        public void Theory_HandShouldSortCards(Rank firstRank, Rank secondRank, Rank thirdRank)
        {
            //arrange
            var firstCard = new Card(firstRank, Suit.Club);
            var secondCard = new Card(secondRank, Suit.Diamond);
            var thirdCard = new Card(thirdRank, Suit.Club);
            var hand = new Hand(firstCard, secondCard);
            
            //act
            hand.AddCardToHand(thirdCard);
            hand.SortHand();

            //assert
            Assert.Equal(secondCard, hand.Cards.Last());
        }
        
        
        /*
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
        public void PlayersHandTest()
        {
            //arrange
            var firstCard = new Card(Rank.Ace, Suit.Club);
            var secondCard = new Card(Rank.Eight, Suit.Diamond);
            var hand = new Hand(firstCard, secondCard);
            
            //act
            var result = HandEvaluator.GetTotal(hand);
            
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
            var result = HandEvaluator.GetTotal(hand);
            
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
            var result = HandEvaluator.GetTotal(hand);
            
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
            var result = HandEvaluator.GetTotal(hand);
            
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
            var result = HandEvaluator.GetTotal(hand);
            
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
            var result = HandEvaluator.GetTotal(hand);
            
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
            var result = HandEvaluator.GetTotal(hand);
            
            //assert
            Assert.Equal(21, result);
        }
        
        
*/
    }
}