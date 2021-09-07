using Blackjack;
using Moq;
using Xunit;

namespace BlackjackTest
{
    public class BlackjackGameTest
    {
        //If the player and the dealer both don't bust, whoever is closest to 21 wins.
        
        [Fact]
        public void ShouldAssignTheWinnerToHighestScoreUnderTwentyOne()
        {
            //arrange
            
            var mockConsole = new Mock<IConsole>();
            var mockDeck = new Mock<IDeck>();
            var game = new BlackjackGame(mockConsole.Object, mockDeck.Object);
            
            
            //players wins writeline "you beat the dealer" statement
            
            //act

            //assert
        }
            //If the player has blackjack, they win, unless the dealer also has blackjack, in which case the game is a tie.
            //If the dealer busts and the player doesn't, the player wins.
            //If the player busts, the dealer wins.
            
    }
}