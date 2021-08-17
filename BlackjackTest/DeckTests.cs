using BlackjackGame;
using Xunit;

namespace BlackjackTest
{
    public class DeckTests
    {
        //Providing a random card "pulling a random card"
        [Fact]
        public void Should ()
        {
            
        }
        //When deck is created it should have 52 cards
        [Fact]
        public void DeckShouldBe52Cards()
        {
            var expectedCardAmount = 52;
            var deck = new Deck();
            var result = deck.Cards.Count;
            Assert.Equal(expectedCardAmount, result);
        }
        
        //Record of cards taken/used from deck by player or dealer's hand
        //Reset the deck with new game
        
    }
}