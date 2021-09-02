using System;
using System.Linq;
using System.Reflection.Metadata;
using Blackjack;
using Xunit;

namespace BlackjackTest
{
    public class HandTest
    {
        //convert this test to theory**
        [Theory]
        [InlineData(Rank.Eight, Rank.Ace, Rank.Two, 21)]
        [InlineData(Rank.Ten, Rank.King, Rank.Ace, 21)]
        [InlineData(Rank.Queen, Rank.King, Rank.Five, 25)]
        //[InlineData(Rank.Ace, Rank.King, Rank.Ace, 12)]
        [InlineData(Rank.Nine, Rank.Nine, Rank.Four, 22)]
        public void Theory_HandShouldIncreaseAfterAddingACard(Rank firstRank, Rank secondRank, Rank thirdRank, int total)
        {
            //Arrange
            var firstCard = new Card(firstRank, Suit.Club);
            var secondCard = new Card(secondRank, Suit.Diamond);
            var thirdCard = new Card(thirdRank, Suit.Club);
            var hand = new Hand(firstCard, secondCard);
            var expectedCountOfHandCards = 3;
            
            //Act
            hand.AddCardToHand(thirdCard);
            hand.SortHand();
            var actualTotal = HandEvaluator.GetTotal(hand);

            //Assert
            Assert.Equal(total, actualTotal);
            Assert.True(hand.Cards.Contains(thirdCard));
            Assert.Equal(expectedCountOfHandCards, hand.Cards.Count);
        }
        
        [Theory]
        [InlineData(Rank.Eight, Rank.Ace, Rank.Two, 21)]
        [InlineData(Rank.Ten, Rank.Ace, Rank.King, 21)]
        [InlineData(Rank.Queen, Rank.Five, Rank.King, 25)]
        [InlineData(Rank.Ace, Rank.Ace, Rank.King, 12)]
        [InlineData(Rank.Nine, Rank.Four, Rank.Nine, 22)]
        public void Theory_HandShouldSortCards(Rank firstRank, Rank secondRank, Rank thirdRank, int total)
        {
            //arrange
            var firstCard = new Card(firstRank, Suit.Club);
            var secondCard = new Card(secondRank, Suit.Diamond);
            var thirdCard = new Card(thirdRank, Suit.Club);
            var hand = new Hand(firstCard, secondCard);
            
            //act
            hand.AddCardToHand(thirdCard);
            hand.SortHand();

            //assert
            Assert.Equal(secondCard, hand.Cards.Last());
        }
        
        [Theory]
        [InlineData(Rank.Eight, Rank.Ace, 19)]
        [InlineData(Rank.Ten, Rank.Ace, 21)]
        [InlineData(Rank.Queen, Rank.Five, 15)]
        [InlineData(Rank.Ace, Rank.Ace, 12)]
        [InlineData(Rank.Nine, Rank.Four, 13)]
        public void Theory_TotalOfTwoCardHandShouldBeSumOfRank(Rank firstRank, Rank secondRank, int total)
        {
            //arrange
            var firstCard = new Card(firstRank, Suit.Club);
            var secondCard = new Card(secondRank, Suit.Diamond);
            var hand = new Hand(firstCard, secondCard);
            
            //act
            hand.SortHand();
            var result = HandEvaluator.GetTotal(hand);

            //assert
            Assert.Equal(total, result);
        }
        
        [Theory]
        [InlineData(Rank.Eight, Rank.King, 18)]
        [InlineData(Rank.Ten, Rank.Jack, 20)]
        [InlineData(Rank.Queen, Rank.Five, 15)]
        [InlineData(Rank.King, Rank.King, 20)]
        [InlineData(Rank.Queen, Rank.Queen, 20)]
        [InlineData(Rank.Jack, Rank.Jack, 20)]
        [InlineData(Rank.Queen, Rank.Jack, 20)]
        [InlineData(Rank.Queen, Rank.King, 20)]
        [InlineData(Rank.King, Rank.Jack, 20)]
        [InlineData(Rank.Queen, Rank.Ace, 21)]
        public void Theory_FaceCardsShouldValueTenForScoring(Rank firstRank, Rank secondRank, int total)
        {
            //arrange
            var firstCard = new Card(firstRank, Suit.Club);
            var secondCard = new Card(secondRank, Suit.Diamond);
            var hand = new Hand(firstCard, secondCard);
            
            //act
            hand.SortHand();
            var result = HandEvaluator.GetTotal(hand);

            //assert
            Assert.Equal(total, result);
        }
        
