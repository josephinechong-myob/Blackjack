using Blackjack;
using Xunit;

namespace BlackjackTest
{
    public class HandEvaluatorTest
    {
        //how to use an inline theory - setup test to pass in senrios as fuction arguments
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