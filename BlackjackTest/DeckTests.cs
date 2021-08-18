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
            
            //act
            var deck = new Deck();
            var result = deck.Cards.Count;
            
            //assert
            Assert.Equal(expectedCardAmount, result);
        }
        //Providing a random card "pulling a random card" - should result in a decreased number in deck
        [Fact]
        public void DeckLengthShouldDecreaseAfterDrawingACard()
        {
            //arrange
            var expectedCardAmount = 51;

            //act
            var deck = new Deck();
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
            deck.AddingCardToDeck();
            deck.AddingCardToDeck();
            var result = deck.Cards.Count;
            
            //assert
            Assert.Equal(expectedCardAmount, result);
        }
        
        //Record of cards taken/used from deck by player or dealer's hand
        
        
        //Reset the deck with new game - added 2 cards to deck before resetting
        [Fact]
        public void DeckShouldBeResetAtTheStartOfANewGame()
        {
            //arrange
            var expectedCardAmount = 52;

            //act
            var deck = new Deck();
            deck.AddingCardToDeck();
            deck.AddingCardToDeck();
            deck.ResetDeck();
            var result = deck.Cards.Count;
            
            //assert
            Assert.Equal(expectedCardAmount, result);
        }
    }
}