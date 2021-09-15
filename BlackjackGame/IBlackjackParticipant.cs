using Blackjack.Cards;

namespace Blackjack
{
    public interface IBlackjackParticipant
    {
        public bool Play(IDeck deck);
        public void Hit(IDeck deck);
        public int Score { get; }
        public string Name { get; }
        public Hand Hand { get; }
    }
}