using System.Collections.Generic;
using Blackjack;
using Blackjack.Cards;
using Xunit;
using Moq;

namespace BlackjackTest
{
    public class PlayerTest
    {
        private Mock<IConsole> _mockConsole;
        public PlayerTest()
        {
            _mockConsole = new Mock<IConsole>();
        }
        
        [Fact]
        public void PlayersScoreShouldReflectTheValueOfItsHand()
        {
            //arrange
            var mockConsole = new Mock<IConsole>();
            var firstCard = new Card(Rank.Two, Suit.Heart);
            var secondCard = new Card(Rank.Three, Suit.Club);
            var player = new Player(firstCard, secondCard, mockConsole.Object, "Jo");
            var hand = new Hand(firstCard, secondCard);
            var expectedValue = HandEvaluator.GetTotal(hand);
            
            //act

            //assert
            Assert.Equal(expectedValue, player.Score);
        }
        
        [Fact]
        public void PlayerShouldBeAbleToDrawMultipleCards()
        {
            //arrange
            var mockConsole = new Mock<IConsole>();
            var mockdeck = new Mock<IDeck>();
            var firstCard = new Card(Rank.Two, Suit.Heart);
            var secondCard = new Card(Rank.Three, Suit.Club);
            var thirdCard = new Card(Rank.Five, Suit.Spade);
            var fourthCard = new Card(Rank.Ace, Suit.Spade);

            mockConsole.SetupSequence(m => m.ReadLine())
                .Returns("1")
                .Returns("1");

            mockdeck.SetupSequence(m => m.DrawRandomCard())
                .Returns(thirdCard)
                .Returns(fourthCard);
            
            var player = new Player(firstCard, secondCard, mockConsole.Object, "Jo");
            var deck = mockdeck.Object;
            
            //act
            player.Play(deck);

            //assert
            mockConsole.Verify(m => m.ReadLine(), Times.Exactly(2));
            mockConsole.Verify(
                m=>m.WriteLine(
                    It.Is<string>(s=>s==$"\nYou draw {thirdCard}")
                ), Times.Once
            );
        }
        
        [Fact]
        public void TestingPlayMethod_HitShouldIncreaseCardCountByOne()
        {
            //arrange
            var mockConsole = new Mock<IConsole>();
            mockConsole.SetupSequence(m => m.ReadLine())
                .Returns("1")
                .Returns("0");
            var expectedHandTotal = 3;
            var firstCard = new Card(Rank.Eight, Suit.Heart);
            var secondCard = new Card(Rank.Jack, Suit.Club);
            var thirdCard = new Card(Rank.Two, Suit.Club);
            var player = new Player(firstCard, secondCard, mockConsole.Object, "Jo");
            var mockDeck = new Mock<IDeck>();
            mockDeck.Setup(m => m.DrawRandomCard()).Returns(thirdCard);

            //act
            player.Play(mockDeck.Object);
            var actualHandTotal = player.Hand.Cards.Count;
            
            //assert
            Assert.Equal(expectedHandTotal, actualHandTotal);
            mockConsole.Verify(m => m.ReadLine(), Times.Exactly(2));
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
            var player = new Player(firstCard, secondCard, stubConsole, "Jo");
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
            var player = new Player(firstCard, secondCard, stubConsole, "Jo");
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
            var player = new Player(firstCard, secondCard, stubConsole, "Jo");
            var deck = new Deck();
            var expectedWriteLineCount = 2;

            //act
            player.Play(deck);
            var actualWriteLineCount = stubConsole.TestingWriteLine.Count;

            //assert
            Assert.Equal(expectedWriteLineCount, actualWriteLineCount);
        }
        
        [Fact]
        public void WhenPlayerHasTwentyOneConsoleWriteLineShouldPrintPlayerStatement()
        {
            //arrange
            var playOrder = new List<string> {"0"};
            var stubConsole = new StubConsole(playOrder);
            var firstCard = new Card(Rank.Ace, Suit.Heart);
            var secondCard = new Card(Rank.Jack, Suit.Club);
            var player = new Player(firstCard, secondCard, stubConsole, "Jo");
            var deck = new Deck();
            var expectedWinningStatement = "Jo is currently at 21\nwith the hand[Jack of Club][Ace of Heart]";

            //act
            player.Play(deck);
            var actualWinningStatement = stubConsole.TestingWriteLine[stubConsole.TestingWriteLine.Count-1];

            //assert
            Assert.Equal(expectedWinningStatement, actualWinningStatement);
        }

        [Fact]
        public void ScoreOverTwentyOneShouldPrintBustStatement()
        {
            // times function being called = times you have hit
            
            //arrange
            var mockConsole = new Mock<IConsole>();
            var mockDeck = new Mock<IDeck>();
            mockConsole.Setup(m => m.ReadLine()).Returns("1");
            var firstCard = new Card(Rank.Eight, Suit.Heart);
            var secondCard = new Card(Rank.Jack, Suit.Club);
            var thirdCard = new Card(Rank.Jack, Suit.Spade);
            mockDeck.Setup(m => m.DrawRandomCard()).Returns(thirdCard);
            var player = new Player(firstCard, secondCard, mockConsole.Object, "Jo");
            var deck = mockDeck.Object;
            var expectedBustStatement = "\nYou are currently at bust!";
            //make a new list to take in m - to know how many times the function was called and with what value
            var writeLineList = new List<string>();
            var logWriteLine = string.Empty;
            
            mockConsole.Setup(m => m.WriteLine(It.IsAny<string>()))
                .Callback<string>((m) =>
                {
                    logWriteLine = m;
                    //tracking value of write line
                    writeLineList.Add(m);
                });
            
            //act
            player.Play(deck);
            var lastIndexForWriteLineList = writeLineList.Count - 1;
            
            //assert
            Assert.Equal(expectedBustStatement, writeLineList[lastIndexForWriteLineList]);
            mockConsole.Verify(m => m.ReadLine(), Times.Exactly(1));
        }
    }
}