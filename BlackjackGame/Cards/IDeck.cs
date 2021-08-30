namespace Blackjack
{
    public interface IDeck
    {
        public Card DrawRandomCard();

        public void ResetDeck();
    }
}