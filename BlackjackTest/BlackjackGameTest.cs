using Blackjack;
using Blackjack.Cards;
using Moq;
using Xunit;

namespace BlackjackTest
{
    public class BlackjackGameTest //theory inline testing
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
            mockConsole.Verify(
                m=>m.WriteLine(
                    It.Is<string>(s=>s==$"\nDealer wins!")
                ), Times.Never
            );
            mockConsole.Verify(
                m=>m.WriteLine(
                    It.Is<string>(s=>s==$"\nIt's a tie!")
                ), Times.Never
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
            mockConsole.Verify(
                m=>m.WriteLine(
                    It.Is<string>(s=>s==$"\nIt's a tie!")
                ), Times.Never
            );
            mockConsole.Verify(
                m=>m.WriteLine(
                    It.Is<string>(s=>s==$"\nPlayer has beat the dealer!")
                ), Times.Never
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
            
            mockConsole.SetupSequence(m => m.ReadLine())
                .Returns("0");
            
            var game = new BlackjackGame(mockConsole.Object, mockDeck.Object);
            
            //act
            game.Run();
            while (game.DoesUserWantToContinueGame())
            {
                game.Reset();
                game.Run();
            }
            
            //assert
            
            mockConsole.Verify(
                m=>m.WriteLine(
                    It.Is<string>(s=>s==$"\nIt's a tie!")
                ), Times.Once
            );
            mockConsole.Verify(
                m=>m.WriteLine(
                    It.Is<string>(s=>s==$"Tie has occured 1 time")
                ), Times.Once
            );
            mockConsole.Verify(
                m=>m.WriteLine(
                    It.Is<string>(s=>s==$"Tie has a win count of 1")
                ), Times.Never
            );
            mockConsole.Verify(
                m=>m.WriteLine(
                    It.Is<string>(s=>s==$"\nPlayer has beat the dealer!")
                ), Times.Never
            );
            mockConsole.Verify(
                m=>m.WriteLine(
                    It.Is<string>(s=>s==$"\nDealer wins!")
                ), Times.Never
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
            mockConsole.Verify(
                m=>m.WriteLine(
                    It.Is<string>(s=>s==$"\nPlayer has beat the dealer!")
                ), Times.Never
            );
            mockConsole.Verify(
                m=>m.WriteLine(
                    It.Is<string>(s=>s==$"\nDealer wins!")
                ), Times.Never
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
                mockConsole.Verify(
                    m=>m.WriteLine(
                        It.Is<string>(s=>s==$"\nIt's a tie!")
                    ), Times.Never
                );
                mockConsole.Verify(
                    m=>m.WriteLine(
                        It.Is<string>(s=>s==$"\nDealer wins!")
                    ), Times.Never
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
                mockConsole.Verify(
                    m=>m.WriteLine(
                        It.Is<string>(s=>s==$"\nPlayer has beat the dealer!")
                    ), Times.Never
                );
                mockConsole.Verify(
                    m=>m.WriteLine(
                        It.Is<string>(s=>s==$"\nIt's a tie!")
                    ), Times.Never
                );
            }
            
            [Fact]                              
            public void ShouldAssignPlayerAsTheWinnerIfDealerIsBust_CaseStudy()
            {
                //arrange
                var mockConsole = new Mock<IConsole>();
                var mockDeck = new Mock<IDeck>();
                var firstCard = new Card(Rank.Ten, Suit.Heart);
                var secondCard = new Card(Rank.Ten, Suit.Club);
                var thirdCard = new Card(Rank.Jack, Suit.Spade);
                var fourthCard = new Card(Rank.Three, Suit.Spade);
                var fifthCard = new Card(Rank.Ace, Suit.Diamond);
                var sixthCard = new Card(Rank.Queen, Suit.Diamond);
            
                mockConsole.SetupSequence(m => m.ReadLine())
                    .Returns("0");
            
                mockDeck.SetupSequence(m => m.DrawRandomCard())
                    .Returns(firstCard)
                    .Returns(secondCard)
                    .Returns(thirdCard)
                    .Returns(fourthCard)
                    .Returns(fifthCard)
                    .Returns(sixthCard);
            
                var game = new BlackjackGame(mockConsole.Object, mockDeck.Object);
            
                //act
                game.Run();
            
                //assert
                mockConsole.Verify(
                    m=>m.WriteLine(
                        It.Is<string>(s=>s==$"\nPlayer has beat the dealer!")
                    ), Times.Once
                );
                mockConsole.Verify(
                    m=>m.WriteLine(
                        It.Is<string>(s=>s==$"Dealer is at bust\nwith the hand[Queen of Diamond][Jack of Spade][Three of Spade][Ace of Diamond]")
                    ), Times.Once
                );
                mockConsole.Verify(
                    m=>m.WriteLine(
                        It.Is<string>(s=>s==$"\nDealer wins!")
                    ), Times.Never
                );
            }
            
            [Fact]                              
            public void ShouldAssignDealerAsTheWinnerIfPlayerIsBust_CaseStudy2()
            {
                //arrange
                var mockConsole = new Mock<IConsole>();
                var mockDeck = new Mock<IDeck>();
                var firstCard = new Card(Rank.Ten, Suit.Heart);
                var secondCard = new Card(Rank.Ten, Suit.Club);
                var thirdCard = new Card(Rank.Jack, Suit.Spade);
                var fourthCard = new Card(Rank.Six, Suit.Spade);
                var fifthCard = new Card(Rank.King, Suit.Diamond);
                var sixCard = new Card(Rank.Two, Suit.Spade);
                
                mockConsole.SetupSequence(m => m.ReadLine())
                    .Returns("1");
            
                mockDeck.SetupSequence(m => m.DrawRandomCard())
                    .Returns(firstCard)
                    .Returns(secondCard)
                    .Returns(thirdCard)
                    .Returns(fourthCard)
                    .Returns(fifthCard)
                    .Returns(sixCard);
            
                var game = new BlackjackGame(mockConsole.Object, mockDeck.Object);
            
                //act
                game.Run();
            
                //assert
                mockConsole.Verify(
                    m=>m.WriteLine(
                        It.Is<string>(s=>s==$"Dealer is at 18")
                    ), Times.Never
                );
                mockConsole.Verify(
                    m=>m.WriteLine(
                        It.Is<string>(s=>s==$"\nDealer wins!")
                    ), Times.Once
                );
            }
            
            //Resetting the game after finishing previous game
            [Fact]
            public void GameDeckShouldResetHandCardsWhenRestartingNewGame()
            {
                //assign
                var mockConsole = new Mock<IConsole>();
                var mockDeck = new Mock<IDeck>();
                var firstCard = new Card(Rank.Ten, Suit.Heart);
                var secondCard = new Card(Rank.Ace, Suit.Club);
                var thirdCard = new Card(Rank.Jack, Suit.Spade);
                var fourthCard = new Card(Rank.Seven, Suit.Spade);
                var fifthCard = new Card(Rank.King, Suit.Spade);
                var sixthCard = new Card(Rank.Ace, Suit.Spade);
                var seventhCard = new Card(Rank.Nine, Suit.Spade);
                var eighthCard = new Card(Rank.Ten, Suit.Spade);

                //act
                mockDeck.SetupSequence(m => m.DrawRandomCard())
                    .Returns(firstCard)
                    .Returns(secondCard)
                    .Returns(thirdCard)
                    .Returns(fourthCard)
                    .Returns(fifthCard)
                    .Returns(sixthCard)
                    .Returns(seventhCard)
                    .Returns(eighthCard);
                
                mockConsole.SetupSequence(m => m.ReadLine())
                    .Returns("1")
                    .Returns("0");
                
                var game = new BlackjackGame(mockConsole.Object, mockDeck.Object);
            
                //act
                game.Run();
                game.DoesUserWantToContinueGame();
                game.Reset();
                game.Run();

                //assert
                mockConsole.Verify(
                    m=>m.WriteLine(
                        It.Is<string>(s=>s==$"Let's play again")
                    ), Times.Once
                );
                mockConsole.Verify(
                    m=>m.WriteLine(
                        It.Is<string>(s=>s==$"Jo is currently at 21\nwith the hand[King of Spade][Ace of Spade]")
                    ), Times.Once
                );
                mockConsole.Verify(
                    m=>m.WriteLine(
                        It.Is<string>(s=>s==$"Do you want to play blackjack again? (Yes = 1, No = 0)")
                    ), Times.Once
                );
            }

            [Fact]
            public void WinnersRecordShouldReflectWinsByPlayerAndDealer()
            {
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

                mockConsole.SetupSequence(m => m.ReadLine())
                    .Returns("0");
            
                var game = new BlackjackGame(mockConsole.Object, mockDeck.Object);
            
                //act
                game.Run();
                while (game.DoesUserWantToContinueGame())
                {
                    game.Reset();
                    game.Run();
                }
                
                //assert
                mockConsole.Verify(
                    m=>m.WriteLine(
                        It.Is<string>(s=>s==$"\nPlayer has beat the dealer!")
                    ), Times.Once
                );
                mockConsole.Verify(
                    m=>m.WriteLine(
                        It.Is<string>(s=>s==$"Jo has a win count of 1")
                    ), Times.Once
                );
            }

            [Fact]
            public void ShouldReportBothPlayerAndDealerWinningInWinnersRecord()
            {
                var mockConsole = new Mock<IConsole>();
                var mockDeck = new Mock<IDeck>();
                var firstCard = new Card(Rank.Ace, Suit.Heart);
                var secondCard = new Card(Rank.Ten, Suit.Club);
                var thirdCard = new Card(Rank.Six, Suit.Spade);
                var fourthCard = new Card(Rank.Ace, Suit.Spade);

                mockDeck.SetupSequence(m => m.DrawRandomCard())
                    .Returns(firstCard)//player wins
                    .Returns(secondCard)
                    .Returns(thirdCard)
                    .Returns(fourthCard)
                    .Returns(thirdCard)//2nd run - dealer wins players staysf
                    .Returns(fourthCard)
                    .Returns(firstCard)
                    .Returns(secondCard)
                    .Returns(thirdCard)//3rd run - dealer wins players stays
                    .Returns(fourthCard)
                    .Returns(firstCard)
                    .Returns(secondCard);
                
                mockConsole.SetupSequence(m => m.ReadLine())
                    .Returns("1")
                    .Returns("0")
                    .Returns("1")
                    .Returns("0")
                    .Returns("0");
            
                var game = new BlackjackGame(mockConsole.Object, mockDeck.Object);
            
                //act
                game.Run();
                while (game.DoesUserWantToContinueGame())
                {
                    game.Reset();
                    game.Run();
                }
                
                //assert
                mockConsole.Verify(
                    m=>m.WriteLine(
                        It.Is<string>(s=>s==$"\nPlayer has beat the dealer!")
                    ), Times.Once
                );
                mockConsole.Verify(
                    m=>m.WriteLine(
                        It.Is<string>(s=>s==$"\nDealer wins!")
                    ), Times.Exactly(2)
                );
                mockConsole.Verify(
                    m=>m.WriteLine(
                        It.Is<string>(s=>s==$"Jo has a win count of 1")
                    ), Times.Once
                );
                mockConsole.Verify(
                    m=>m.WriteLine(
                        It.Is<string>(s=>s==$"Dealer has a win count of 2")
                    ), Times.Once
                );
            }
    }
}