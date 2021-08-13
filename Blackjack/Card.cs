using System;

namespace Blackjack
{
    public class Card
    {
        public string Rank { get; }
        //private int Value { get; }
        public string Suit { get; }

        public Card(string rank, string suit)
        {
            Rank = rank;
            // Value = value;
            Suit = suit;
        }

        public int GetValue()
        {
            //return Value;
            if (Rank != "Ace" && Rank == "Jack" || Rank != "Ace" && Rank == "Queen" || Rank != "Ace" && Rank == "King")
            {
                return 10;
            }
            else if (Rank == "Ace")
            {
                throw new InvalidOperationException("Please don't call value on Ace");
            }
            return Convert.ToInt32(Rank);
        }

        public override string ToString()
        {
            return $"'{Rank}' '{Suit}'";
        }
    }
}