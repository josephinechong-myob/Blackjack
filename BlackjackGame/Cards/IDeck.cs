namespace Blackjack.Cards
{
    public interface IDeck
    {
        public Card DrawRandomCard();
        public void ResetDeck();
    }
}