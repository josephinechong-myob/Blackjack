using System;
using System.Reflection.Metadata;
using BlackjackGame;
using Xunit;

namespace BlackjackTest
{
    public class UnitTest1
    {
        
        [Fact]
        public void PlayersHandTest()
        {
            var blackjack = new Blackjack();
            var result = blackjack.SumOfCards(
                new Card(Rank.Four, Suit.Spade), 
                new Card(Rank.Five, Suit.Spade)
                );
            Assert.Equal(9,result);
        }
        
        [Fact]
        public void PlayersHandWithKingTest()
        {
            var blackjack = new Blackjack();
            var result = blackjack.SumOfCards(
                new Card(Rank.King, Suit.Spade), 
                new Card(Rank.Five, Suit.Club)
                );
            Assert.Equal(15, result);
        }
        
        [Fact]
        public void PlayersHandWithQueenTest()
        {
            var blackjack = new Blackjack();
            var result = blackjack.SumOfCards(
                new Card(Rank.Queen, Suit.Spade), 
                new Card(Rank.Five, Suit.Club)
            );
            Assert.Equal(15, result);
        }
        
        [Fact]
        public void PlayersHandWithJackTest()
        {
            var blackjack = new Blackjack();
            var result = blackjack.SumOfCards(
                new Card(Rank.Jack, Suit.Spade), 
                new Card(Rank.Five, Suit.Club)
            );
            Assert.Equal(15, result);
        }
        
        [Fact]
        public void PlayersHandWithAceTest()
        {
            var blackjack = new Blackjack();
            var result = blackjack.SumOfCards(
                new BlackjackGame.Card(Rank.Ace, Suit.Spade), 
                new BlackjackGame.Card(Rank.Five, Suit.Club)
            );
            Assert.Equal(16, result);
        }
        
        [Fact]
        public void PlayersHandWithAceTest2()
        {
            var blackjack = new Blackjack();
            var result = blackjack.SumOfCards(
                new Card(Rank.Five, Suit.Spade),
                new Card(Rank.King, Suit.Diamond),
                new Card(Rank.Ace, Suit.Heart)
            );
            Assert.Equal(16, result);
        }
        
        [Fact]
        public void PlayersHandWithAceTest3()
        {
            var blackjack = new Blackjack();
            var result = blackjack.SumOfCards(
                new Card(Rank.Ace, Suit.Club), 
                new Card(Rank.Five, Suit.Spade),
                new Card(Rank.King, Suit.Heart)
            );
            Assert.Equal(16, result);
        }
        
        [Fact]
        public void CardShouldPrintTwoDiamond()
        {
            var card = new Card(Rank.Two, Suit.Diamond);
            var result = card.ToString();
            var expected = "Two of Diamond";
            Assert.Equal(expected, result);
        }
    }
}