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
        public void TestingHowManyTimesHitOrStayIsCalled()
        {
            //arrange
            var mockConsole = new Mock<IConsole>();
            //mockConsole.Setup(m => m.ReadLine()).Returns("1");
            //mockConsole.SetupSequence(m => m.ReadLine()).Returns("1").Returns("1");
            //mockConsole.SetupSequence(m => m.ReadLine()).Returns(new Queue<string>(new[] { "1", "1"}).Dequeue);
            var firstCard = new Card(Rank.Two, Suit.Heart);
            var secondCard = new Card(Rank.Three, Suit.Club);
            var thirdCard = new Card(Rank.Five, Suit.Spade);
            //var fourthCard = new Card(Rank.Ace, Suit.Spade);
            var player = new Player(firstCard, secondCard, mockConsole.Object);
            var deck = new Deck();


            //act
            player.Play(deck);
            //player.Hand.AddCardToHand(thirdCard);
            //player.Hand.AddCardToHand(fourthCard);
            //var actualWinningStatement = mockConsole.TestingWriteLine[mockConsole.TestingWriteLine.Count-1];
            
            //assert
            mockConsole.Verify(m => m.ReadLine(), Times.Exactly(2));
            
            //Assert.Equal(expectedWinningStatement, actualWinningStatement);
            
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
            mockConsole.Verify(m => m.ReadLine(), Times.Exactly(1));
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
        //mocks return anything, inconsistencies with multiple developers stubs maintains consistency and stubs are used in dependedncy injections
        
        [Fact]
        public void ScoreOverTwentyOneShouldPrintBustStatement()
        {
            //arrange
            var mockConsole = new Mock<IConsole>();
            var mockDeck = new Mock<Deck>();
            mockConsole.Setup(m => m.ReadLine()).Returns("1");
            var firstCard = new Card(Rank.Eight, Suit.Heart);
            var secondCard = new Card(Rank.Jack, Suit.Club);
            var thirdCard = new Card(Rank.Jack, Suit.Spade);
            mockDeck.Setup(m => m.DrawRandomCard()).Returns(thirdCard);
            var player = new Player(firstCard, secondCard, mockConsole.Object);
            var deck = mockDeck.Object;
            var expectedBustStatement = "\nThere is a bust!";
            var logWriteLine = string.Empty;
            mockConsole.Setup(m => m.WriteLine(It.IsAny<string>()))
                .Callback<string>((m) =>
                {
                    logWriteLine = m;
                });
            
            //make a new list to take in m - to know how many times the fucntion was called and with what value
            //act
            player.Play(deck);
            
            //assert
            Assert.Equal(expectedBustStatement, logWriteLine);
            mockConsole.Verify(m => m.ReadLine(), Times.Exactly(1));
        }
    }
}