        [Theory]
        [InlineData(Rank.Ace, Rank.King, 21)]
        [InlineData(Rank.Ten, Rank.Ace, 21)]
        [InlineData(Rank.Ace, Rank.Ace, 12)]
        [InlineData(Rank.Two, Rank.Ace, 13)]
        [InlineData(Rank.Queen, Rank.Ace, 21)]
        [InlineData(Rank.Jack, Rank.Ace, 21)]
        [InlineData(Rank.King, Rank.Ace, 21)]
        [InlineData(Rank.Ace, Rank.Nine, 20)]
        [InlineData(Rank.Eight, Rank.Ace, 19)]
        [InlineData(Rank.Three, Rank.Ace, 14)]
        public void Theory_AcesShouldValueEitherOneOrElevenDependingOnSumOfNonAceCards(Rank firstRank, Rank secondRank, int total)
        {
            //arrange
            var firstCard = new Card(firstRank, Suit.Club);
            var secondCard = new Card(secondRank, Suit.Diamond);
            var hand = new Hand(firstCard, secondCard);
            
            //act
            hand.SortHand();
            var result = HandEvaluator.GetTotal(hand);

            //assert
            Assert.Equal(total, result);
        }
        /*
        //Adding a card to the Hand
        [Fact]
        public void HandShouldIncreaseAfterAddingACard()
        {
            //arrange
            var expectedCountOfHandCards = 3;
            var expectedFirstCard = new Card(Rank.Ten, Suit.Club);
            var expectedSecondCard = new Card(Rank.Jack, Suit.Club);
            var expectedThridCard = new Card(Rank.Ace, Suit.Club);
            var hand = new Hand(expectedFirstCard, expectedSecondCard);

            //act
            hand.AddCardToHand(expectedThridCard);

            //assert
            Assert.True(hand.Cards.Contains(expectedThridCard));
            Assert.Equal(expectedCountOfHandCards, hand.Cards.Count);
        }
        
        [Fact]
        public void HandShouldSortCards()
        {
            //arrange
            var expectedFirstCard = new Card(Rank.Ten, Suit.Club);
            var expectedSecondCard = new Card(Rank.Jack, Suit.Club);
            var expectedThridCard = new Card(Rank.Ace, Suit.Club);
            var hand = new Hand(expectedFirstCard, expectedThridCard);

            //act
            hand.AddCardToHand(expectedSecondCard);
            hand.SortHand();

            //assert
            Assert.Equal(expectedThridCard, hand.Cards.Last());
        }
        
        [Fact]
        public void PlayersHandTest()
        {
            //arrange
            var firstCard = new Card(Rank.Ace, Suit.Club);
            var secondCard = new Card(Rank.Eight, Suit.Diamond);
            var hand = new Hand(firstCard, secondCard);
            
            //act
            var result = HandEvaluator.GetTotal(hand);
            
            //assert
            Assert.Equal(19,result);
        }
        
        [Fact]
        public void PlayersHandWithKingTest()
        {
            //arrange
            var firstCard = new Card(Rank.King, Suit.Club);
            var secondCard = new Card(Rank.Eight, Suit.Diamond);
            var hand = new Hand(firstCard, secondCard);
            
            //act
            var result = HandEvaluator.GetTotal(hand);
            
            //assert
            Assert.Equal(18, result);
        }
        
        [Fact]
        public void PlayersHandWithQueenTest()
        {
            //arrange
            var firstCard = new Card(Rank.Queen, Suit.Club);
            var secondCard = new Card(Rank.Eight, Suit.Diamond);
            var hand = new Hand(firstCard, secondCard);
            
            //act
            var result = HandEvaluator.GetTotal(hand);
            
            //assert
            Assert.Equal(18, result);
        }
        
        [Fact]
        public void PlayersHandWithJackTest()
        {
            //arrange
            var firstCard = new Card(Rank.Jack, Suit.Club);
            var secondCard = new Card(Rank.Eight, Suit.Diamond);
            var hand = new Hand(firstCard, secondCard);
            
            //act
            var result = HandEvaluator.GetTotal(hand);
            
            //assert
            Assert.Equal(18, result);
        }
*/
        [Fact]
        public void NewHandShouldHaveTwoCards()
        {
            //arrange
            var expectedCountOfHandCards = 2;
            var firstCard = new Card(Rank.Ace, Suit.Club);
            var secondCard = new Card(Rank.Eight, Suit.Diamond);
            var hand = new Hand(firstCard, secondCard);
            
            //act
            var actualCountOfHandCards = hand.Cards.Count;
            
            //assert
            Assert.Equal(expectedCountOfHandCards, actualCountOfHandCards);
        }
        
        [Fact]
        public void PlayersHandWithAceTest()
        {
            //arrange
            var firstCard = new Card(Rank.Ace, Suit.Club);
            var secondCard = new Card(Rank.Eight, Suit.Diamond);
            var hand = new Hand(firstCard, secondCard);
            
            //act
            var result = HandEvaluator.GetTotal(hand);
            
            //assert
            Assert.Equal(19, result);
        }
        
        [Fact]
        public void PlayersHandWithAceTest2()
        {
            //arrange
            var firstCard = new Card(Rank.Ace, Suit.Club);
            var secondCard = new Card(Rank.Ace, Suit.Diamond);
            var hand = new Hand(firstCard, secondCard);
            
            //act
            var result = HandEvaluator.GetTotal(hand);
            
            //assert
            Assert.Equal(12, result);
        }
        
        [Fact]
        public void PlayersHandWithAceTest3()
        {
            //arrange
            var firstCard = new Card(Rank.Ace, Suit.Club);
            var secondCard = new Card(Rank.King, Suit.Diamond);
            var hand = new Hand(firstCard, secondCard);

            //act
            var result = HandEvaluator.GetTotal(hand);
            
            //assert
            Assert.Equal(21, result);
        }
        
        [Fact]
        public void CardShouldPrintTwoDiamond()
        {
            //arrange
            var card = new Card(Rank.Two, Suit.Diamond);
            
            //act
            var result = card.ToString();
            var expected = "Two of Diamond";
            
            //assert
            Assert.Equal(expected, result);
        }
    }
}