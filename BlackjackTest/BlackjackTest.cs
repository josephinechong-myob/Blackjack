using System;
using System.Reflection.Metadata;
using Blackjack.Blackjack;
using Xunit;

namespace BlackjackTest
{
    public class UnitTest1
    {
        Blackjack.Blackjack blackjack = new Blackjack.Blackjack();
        
        [Fact]
        public void PlayersHandTest()
        {
            
            var result = blackjack.SumOfCards(
                new Card("4", "spade"), 
                new Card("5", "spade")
                );
           // Console.WriteLine($"Sum of 4 and 5 should be 9, got: {result}");
           Assert.Equal(9,result);
        }

        [Fact]
        public void PlayersHandWithKingTest()
        {
            var result = blackjack.SumOfCards(
                new Card("King", "spade"), 
                new Card("5", "spade")
                );
            Assert.Equal(15, result);
        }
        
        [Fact]
        public void PlayersHandWithQueenTest()
        {
            var result = Blackjack.Blackjack.SumOfCards(
                new Card("King", "spade"), 
                new Card("5", "spade")
            );
            Assert.Equal(15, result);
        }
        
        [Fact]
        public void PlayersHandWithJackTest()
        {
            var result = Blackjack.Blackjack.SumOfCards(
                new Card("King", "spade"), 
                new Card("5", "spade")
            );
            Assert.Equal(15, result);
        }
        
        [Fact]
        public void PlayersHandWithAceTest()
        {
            var result = Blackjack.Blackjack.SumOfCards(
                new Blackjack.Card("Ace", "spade"), 
                new Blackjack.Card("5", "spade")
            );
            Assert.Equal(16, result);
        }
        
        [Fact]
        public void PlayersHandWithAceTest2()
        {
            var result = Blackjack.Blackjack.SumOfCards(
                new Card("5", "spade"),
                new Card("King", "spade"),
                new Card("Ace", "spade")
            );
            Assert.Equal(16, result);
        }
        
        [Fact]
        public void PlayersHandWithAceTest3()
        {
            var result = Blackjack.Blackjack.SumOfCards(
                new Card("Ace", "spade"), 
                new Card("5", "spade"),
                new Card("King", "spade")
            );
            Assert.Equal(16, result);
        }
    }
}