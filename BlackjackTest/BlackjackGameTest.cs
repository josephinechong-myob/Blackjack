using Blackjack;
using Moq;
using Xunit;

namespace BlackjackTest
{
    public class BlackjackGameTest
    {
        //If the player and the dealer both don't bust, whoever is closest to 21 wins.
        [Fact]                              
        public void ShouldAssignPlayerAsTheWinnerForHavingHighestScoreUnderTwentyOne()
        {
            //arrange
            var mockConsole = new Mock<IConsole>();
            var mockDeck = new Mock<IDeck>();
            var firstCard = new Card(Rank.Ace, Suit.Heart);
            var secondCard = new Card(Rank.Ten, Suit.Club);
            var thirdCard = new Card(Rank.Six, Suit.Spade);
            var fourthCard = new Card(Rank.Ace, Suit.Spade);
            
            mockDeck.SetupSequence(m => m.DrawRandomCard())
                .Returns(firstCard)
                .Returns(secondCard)
                .Returns(thirdCard)
                .Returns(fourthCard);
            
            var game = new BlackjackGame(mockConsole.Object, mockDeck.Object);
            
            //act
            game.Run();
            
            //assert
            mockConsole.Verify(
                m=>m.WriteLine(
                    It.Is<string>(s=>s==$"\nPlayer has beat the dealer!")
                ), Times.Once
            );
        }
        
        [Fact]                              
        public void ShouldAssignDealerAsTheWinnerForHavingHighestScoreUnderTwentyOne()
        {
            //arrange
            var mockConsole = new Mock<IConsole>();
            var mockDeck = new Mock<IDeck>();
            var firstCard = new Card(Rank.Two, Suit.Heart);
            var secondCard = new Card(Rank.Ten, Suit.Club);
            var thirdCard = new Card(Rank.Jack, Suit.Spade);
            var fourthCard = new Card(Rank.Ace, Suit.Spade);
            
            mockConsole.SetupSequence(m => m.ReadLine())
                .Returns("0");
            
            mockDeck.SetupSequence(m => m.DrawRandomCard())
                .Returns(firstCard)
                .Returns(secondCard)
                .Returns(thirdCard)
                .Returns(fourthCard);
            
            var game = new BlackjackGame(mockConsole.Object, mockDeck.Object);
            
            //act
            game.Run();
            
            //assert
            mockConsole.Verify(
                m=>m.WriteLine(
                    It.Is<string>(s=>s==$"\nDealer wins!")
                ), Times.Once
            );
        }
        
        //If the player has blackjack, they win, unless the dealer also has blackjack, in which case the game is a tie.
        [Fact]                              
        public void ShouldAssignPlayerAndDealerWithTieWhenBothScoreTwentyOne()
        {
            //arrange
            var mockConsole = new Mock<IConsole>();
            var mockDeck = new Mock<IDeck>();
            var firstCard = new Card(Rank.Ace, Suit.Heart);
            var secondCard = new Card(Rank.Ten, Suit.Club);
            var thirdCard = new Card(Rank.Jack, Suit.Spade);
            var fourthCard = new Card(Rank.Ace, Suit.Spade);
            
            mockDeck.SetupSequence(m => m.DrawRandomCard())
                .Returns(firstCard)
                .Returns(secondCard)
                .Returns(thirdCard)
                .Returns(fourthCard);
            
            var game = new BlackjackGame(mockConsole.Object, mockDeck.Object);
            
            //act
            game.Run();
            
            //assert
            
            mockConsole.Verify(
                m=>m.WriteLine(
                    It.Is<string>(s=>s==$"\nIt's a tie!")
                ), Times.Once
            );
        }
        
        [Fact]                              
        public void ShouldAssignPlayerAndDealerWithTieWhenScoresAreEqualUnderTwentyOne()
        {
            //arrange
            var mockConsole = new Mock<IConsole>();
            var mockDeck = new Mock<IDeck>();
            var firstCard = new Card(Rank.Seven, Suit.Heart);
            var secondCard = new Card(Rank.Ten, Suit.Club);
            var thirdCard = new Card(Rank.Ten, Suit.Spade);
            var fourthCard = new Card(Rank.Seven, Suit.Spade);
            
            mockConsole.SetupSequence(m => m.ReadLine())
                .Returns("0");
            
            mockDeck.SetupSequence(m => m.DrawRandomCard())
                .Returns(firstCard)
                .Returns(secondCard)
                .Returns(thirdCard)
                .Returns(fourthCard);
            
            var game = new BlackjackGame(mockConsole.Object, mockDeck.Object);
            
            //act
            game.Run();
            
            //assert
            mockConsole.Verify(
                m=>m.WriteLine(
                    It.Is<string>(s=>s==$"\nIt's a tie!")
                ), Times.Once
            );
        }
           
            //If the dealer busts and the player doesn't, the player wins.
            [Fact]                              
            public void ShouldAssignPlayerAsTheWinnerIfTheDealerBust()
            {
                //arrange
                var mockConsole = new Mock<IConsole>();
                var mockDeck = new Mock<IDeck>();
                var firstCard = new Card(Rank.Two, Suit.Heart);
                var secondCard = new Card(Rank.Ten, Suit.Club);
                var thirdCard = new Card(Rank.Jack, Suit.Spade);
                var fourthCard = new Card(Rank.Six, Suit.Spade);
                var fifthCard = new Card(Rank.Jack, Suit.Diamond);
            
                mockConsole.SetupSequence(m => m.ReadLine())
                    .Returns("0");
            
                mockDeck.SetupSequence(m => m.DrawRandomCard())
                    .Returns(firstCard)
                    .Returns(secondCard)
                    .Returns(thirdCard)
                    .Returns(fourthCard)
                    .Returns(fifthCard);
            
                var game = new BlackjackGame(mockConsole.Object, mockDeck.Object);
            
                //act
                game.Run();
            
                //assert
            
                mockConsole.Verify(
                    m=>m.WriteLine(
                        It.Is<string>(s=>s==$"\nPlayer has beat the dealer!")
                    ), Times.Once
                );
            
            }
            
            //If the player busts, the dealer wins.
            [Fact]                              
            public void ShouldAssignDealerAsTheWinnerIfPlayerBust()
            {
                //arrange
                var mockConsole = new Mock<IConsole>();
                var mockDeck = new Mock<IDeck>();
                var firstCard = new Card(Rank.Ten, Suit.Heart);
                var secondCard = new Card(Rank.Ten, Suit.Club);
                var thirdCard = new Card(Rank.Jack, Suit.Spade);
                var fourthCard = new Card(Rank.Seven, Suit.Spade);
                var fifthCard = new Card(Rank.Jack, Suit.Diamond);
            
                mockConsole.SetupSequence(m => m.ReadLine())
                    .Returns("1");
            
                mockDeck.SetupSequence(m => m.DrawRandomCard())
                    .Returns(firstCard)
                    .Returns(secondCard)
                    .Returns(thirdCard)
                    .Returns(fourthCard)
                    .Returns(fifthCard);
            
                var game = new BlackjackGame(mockConsole.Object, mockDeck.Object);
            
                //act
                game.Run();
            
                //assert
                mockConsole.Verify(
                    m=>m.WriteLine(
                        It.Is<string>(s=>s==$"\nDealer wins!")
                    ), Times.Once
                );
            }
    }
}