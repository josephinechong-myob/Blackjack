using BlackjackGame;
using Xunit;

namespace BlackjackTest
{
    public class DeckTests
    {
        //When deck is created it should have 52 cards
        [Fact]
        public void DeckShouldBe52Cards()
        {
            var expectedCardAmount = 52;
            var deck = new Deck();
            var result = deck.Cards.Count;
            Assert.Equal(expectedCardAmount, result);
        }
        //Providing a random card "pulling a random card" - should result in a decreased number in deck
        [Fact]
        public void DeckLengthShouldDecreaseAfterDrawingACard()
        {
            //arrange
            var expectedCardAmount = 51;
            var deck = new Deck();
            
            //act
            deck.DrawRandomCard();
            var result = deck.Cards.Count;
            
            //assert
            Assert.Equal(expectedCardAmount, result);
        }

        //Drawing more than 52 cards to a deck

        [Fact]
        public void DeckLengthShouldIncreaseAfterAddingACard()
        {
            //arrange
            var expectedCardAmount = 53;
            var deck = new Deck();
            
            //act
            deck.AddingCardToDeck();
            var result = deck.Cards.Count;
            
            //assert
            Assert.Equal(expectedCardAmount, result);
        }
        
        //Record of cards taken/used from deck by player or dealer's hand
        
        
        //Reset the deck with new game
        [Fact]
        public void DeckShouldBeResetAtTheStartOfANewGame()
        {
            //arrange
            var expectedCardAmount = 52;
            var deck = new Deck();
            
            //act
            var result = deck.Cards.Count;
            
            //assert
            Assert.Equal(expectedCardAmount, result);
        }
    }
}