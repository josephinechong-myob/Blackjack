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
        
        [Theory]
        [InlineData(Rank.Eight, Rank.King, 18)]
        [InlineData(Rank.Ten, Rank.Jack, 20)]
        [InlineData(Rank.Queen, Rank.Five, 15)]
        [InlineData(Rank.King, Rank.King, 20)]
        [InlineData(Rank.Queen, Rank.Queen, 20)]
        [InlineData(Rank.Jack, Rank.Jack, 20)]
        [InlineData(Rank.Queen, Rank.Jack, 20)]
        [InlineData(Rank.Queen, Rank.King, 20)]
        [InlineData(Rank.King, Rank.Jack, 20)]
        [InlineData(Rank.Queen, Rank.Ace, 21)]
        public void Theory_FaceCardsShouldValueTenForScoring(Rank firstRank, Rank secondRank, int total)
        {
            //arrange
            var firstCard = new Card(firstRank, Suit.Club);
            var secondCard = new Card(secondRank, Suit.Diamond);
            var hand = new Hand(firstCard, secondCard);
            
            //act
            hand.SortHand();
            var result = HandEvaluator.GetTotal(hand);

            //assert
            Assert.Equal(total, result);
        }
        
        [Theory]
        [InlineData(Rank.Ace, Rank.King, 21)]
        [InlineData(Rank.Ten, Rank.Ace, 21)]
        [InlineData(Rank.Ace, Rank.Ace, 12)]
        [InlineData(Rank.Two, Rank.Ace, 13)]
        [InlineData(Rank.Queen, Rank.Ace, 21)]
        [InlineData(Rank.Jack, Rank.Ace, 21)]
        [InlineData(Rank.King, Rank.Ace, 21)]
        [InlineData(Rank.Ace, Rank.Nine, 20)]
        [InlineData(Rank.Eight, Rank.Ace, 19)]
        [InlineData(Rank.Three, Rank.Ace, 14)]
        public void Theory_AcesShouldValueEitherOneOrElevenDependingOnSumOfNonAceCards(Rank firstRank, Rank secondRank, int total)
        {
            //arrange
            var firstCard = new Card(firstRank, Suit.Club);
            var secondCard = new Card(secondRank, Suit.Diamond);
            var hand = new Hand(firstCard, secondCard);
            
            //act
            hand.SortHand();
            var result = HandEvaluator.GetTotal(hand);

            //assert
            Assert.Equal(total, result);
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