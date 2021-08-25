namespace Blackjack
{
    public interface IBlackjackParticipant
    {
        // interface has no logic (like contents page)
        public void Play(Deck deck);
        public void Hit(Deck deck);
        public void ResetGame(Deck deck);
    }
}