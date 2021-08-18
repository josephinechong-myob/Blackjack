using Blackjack;
using Xunit;

namespace BlackjackTest
{
    public class DeckTests
    {
        //When deck is created it should have 52 cards
        [Fact]
        public void DeckShouldBe52Cards()
        {
            //arrange
            var expectedCardAmount = 52;
            var deck = new Deck();
            
            //act
            var result = deck.Cards.Count;
            
            //assert
            Assert.Equal(expectedCardAmount, result);
        }
        //Providing a random card "pulling a random card" - should result in a decreased number in deck
        [Fact]
        public void DeckLengthShouldDecreaseAfterDrawingACard()
        {
            //arrange
            var expectedCardAmount = 50;
            var deck = new Deck();
            
            //act
            deck.DrawRandomCard();
            deck.DrawRandomCard();
            var result = deck.Cards.Count;
            
            //assert
            Assert.Equal(expectedCardAmount, result);
        }

        //Adding more cards to a deck

        [Fact]
        public void DeckLengthShouldIncreaseAfterAddingACard()
        {
            //arrange
            var expectedCardAmount = 54;

            //act
            var deck = new Deck();
            deck.AddCardToDeck();
            deck.AddCardToDeck();
            var result = deck.Cards.Count;
            
            //assert
            Assert.Equal(expectedCardAmount, result);
        }
        
        //Record of cards taken/used from deck by player or dealer's hand
        [Fact]
        public void DrawnCardsShouldBeRecorded()
        {
            //arrange
            var drawnCardsExpectedCount = 2;
            var deck = new Deck();

            //act
            var firstExpectedCard = deck.DrawRandomCard();
            var secondExpectedCard = deck.DrawRandomCard();

            var firstActualCard = deck.DrawnCards[0];
            var secondActualCard = deck.DrawnCards[1];
            var drawnCardsActualCount = deck.DrawnCards.Count;
            
            //assert
            Assert.Equal(drawnCardsExpectedCount, drawnCardsActualCount);
            Assert.Equal(firstExpectedCard, firstActualCard);
            Assert.Equal(secondExpectedCard, secondActualCard);
        }
        
        //Reset the deck with new game - added 2 cards to deck before resetting
        [Fact]
        public void DeckShouldBeResetAtTheStartOfANewGame()
        {
            //arrange
            var expectedCardAmount = 52;
            var deck = new Deck();
            var expectedDrawnCards = 0;
            
            //act
            deck.DrawRandomCard();
            deck.DrawRandomCard();
            deck.ResetDeck();
            var actualDrawnCards = deck.DrawnCards.Count;
            
            var result = deck.Cards.Count;
            
            //assert
            Assert.Equal(expectedCardAmount, result);
            Assert.Equal(expectedDrawnCards, actualDrawnCards);
        }
    }
}