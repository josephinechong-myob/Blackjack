using Blackjack;
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
            var dealer = new Dealer(firstCard, secondCard);
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
            var firstCard = new Card(Rank.Six, Suit.Club);
            var secondCard = new Card(Rank.Seven, Suit.Diamond);
            var dealer = new Dealer(firstCard, secondCard);
            var deck = new Deck();
            var expectedScore = 17;

            //act
            dealer.Play(deck);
            var actualScore = dealer.Score;

            //assert
            Assert.Equal(expectedScore, actualScore);
        }
        
    }
}