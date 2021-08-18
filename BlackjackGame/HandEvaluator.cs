using System;
using System.Data;

namespace Blackjack
{
    public class HandEvaluator
    {
        public string WinCondition1(int sum)
        {
            if (sum == 21) return "You have hit 21 and win the game!";
            if (sum > 21) return "You have gone bust";
            return "something";
        }
    }
}