using Blackjack;
using Xunit;

namespace BlackjackTest
{
    public class HandEvaluatorTest
    {
        //how to use an inline theory - setup test to pass in senrios as fuction arguments
        //fact vs theory - fact is one thing, theory tests a concept not restricted to one condition
        
        [Theory]
        [InlineData(Rank.Eight, Rank.Ace, 19)]
        [InlineData(Rank.Five, Rank.King, 15)]
        [InlineData(Rank.Queen, Rank.King, 20)]
        [InlineData(Rank.Ace, Rank.King, 21)]
        [InlineData(Rank.Nine, Rank.Nine, 18)]
        public void ShouldCalculateCorrectValue(Rank firstRank, Rank secondRank , int total)
        {
            //Arrange
            var firstCard = new Card(firstRank, Suit.Club);
            var secondCard = new Card(secondRank, Suit.Diamond);
            var hand = new Hand(firstCard, secondCard);

            //Act
            var actualTotal = HandEvaluator.GetTotal(hand);

            //Assert
            Assert.Equal(total, actualTotal);
        }
        
        [Fact]
        public void ThreeAcesShouldReturnThirteen()
        {
            //arrange
            var expectedTotal = 13;
            var expectedFirstCard = new Card(Rank.Ace, Suit.Club);
            var expectedSecondCard = new Card(Rank.Ace, Suit.Diamond);
            var expectedthirdCard = new Card(Rank.Ace, Suit.Spade);
            var hand = new Hand(expectedFirstCard, expectedSecondCard);
            
            //act
            hand.AddCardToHand(expectedthirdCard);
            var actualTotal = HandEvaluator.GetTotal(hand);

            //assert
            Assert.Equal(expectedTotal, actualTotal);
        }
        
        [Fact]
        public void TotalShouldReturnSumOfCardsInHand()
        {
            //arrange
            var expectedTotal = 21;
            var expectedFirstCard = new Card(Rank.Ten, Suit.Club);
            var expectedSecondCard = new Card(Rank.Jack, Suit.Club);
            var expectedThridCard = new Card(Rank.Ace, Suit.Club);
            var hand = new Hand(expectedFirstCard, expectedSecondCard);

            //act
            hand.AddCardToHand(expectedThridCard);
            var actualTotal = HandEvaluator.GetTotal(hand);

            //assert
            Assert.Equal(expectedTotal, actualTotal);
        }
        
        [Fact]
        public void TotalShouldReturnSumOfCardsInHand2()
        {
            //arrange
            var expectedTotal = 21;
            var expectedFirstCard = new Card(Rank.Ten, Suit.Club);
            var expectedSecondCard = new Card(Rank.Jack, Suit.Club);
            var expectedThridCard = new Card(Rank.Ace, Suit.Club);
            var hand = new Hand(expectedThridCard, expectedSecondCard);

            //act
            hand.AddCardToHand(expectedFirstCard);
            var actualTotal = HandEvaluator.GetTotal(hand);

            //assert
            Assert.Equal(expectedTotal, actualTotal);
        }
    }
}