using Blackjack;
using Xunit;

namespace BlackjackTest
{
    public class HandEvaluatorTest
    {
        [Fact]
        public void SumOfHandShouldReturnSumOfCardsInHand()
        {
            //arrange
            var expectedSumOfHand = 21;
            var expectedFirstCard = new Card(Rank.Ten, Suit.Club);
            var expectedSecondCard = new Card(Rank.Jack, Suit.Club);
            var expectedThridCard = new Card(Rank.Ace, Suit.Club);
            var hand = new Hand(expectedFirstCard, expectedSecondCard);

            //act
            hand.AddCardToHand(expectedThridCard);
            var actualSumOfHand = HandEvaluator.SumOfHand(hand);

            //assert
            Assert.Equal(expectedSumOfHand, actualSumOfHand);
        }
    }
}