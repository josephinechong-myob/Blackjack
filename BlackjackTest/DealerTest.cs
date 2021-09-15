using Blackjack;
using Blackjack.Cards;
using Moq;
using Xunit;

namespace BlackjackTest
{
    public class DealerTest
    {
        [Fact]
        public void DealerShouldStopPlayingWhenTheirScoreIsAtLeastSeventeen() //score >=17
        {
            //arrange
            var firstCard = new Card(Rank.Six, Suit.Club);
            var secondCard = new Card(Rank.Ace, Suit.Diamond);
            var mockConsole = new Mock<IConsole>();
            var dealer = new Dealer(firstCard, secondCard, mockConsole.Object, "Dealer");
            var deck = new Deck();
            var expectedScore = 17;

            //act
            dealer.Play(deck);
            var actualScore = dealer.Score;

            //assert
            Assert.Equal(expectedScore, actualScore);
        }
        
        [Fact]
        public void DealerShouldHitWhenTheScoreIsLessThanSeventeen() //score <17 while loop, mock the deck
        {
            //arrange
            var mockDeck = new Mock<IDeck>();
            var mockConsole = new Mock<IConsole>();
            var firstCard = new Card(Rank.Six, Suit.Club);
            var secondCard = new Card(Rank.Seven, Suit.Diamond);
            var thirdCard = new Card(Rank.Seven, Suit.Spade);
            var dealer = new Dealer(firstCard, secondCard, mockConsole.Object, "Dealer");
            var deck = mockDeck;
            var expectedScore = 20;
            mockDeck.Setup(m => m.DrawRandomCard()).Returns(thirdCard);

            //act
            dealer.Play(deck.Object);
            var actualScore = dealer.Score;

            //assert
            Assert.Equal(expectedScore, actualScore);
            mockConsole.Verify(
                m=>m.WriteLine(
                    It.Is<string>(s=>s==$"\nDealer has drawn {thirdCard}")
                ), Times.Once
            );
        }
        
        [Fact]
        public void DealerShouldBustWhenScoreIsOverTwentyOne() //score <17 while loop, mock the deck
        {
            //arrange
            var mockDeck = new Mock<IDeck>();
            var mockConsole = new Mock<IConsole>();
            var firstCard = new Card(Rank.Six, Suit.Club);
            var secondCard = new Card(Rank.Seven, Suit.Diamond);
            var thirdCard = new Card(Rank.Jack, Suit.Spade);
            var dealer = new Dealer(firstCard, secondCard, mockConsole.Object, "Dealer");
            var deck = mockDeck;
            var expectedScore = 23;
            mockDeck.Setup(m => m.DrawRandomCard()).Returns(thirdCard);
            
            //act
            dealer.Play(deck.Object);
            var actualScore = dealer.Score;

            //assert
            Assert.Equal(expectedScore, actualScore);
            mockConsole.Verify(m=>m.WriteLine(
                It.Is <string>(value=> value == "Dealer is at bust\nwith the hand[Jack of Spade][Seven of Diamond][Six of Club]")
                ),Times.Exactly(1)); //checks it was called once but doesn't check that it was the last thing called so making a new list to log all the Writelines whill still help with positioning or the order of thwne things are called
            
        }
        
    }
}