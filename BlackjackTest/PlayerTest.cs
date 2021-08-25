using Blackjack;
using Xunit;

namespace BlackjackTest
{
    public class PlayerTest
    {
        //mocks - testing user input
        //NuGet - terminal 
        [Fact]
        public void WhenScoreIsOverTwentyOnePlayerShouldBust()
        {
            //arrange
            var consoleOperations = new Mock<IConsoleOperations>();
            //act
            
            //assert
            consoleOperations.Verify(
                m => m.Write(It.Is<string>(c => c == "It’s a bust!")));
        }
        
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