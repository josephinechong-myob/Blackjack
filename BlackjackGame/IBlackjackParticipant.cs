namespace Blackjack
{
    public interface IBlackjackParticipant
    {
        // interface has no logic (like contents page)
        public void Play(IDeck deck);
        public void Hit(IDeck deck);
    }
}