using System;

namespace Blackjack
{
    public class Card
    {
        public Rank Rank {get;}
        public Suit Suit {get;}

        public Card(Rank rank, Suit suit)
        {
            Rank = rank;
            Suit = suit;
        }

        public int GetRankValue()
        {
            if (Rank == Rank.Jack || Rank == Rank.Queen || Rank == Rank.King)
            {
                return 10;
            }
            else if (Rank == Rank.Ace)
            {
                throw new InvalidOperationException("Please don't call value on Ace");
            }
            return (int)Rank;
        }

        public override string ToString()
        {
            string rank = Enum.GetName(Rank);
            string suit = Enum.GetName(Suit);
            return $"{rank} of {suit}";
        }
    }
}