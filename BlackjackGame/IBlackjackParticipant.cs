namespace Blackjack
{
    public interface IBlackjackParticipant
    {
        // interface has no logic (like contents page)
        public bool Play(IDeck deck);
        public void Hit(IDeck deck);
    }
}