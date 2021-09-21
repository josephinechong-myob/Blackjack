using Blackjack.Cards;

namespace Blackjack
{
    public class Player:IBlackjackParticipant
    {
        public Hand Hand { get; }
        private readonly IConsole _console;
        public int Score => HandEvaluator.GetTotal(Hand);
        public string Name { get; }

        public Player(Card firstCard, Card secondCard, IConsole console, string name)
        {
            Hand = new Hand(firstCard, secondCard);
            _console = console;
            Name = name;
        }
        
        public bool Play(IDeck deck) 
        {
            while (!IsThereABust(Score) && !IsThereABlackjack(Score))
            {
                HandEvaluator.PrintHand(Hand, Name, _console);
                var choice = HitOrStay();
                if (choice == "hit")
                {
                    Hit(deck);
                }
                else if (choice == "stay")
                {
                    return false;
                }
            }
            return false;
        }
        
        public void Hit(IDeck deck)
        {
            var drawnCard = deck.DrawRandomCard();
            Hand.AddCardToHand(drawnCard);
            _console.WriteLine($"\nYou draw {drawnCard}");
        }

        private bool IsThereABust(int score)
        {
            if (score > 21)
            {
                _console.WriteLine("\nYou are currently at bust!");
                return true;
            }
            return false;
        }

        private bool IsThereABlackjack(int score)
        {
            if (score == 21)
            {
                HandEvaluator.PrintHand(Hand, Name, _console);
                return true;
            }
            return false;
        }
       
        private string HitOrStay()
        {
            _console.WriteLine("Hit or stay? (Hit = 1, Stay = 0)");
            while (true)
            {
                var answer = _console.ReadLine();
                if (answer == "1") return "hit";
                if (answer == "0") return "stay";
                _console.WriteLine("Please enter a valid value");
            }
        }
    }
}