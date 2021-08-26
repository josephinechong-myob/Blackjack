using System.Collections.Generic;
using Blackjack;
using Xunit;
using Moq;

namespace BlackjackTest
{
    public class PlayerTest
    {
        //how to verify how a function is called - helena
        //mocks - testing user input
        //NuGet - terminal 
        
        [Fact]
        public void ScoreOverTwentyOneShouldPrintBustStatement()
        {
            //arrange
            var playOrder = new List<string>() {"1"};
            var stubConsole = new StubConsole(playOrder);
            var firstCard = new Card(Rank.Eight, Suit.Heart);
            var secondCard = new Card(Rank.Jack, Suit.Club);
            var thirdCard = new Card(Rank.Jack, Suit.Spade);
            var player = new Player(firstCard, secondCard, stubConsole);
            var deck = new Deck();
            var expectedBustStatement = "\nThere is a bust!";

            //act
            player.Play(deck);
            player.Hand.AddCardToHand(thirdCard);
            var actualBustStatement = stubConsole.TestingWriteLine[stubConsole.TestingWriteLine.Count-1];
            
            //assert
            Assert.Equal(expectedBustStatement, actualBustStatement);
        }
        
        [Fact]
        public void TestingPlayMethod_HitShouldIncreaseCardCountByOne()
        {
            //arrange
            var mockConsole = new Mock<IConsole>();
            mockConsole.Setup(m => m.ReadLine()).Returns("1");
            var expectedHandTotal = 3;
            var firstCard = new Card(Rank.Eight, Suit.Heart);
            var secondCard = new Card(Rank.Jack, Suit.Club);
            var player = new Player(firstCard, secondCard, mockConsole.Object);
            var deck = new Deck();

            //act
            player.Play(deck);
            var actualHandTotal = player.Hand.Cards.Count;
            
            //assert
            Assert.Equal(expectedHandTotal, actualHandTotal);
        }
        
        [Fact]
        public void HitShouldIncreaseCardCountByOne()
        {
            //arrange
            var playOrder = new List<string>() {"1", "1"};
            var stubConsole = new StubConsole(playOrder);
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
            var playOrder = new List<string> {"0"};
            var stubConsole = new StubConsole(playOrder);
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

        [Fact]
        public void ThereShouldBeOneConsoleWriteLineCountWhenPlayerStays()
        {
            //arrange
            var playOrder = new List<string> {"0"};
            var stubConsole = new StubConsole(playOrder);
            var firstCard = new Card(Rank.Eight, Suit.Heart);
            var secondCard = new Card(Rank.Jack, Suit.Club);
            var player = new Player(firstCard, secondCard, stubConsole);
            var deck = new Deck();
            var expectedWriteLineCount = 1;

            //act
            player.Play(deck);
            var actualWriteLineCount = stubConsole.TestingWriteLine.Count;

            //assert
            Assert.Equal(expectedWriteLineCount, actualWriteLineCount);
        }
        
        [Fact]
        public void WhenPlayerHasTwentyOneConsoleWriteLineShouldPrintWinningStatement()
        {
            //arrange
            var playOrder = new List<string> {"0"};
            var stubConsole = new StubConsole(playOrder);
            var firstCard = new Card(Rank.Ace, Suit.Heart);
            var secondCard = new Card(Rank.Jack, Suit.Club);
            var player = new Player(firstCard, secondCard, stubConsole);
            var deck = new Deck();
            var expectedWinningStatement = "\nYou have won!";

            //act
            player.Play(deck);
            var actualWinningStatement = stubConsole.TestingWriteLine[stubConsole.TestingWriteLine.Count-1];

            //assert
            Assert.Equal(expectedWinningStatement, actualWinningStatement);
        }
    }
}