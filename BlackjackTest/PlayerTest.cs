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
          
            //act
            
            //assert
            
        }
        
        [Fact]
        public void HitShouldIncreaseCardCountByOne()
        {
            //arrange
            var stubConsole = new StubConsole();
            var expectedHandTotal = 3;
            var firstCard = new Card(Rank.Eight, Suit.Heart);
            var secondCard = new Card(Rank.Jack, Suit.Club);
            var player = new Player(firstCard, secondCard, stubConsole);
            var deck = new Deck();

            //act
            player.Hit(deck);
            var actualHandTotal = player.Hand.Cards.Count;
            
            //assert
            Assert.Equal(expectedHandTotal, actualHandTotal);

        }

        [Fact]
        public void PlayerShouldBeAbleToStay()
        {
            //arrange
            var stubConsole = new StubConsole();
            var expectedHandTotal = 2;
            var firstCard = new Card(Rank.Eight, Suit.Heart);
            var secondCard = new Card(Rank.Jack, Suit.Club);
            var player = new Player(firstCard, secondCard, stubConsole);
            var deck = new Deck();
            
            //act
            player.Play(deck);
            var actualHandTotal = player.Hand.Cards.Count;

            //assert
            Assert.Equal(expectedHandTotal, actualHandTotal);
        }
    }
}