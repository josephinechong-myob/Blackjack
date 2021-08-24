using Blackjack;
using Xunit;

namespace BlackjackTest
{
    public class PlayerTest
    {
        [Fact]
        public void HitShouldIncreaseCardCountByOne()
        {
            //arrange
            var expectedHandTotal = 3;
            var firstCard = new Card(Rank.Eight, Suit.Heart);
            var secondCard = new Card(Rank.Jack, Suit.Club);
            var player = new Player(firstCard, secondCard);
            var deck = new Deck();

            //act
            player.Hit(deck);
            var actualHandTotal = player.Hand.Cards.Count;
            
            //assert
            Assert.Equal(expectedHandTotal, actualHandTotal);

        }
    }
}