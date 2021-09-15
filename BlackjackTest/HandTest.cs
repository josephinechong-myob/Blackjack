using System;
using System.Linq;
using System.Reflection.Metadata;
using Blackjack;
using Blackjack.Cards;
using Moq;
using Xunit;

namespace BlackjackTest
{
    public class HandTest
    {
        private readonly Mock<IConsole> _mockConsole;

        public HandTest()
        {
            _mockConsole = new Mock<IConsole>();
        }
        
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
            var hand = new Hand(firstCard, secondCard, _mockConsole.Object);
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
            var hand = new Hand(firstCard, secondCard, _mockConsole.Object);
            
            //act
            hand.AddCardToHand(thirdCard);
            hand.SortHand();

            //assert
            Assert.Equal(secondCard, hand.Cards.Last());
        }

        [Fact]
        public void HandShouldBeEmptyWhenCleared()
        {
            //arrange
            var firstCard = new Card(Rank.Three, Suit.Club);
            var secondCard = new Card(Rank.Two, Suit.Diamond);
            var thirdCard = new Card(Rank.Four, Suit.Club);
            var hand = new Hand(firstCard, secondCard, _mockConsole.Object);
            var expectedCountAfterThirdCardAdded = 3;
            var expectedCountAfterClearedHand = 0;
            
            //act
            hand.AddCardToHand(thirdCard);
            var actualhandCountAfterThirdCard = hand.Cards.Count;
            hand.ClearHand();
            var actualhandCountAfterClearedHand = hand.Cards.Count;

            //assert
            Assert.Equal(expectedCountAfterThirdCardAdded, actualhandCountAfterThirdCard);
            Assert.Equal(expectedCountAfterClearedHand, actualhandCountAfterClearedHand);
        }
        
        [Fact]
        public void HandShouldHoldTwoCardsAfterReset()
        {
            //arrange
            var firstCard = new Card(Rank.Three, Suit.Club);
            var secondCard = new Card(Rank.Two, Suit.Diamond);
            var thirdCard = new Card(Rank.Four, Suit.Club);
            var fourthCard = new Card(Rank.Ace, Suit.Club);
            var fifthCard = new Card(Rank.King, Suit.Club);
            var hand = new Hand(firstCard, secondCard, _mockConsole.Object);
            var expectedCountAfterThirdCardAdded = 3;
            var expectedCountAfterResetHand = 2;
            
            //act
            hand.AddCardToHand(thirdCard);
            var actualhandCountAfterThirdCard = hand.Cards.Count;
            hand.ClearHand();
            hand.ResetHand(fourthCard, fifthCard);
            var actualhandCountAfterResetHand = hand.Cards.Count;

            //assert
            Assert.Equal(expectedCountAfterThirdCardAdded, actualhandCountAfterThirdCard);
            Assert.Equal(expectedCountAfterResetHand, actualhandCountAfterResetHand);
        }
    }
}