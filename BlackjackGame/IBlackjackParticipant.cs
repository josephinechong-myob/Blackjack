namespace Blackjack
{
    public interface IBlackjackParticipant
    {
        public void Hit(Deck deck);
        
        public void Play(Deck deck);
        // playing (choosing btw hitting or staying)
        // stay
        // interface has no logic (like contents page)
        //evaluate next move
        //
    }
}